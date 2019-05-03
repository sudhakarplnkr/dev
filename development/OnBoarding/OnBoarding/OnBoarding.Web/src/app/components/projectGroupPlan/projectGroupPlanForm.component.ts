import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material';
import { ProjectGroupPlanService } from '../../service/projectGroupPlan.service';
import { AssociateService } from '../../service/associate.service';
import { KnowledgeTransferService } from '../../service/knowledgeTransfer.service';
import { ModeService } from '../../service/mode.service';
import { RoleService } from '../../service/role.service';
import { IProjectGroupPlan, IAssociate, IKnowledgeTransfer, IRole, IMode } from '../../model/models';
import { Observable } from 'rxjs/Rx';
import { DBOperation } from '../../shared/enum';
import * as moment from 'moment';

@Component({
    templateUrl: '../projectGroupPlan/projectGroupPlanForm.component.html'
})

export class ProjectGroupPlanFormComponent implements OnInit {
    
    projectGroupPlan: IProjectGroupPlan;
    projectGroupId: string;
    knowledgeTransfers: IKnowledgeTransfer[];
    associates: IAssociate[];
    roles: IRole[];
    modes: IMode[];
    msg: string;
    projectGroupPlanFrm: FormGroup;
    dbops: DBOperation;
    stateCtrl: FormControl;
    modalTitle: string;
    modalBtnTitle: string;

    constructor(private fb: FormBuilder,
        private projectGroupPlanService: ProjectGroupPlanService,
        private associateService: AssociateService,
        private knowledgeTransferService: KnowledgeTransferService,
        private modeService: ModeService,
        private roleService: RoleService,
        public dialogRef: MatDialogRef<ProjectGroupPlanFormComponent>) {
    }

    ngOnInit(): void {
        this.loadStatic();
        this.projectGroupPlanFrm = this.fb.group({

            Id: [''],            
            Week: ['', [Validators.required]],
            Day: ['', [Validators.required]],
            KnowledgeTransferId: ['', [Validators.required]],
            Reference: [''],
            ModeId: ['', [Validators.required]],
            RoleId: ['', [Validators.required]],
            OwnerId: [''],
            ProjectGroupId: [''],
            ScheduledDate: ['', [Validators.required]]
        });
       
        this.projectGroupPlanFrm.valueChanges.subscribe(data => this.onValueChanged(data));
        this.onValueChanged();

        if (this.dbops == DBOperation.create) {
            this.projectGroupPlanFrm.reset();      
        }
        else {
            this.projectGroupPlanFrm.setValue({
                Id: this.projectGroupPlan.Id,
                Week: this.projectGroupPlan.Week,
                Day: this.projectGroupPlan.Day,
                KnowledgeTransferId: this.projectGroupPlan.KnowledgeTransferId,
                Reference: this.projectGroupPlan.Reference,
                ModeId: this.projectGroupPlan.ModeId,
                RoleId: this.projectGroupPlan.RoleId,
                OwnerId: this.projectGroupPlan.OwnerId,
                ScheduledDate: this.projectGroupPlan.ScheduledDate ? moment(this.projectGroupPlan.ScheduledDate).utc() : this.projectGroupPlan.ScheduledDate,
                ProjectGroupId: this.projectGroupPlan.ProjectGroupId
            });
        }

        //this.projectGroupPlanFrm.reset();

        this.SetControlsState(this.dbops == DBOperation.delete ? false : true);
    }

    private loadStatic(): void {
        this.associateService.get()
            .subscribe(associates => { this.associates = associates });
        this.knowledgeTransferService.get()
            .subscribe(knowledgeTransfers => { this.knowledgeTransfers = knowledgeTransfers });
        this.modeService.get()
            .subscribe(modes => { this.modes = modes });
        this.roleService.get()
            .subscribe(roles => { this.roles = roles.filter(item => item.Code !== "Other") });
    }

    onValueChanged(data?: any) {

        if (!this.projectGroupPlanFrm) { return; }
        const form = this.projectGroupPlanFrm;

        for (const field in this.formErrors) {
            // clear previous error message (if any)
            this.formErrors[field] = '';
            const control = form.get(field);

            if (control && control.dirty && !control.valid) {
                const messages = this.validationMessages[field];
                for (const key in control.errors) {
                    this.formErrors[field] += messages[key] + ' ';
                }
            }
        }
    }

    formErrors = {
        'KnowledgeTransferId': '',
        'ModeId': '',
        'RoleId': '',
        'ScheduledDate': '',
        'Week': '',
        'Day': ''
    };

    validationMessages = {
        'KnowledgeTransferId': {
            'required': 'Title is required.'
        },
        'ModeId': {
            'required': 'Mode is required.'
        },
        'RoleId': {
            'required': 'Role is required.'
        },
        'ScheduledDate': {
            'required': 'Scheduled date is required.'
        },
        'Week': {
            'required': 'Week is required.'
        },
        'Day': {
            'required': 'Day is required.'
        }
    };

    onSubmit(formData: any) {
        switch (this.dbops) {
            case DBOperation.create:
                formData.value.ProjectGroupId = this.projectGroupId;
                this.projectGroupPlanService.post(formData.value).subscribe(
                    data => {
                        this.dialogRef.close("success");
                    },
                    error => {
                        this.dialogRef.close("error");
                    }
                );
                break;
            case DBOperation.update:
                this.projectGroupPlanService.put(formData.value.Id, formData.value).subscribe(
                    data => {
                        this.dialogRef.close("success");
                    },
                    error => {
                        this.dialogRef.close("error");
                    }
                );
                break;
            case DBOperation.delete:
                this.projectGroupPlanService.delete(formData.value.Id).subscribe(
                    data => {
                        this.dialogRef.close("success");
                    },
                    error => {
                        this.dialogRef.close("error");
                    }
                );
                break;
        }
    }

    SetControlsState(isEnable: boolean) {
        isEnable ? this.projectGroupPlanFrm.enable() : this.projectGroupPlanFrm.disable();
    }
}