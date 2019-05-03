import { Component, OnInit, Input } from '@angular/core';
import { ProjectGroupPlanService } from '../../service/projectGroupPlan.service';
import { IProjectGroupPlan } from '../../model/projectgroupplan'
import { Observable } from 'rxjs/Rx';
import { MatDialog, MatDialogRef } from '@angular/material';
import { ProjectGroupPlanFormComponent } from './projectGroupPlanForm.component';
import { AssociatePlanStatusComponent } from '../associatePlan/associatePlanStatus.component';
import { DBOperation } from '../../shared/enum';
import { AlertService } from '../../shared/alert.service';

@Component({
    selector: 'project-group-plan-list',
    templateUrl: '../projectGroupPlan/projectGroupPlanList.component.html'
})

export class ProjectGroupPlanListComponent {
    
    projectGroupPlans: IProjectGroupPlan[];
    projectGroupPlan: IProjectGroupPlan;    
    projectGroupId: string;
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;

    constructor(private _ProjectGroupPlanService: ProjectGroupPlanService, private dialog: MatDialog, private alertService: AlertService) {
    }

    private onClick(event: Event): void {
        let elementId: Element = (event.target as Element);
        elementId.classList.toggle('in');
    }

    public LoadProjectGroupPlan(projectGroupId: string): void {
        if (!projectGroupId)
        {
            this.projectGroupPlans = [];
            return;
        }

        this.projectGroupId = projectGroupId;
        this._ProjectGroupPlanService.query(projectGroupId)
            .subscribe(projectGroupPlans => { this.projectGroupPlans = projectGroupPlans },
            error => this.alertService.error(<any>error));
    }

    private openDialog() {
        let dialogRef = this.dialog.open(ProjectGroupPlanFormComponent);
        dialogRef.componentInstance.dbops = this.dbops;
        dialogRef.componentInstance.modalTitle = this.modalTitle;
        dialogRef.componentInstance.modalBtnTitle = this.modalBtnTitle;
        dialogRef.componentInstance.projectGroupPlan = this.projectGroupPlan;
        dialogRef.componentInstance.projectGroupId = this.projectGroupId;

        dialogRef.afterClosed().subscribe(result => {
            if (result == "success") {
                this.LoadProjectGroupPlan(this.projectGroupId);
                switch (this.dbops) {
                    case DBOperation.create:
                        this.alertService.success("Plan Created Successfully.");
                        break;
                    case DBOperation.update:
                        this.alertService.success("Plan Updated Successfully.");
                        break;
                    case DBOperation.delete:
                        this.alertService.success("Plan Deleted Successfully.");
                        break;
                }
            }
            else if (result == "error")
                this.alertService.error("There is some issue in saving records, please contact to system administrator!");           
        });
    }

    addPlan() {
        this.dbops = DBOperation.create;
        this.modalTitle = "Add New Plan";
        this.modalBtnTitle = "Add";
        this.openDialog();
    }
    editPlan(id: string) {
        this.dbops = DBOperation.update;
        this.modalTitle = "Edit Plan";
        this.modalBtnTitle = "Update";
        this.projectGroupPlan = this.projectGroupPlans.filter(x => x.Id === id)[0];
        this.openDialog();
    }
    deletePlan(id: string) {
        this.dbops = DBOperation.delete;
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.projectGroupPlan = this.projectGroupPlans.filter(x => x.Id === id)[0];
        this.openDialog();
    }

    getAssociates(id: string) {
        let dialogRef = this.dialog.open(AssociatePlanStatusComponent);
        dialogRef.componentInstance.projectGroupPlanId = id;
    }
}