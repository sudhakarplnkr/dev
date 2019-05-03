import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { IAssociateDetail } from '../../model/associateDetail';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AssociateDetailService } from '../../service/associateDetail.service';
import { AssociateListComponent } from '../associatePlan/associateList.component';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ProjectService } from '../../service/project.service';
import { IProject } from '../../model/project';
import { Iteam } from '../../model/team';
import { TeamService } from '../../service/team.service';
import { IAccountRole } from '../../model/accountRole';
import { AccountRoleService } from '../../service/accountRole.service';
import { RoleService } from '../../service/role.service';
import { IRole } from '../../model/role';
import * as moment from 'moment';
import { AlertService } from '../../shared/alert.service';
import { UserRoleService } from '../../service/userRole.service';
import { IUserRole } from '../../model/userRole';

@Component({

    selector: 'associate-detail',
    templateUrl: '../associatePlan/associateDetail.component.html'
})


export class AssociateDetailComponent implements OnInit {

    associateForm: FormGroup;
    associateDetail: IAssociateDetail[];
    associateObject: IAssociateDetail;
    project: IProject[];
    team: Iteam[];
    accountRole: IAccountRole[];
    role: IRole[];
    userRole: IUserRole[]
    associateId: string;
    mode: string;
    isAdmin: boolean = false;

    constructor(private fb: FormBuilder, private associateDetailService: AssociateDetailService,
        private route: ActivatedRoute, private router: Router, private projectService: ProjectService,
        private teamService: TeamService, private accountRoleService: AccountRoleService,
        private roleService: RoleService, private alertService: AlertService, private userRoleService: UserRoleService) {
    }
    ngOnInit() {
        this.route.params.subscribe(params => { this.associateId = params["id"] });
        this.checkUserRole();
        this.buildForm();
        if (this.associateId == "0" && this.associateId != undefined) {
            this.mode = "Add";
            //this.resetForm();
        }
        else {
            this.associateDetailService.getAssociate(this.associateId)
                .subscribe(modal => {
                    this.associateDetail = modal;
                    this.mode = "Update";
                    this.bindData();
                });

        }
        this.getProjectList();
        this.getAccountRole();
        this.getCognizantRole();
        this.associateForm.get("ProjectId").valueChanges.subscribe((data: string) =>
            this.associateForm.get("TeamId").setValue(null));
    }
    private buildForm() {
        this.associateForm = this.fb.group({
            CognizantId: ['', Validators.required],
            AssociateName: ['', Validators.required],
            RLGUserName: [''],
            RLGStaffId: [''],
            RLGRoleId: [null],
            RLGEmail: [''],
            AssetNo: [''],
            VirtualMachineNo: [''],
            Portfolio: [null],
            RLGDateofJoining: [''],
            RLGDateofLeaving: [''],
            RLGExperience: [''],
            Billable: [null],
            Location: [null],
            ContactNo: [''],
            ProjectId: [0, Validators.required],
            TeamId: [null],
            CognizantRoleId: [null, Validators.required],
            CognizantEmailId: ['', Validators.required],
            AssociateId: ['']
        });

        this.associateForm.valueChanges.subscribe(data => this.onValueChanged(data));
        this.onValueChanged();
    }
    private getProjectList() {
        this.projectService.get()
            .subscribe(modal => {
                this.project = modal
            });
    }

    private getAccountRole() {
        this.roleService.get().
            subscribe(modal => {
                this.role = modal
            });
    }

    private getCognizantRole() {
        this.accountRoleService.get().
            subscribe(modal => {
                this.accountRole = modal
            });
    }

    private checkUserRole() {
        this.userRoleService.get().subscribe(userRole => {
            this.userRole = userRole;
            if (this.userRole.find(i => i.Role == "Admin")) {
                this.isAdmin = true;
            }
        });
    }
    private bindData() {
        this.associateObject = this.associateDetail[0];
        this.onChangeProject(this.associateObject.ProjectId);
        this.associateForm.setValue({
            CognizantId: this.associateObject.CognizantId,
            AssociateName: this.associateObject.AssociateName,
            RLGUserName: this.associateObject.RLGUserName,
            RLGStaffId: this.associateObject.RLGStaffId,
            RLGRoleId: this.associateObject.RLGRoleId,
            RLGEmail: this.associateObject.RLGEmail,
            AssetNo: this.associateObject.AssetNo,
            VirtualMachineNo: this.associateObject.VirtualMachineNo,
            Portfolio: this.associateObject.Portfolio,
            RLGDateofJoining: this.associateObject.RLGDateofJoining ? moment(this.associateObject.RLGDateofJoining).utc() : this.associateObject.RLGDateofJoining,
            RLGDateofLeaving: this.associateObject.RLGDateofLeaving ? moment(this.associateObject.RLGDateofLeaving).utc() : this.associateObject.RLGDateofLeaving,
            RLGExperience: this.associateObject.RLGExperience,
            Billable: this.associateObject.Billable,
            Location: this.associateObject.Location,
            ContactNo: this.associateObject.ContactNo,
            ProjectId: this.associateObject.ProjectId,
            TeamId: this.associateObject.TeamId,
            CognizantRoleId: this.associateObject.CognizantRoleId,
            CognizantEmailId: this.associateObject.CognizantEmailId,
            AssociateId: this.associateObject.AssociateId
        });

    }

    private resetForm() {
        this.associateForm.reset();
    }
    private onValueChanged(data?: any) {

        if (!this.associateForm) {
            return;
        }
        const form = this.associateForm;
        for (const field in this.formErrors) {
            this.formErrors[field] = "";
            const control = form.get(field);
            if (control && control.dirty && !control.valid) {
                const messages = this.validationMessages[field];
                for (const key in control.errors) {
                    this.formErrors[field] += messages[key] + ' ';
                }
            }
        }
    }

    onChangeProject(projectId: string) {
        //this.associateForm.get("ProjectId").setValidators([Validators.required]);
        //this.associateForm.controls.up
        //    get("ProjectId").updateValueAndValidity();
        
        if (projectId === "null") {            
            this.team = [];
            return;
        }

        this.teamService.getTeamList(projectId)
            .subscribe(modal => { this.team = modal });
    }
    onSubmit(formData: any) {
        if (this.mode == "Update") {
            this.associateDetailService.put(formData)
                .subscribe(modal => {
                    this.alertService.success("Associate Details Updated Successfully.");
                });
        }
        else {
            this.associateDetailService.post(formData)
                .subscribe(modal => {
                    this.alertService.success("Associate Details Added Successfully.");
                });
        }
    }

    formErrors = {
        'CognizantId': '',
        'AssociateName': '',
        'ProjectId': '',
        'CognizantRoleId': '',
        'CognizantEmailId': '',
        //'RLGUserName': '',
        //'RLGStaffId': '',
        //'RLGRoleId': '',
        //'RLGEmail': '',
        'AssetNo': ''
        //'VirtualMachineNo': '',
        //'Portfolio': '',
        //'RLGExperience': '',
        //'Billable': '',
        //'Location': '',
        //'ContactNo': '',        
        //'TeamId': '',      

    };
    validationMessages = {
        'CognizantId': {
            'required': 'Cognizant employee id is required.'
        },
        'AssociateName': {
            'required': 'Associate name is required.'
        },
        'ProjectId': {
            'required': 'Project name is required.'
        },
        'CognizantRoleId': {
            'required': 'Cognizant role is required.'
        },
        'CognizantEmailId': {
            'required': 'Cognizant email id is required'
        }
        //'RLGUserName': {
        //    'required': 'RLG user name is required.'
        //},
        //'RLGStaffId': {
        //    'required': 'RLG staff id is required.'
        //},
        //'RLGRoleId': {
        //    'required': 'RLG role is required.'
        //},
        //'RLGEmail': {
        //    'required': 'RLG Email id is required.'
        //},
        //'AssetNo': {
        //    'required': 'Asset no is required.'
        //},
        //'VirtualMachineNo': {
        //    'required': 'Virtual machine number is required.'
        //},
        //'Portfolio': {
        //    'required': 'Portfolio is required.'
        //},
        //'RLGExperience': {
        //    'required': 'RLG experience is required.'
        //},
        //'Billable': {
        //    'required': 'Billable is required.'
        //},
        //'Location': {
        //    'required': 'Location is required.'
        //},
        //'ContactNo': {
        //    'required': 'Contact number is required.'
        //},       
        //'TeamId': {
        //    'required': 'Team name is required.'
        //},

    };
}