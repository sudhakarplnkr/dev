import { Component, OnInit } from '@angular/core';
import { AssociateDetailService } from '../../service/associateDetail.service';
import { IAssociateDetail } from '../../model/associateDetail';
import { IAssociatePlan } from '../../model/associatePlan';
import { Router } from '@angular/router';
import { UserRoleService } from '../../service/userRole.service';
import { IUserRole } from '../../model/userRole';
import { ConfirmationDialogsService } from '../../shared/confirmationDialog.service';
import { AlertService } from '../../shared/alert.service';

@Component({
    templateUrl: '../associatePlan/associateList.component.html'
})
export class AssociateListComponent implements OnInit {

    associateDetail: IAssociateDetail[];
    id: any;
    associateId: string;
    public isView: boolean = false;
    modeType: string;
    userRole: IUserRole[]
    associateCount: number = 0;
    isAdmin: boolean = false;

    constructor(private associateDetailService: AssociateDetailService,
        private router: Router, private userRoleService: UserRoleService,
        private confirmationDialogsService: ConfirmationDialogsService, private alertService: AlertService) {

    }
    ngOnInit() {
        this.getAssociateListDetails();
    }

    private getAssociateListDetails() {

        //this.id = "5d2b3d87-e959-431c-b85e-ba6b44bf3b43";

        this.userRoleService.get().subscribe(userRole => {
            this.userRole = userRole;
            if (this.userRole.find(i => i.Role == "Admin")) {
                this.id = 0;
                this.isAdmin = true;
            }
            else {
                this.id = 1;
            }
            this.associateDetailService.getAssociate(this.id).subscribe(modal => {
                this.associateDetail = modal
                this.associateCount = modal.length;
            });
        });

    }

    editAssociateDetail(associateId: string): any {
        this.router.navigate(['/associateDetail', associateId]);
    }

    addAssociateDetail(): void {
        this.isView = false;
        this.isView = true
        this.modeType = "Add";
    }
    closeDetail(isClose: boolean): void {
        this.isView = isClose;
    }
    deleteAssociateDetail(associateId: string): void {
        this.confirmationDialogsService.confirmWithoutContainer("Confirmation", "Are you sure you want to delete this associate detail? ", true)
            .subscribe(result => {
                if (result) {
                    this.associateDetailService.deleteAssociate(associateId)
                        .subscribe(data => this.alertService.success("Associate Deleted Successfully."));
                    this.getAssociateListDetails();
                }
            })
    }
}