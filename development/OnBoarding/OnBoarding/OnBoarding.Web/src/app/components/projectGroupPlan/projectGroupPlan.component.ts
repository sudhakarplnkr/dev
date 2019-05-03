import { Component, OnInit, ViewChild } from '@angular/core';
import { ProjectGroupService } from '../../service/projectGroup.service';
import { ProjectService } from '../../service/project.service';
import { IProject } from '../../model/project'
import { IProjectGroup, ProjectGroup } from '../../model/projectGroup'
import { Observable } from 'rxjs/Rx';
import { ProjectGroupPlanListComponent } from '../projectGroupPlan/projectGroupPlanList.component';
import { ProjectGroupComponent } from '../projectGroupPlan/projectGroup.component';
import { MatDialog, MatDialogRef } from '@angular/material';
import { DBOperation } from '../../shared/enum';
import { ConfirmationDialogsService } from '../../shared/confirmationDialog.service';
import { AlertService} from '../../shared/alert.service';

@Component({
    templateUrl: '../projectGroupPlan/projectGroupPlan.component.html'
})

export class ProjectGroupPlanComponent implements OnInit {

    projectGroups: IProjectGroup[];
    projects: IProject[];
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;
    selectedProject: IProject;
    selectedGroup: IProjectGroup;  

    @ViewChild(ProjectGroupPlanListComponent)
    private projectGroupPlanListComponent: ProjectGroupPlanListComponent;

    constructor(private _ProjectGroupService: ProjectGroupService, private _ProjectService: ProjectService, private dialog: MatDialog,
        private confirmationDialogsService: ConfirmationDialogsService,private alertService:AlertService) {
    }

    ngOnInit(): void {
        this.LoadProject();
        this.selectedProject = null;
        this.selectedGroup = null;
    }

    private LoadProject(): void {
        this._ProjectService.get()
            .subscribe(projects => { this.projects = projects });
    }

    public onChangeProject(): void {

        this.selectedGroup = null;
        this.onChangeProjectGroup();

        if (!this.selectedProject) {
            this.projectGroups = [];
            return;
        }

        this._ProjectGroupService.query(this.selectedProject.Id)
            .subscribe(projectGroups => { this.projectGroups = projectGroups });
    }

    public onChangeProjectGroup(): void {
        this.projectGroupPlanListComponent.LoadProjectGroupPlan(this.selectedGroup ? this.selectedGroup.Id : null);
    }

    private addProjectGroup() {
        this.dbops = DBOperation.create;
        this.modalTitle = "Add New Batch";
        this.modalBtnTitle = "Add";
        this.openDialog();
    }

    private editProjectGroup() {
        this.dbops = DBOperation.update;
        this.modalTitle = "Edit Batch";
        this.modalBtnTitle = "Edit";
        this.openDialog();
    }

    private deleteProjectGroup() {
        this.confirmationDialogsService.confirmWithoutContainer("Confirmation", "Are you sure you want to delete this batch? ", true)
            .subscribe(result => {
                if (result) {
                    this._ProjectGroupService.delete(this.selectedGroup.Id).subscribe(data => { this.alertService.success("Batch Deleted Successfully."); this.onChangeProject(); });
                }
            });
    }

    private openDialog() {
        let dialogRef = this.dialog.open(ProjectGroupComponent);
        dialogRef.componentInstance.dbops = this.dbops;
        dialogRef.componentInstance.modalTitle = this.modalTitle;
        dialogRef.componentInstance.modalBtnTitle = this.modalBtnTitle;
        dialogRef.componentInstance.projectGroup = this.selectedGroup == null ? new ProjectGroup(null, this.selectedProject.Id, null, null, null) : this.selectedGroup;

        dialogRef.afterClosed().subscribe(result => {
            if (result == "success") {
                //this.LoadProjectGroupPlan(this.id);
                switch (this.dbops) {
                    case DBOperation.create:
                        this.alertService.success("Batch Created Successfully.");
                        this.onChangeProject();
                        break;
                    case DBOperation.update:
                        this.alertService.success("Batch Updated Successfully.");
                        this.onChangeProjectGroup();
                        break;
                }
            }
            else if (result == "error")
                this.alertService.error("There is some issue in saving records, please contact to system administrator!");            
        });
    }
}