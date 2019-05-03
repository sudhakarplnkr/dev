import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { AssociateService } from '../../service/associate.service';
import { ProjectGroupService } from '../../service/projectGroup.service';
import { IProjectGroup, IAssociateProjectGroup, IProject, IAssociate, Associate, ICreateProjectGroup, CreateProjectGroup, IUpdateProjectGroup, UpdateProjectGroup } from '../../model/models';
import { Observable } from 'rxjs/Rx';
import { DBOperation } from '../../shared/enum';
import * as moment from 'moment';

@Component({
    templateUrl: '../projectGroupPlan/projectGroup.component.html'
})

export class ProjectGroupComponent implements OnInit {
    
    projectGroup: IProjectGroup;
    associatesInGroup: IAssociateProjectGroup[];
    associatesNotInGroup: IAssociateProjectGroup[];
    selectedAssociatesInGroup: IAssociateProjectGroup[];
    selectedAssociatesNotInGroup: IAssociateProjectGroup[];
    addAssociate: IAssociate[];
    deleteAssociate: IAssociate[];
    associateCodeInGroup: string;
    associateCodeNotInGroup: string;
    msg: string;
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;
    submitted: boolean;

    constructor(private associateService: AssociateService, private projectGroupService: ProjectGroupService,
        public dialogRef: MatDialogRef<ProjectGroupComponent>) {
    }

    ngOnInit(): void {
        this.loadAssociate();
        if (this.projectGroup.StartDate) {
            this.projectGroup.StartDate = moment(this.projectGroup.StartDate).utc().toDate();
        }
        //this.projectGroupFrm.reset();
    }

    private loadAssociate(): void {
        this.associateService.getAssociateByProjectGroup(this.projectGroup.ProjectId, this.projectGroup.Id)
            .subscribe(associates => {
                this.associatesInGroup = associates.filter(
                    assosiate => assosiate.IsGroup)
                this.associatesNotInGroup = associates.filter(
                assosiate => !assosiate.IsGroup)
            });
    }

    public addToGroup(): void {
        this.selectedAssociatesNotInGroup.forEach(source => {
            source.IsGroup = true;
            this.associatesInGroup.push(source);
            this.associatesNotInGroup = this.associatesNotInGroup.filter(obj => obj.Id !== source.Id);
        });
        
        this.selectedAssociatesNotInGroup = [];
        this.associateCodeInGroup = null;
    }

    public addAllToGroup(): void {
        this.associatesNotInGroup.forEach(source => {
            source.IsGroup = true;
            this.associatesInGroup.push(source);
        });

        this.associatesNotInGroup = [];
        this.associateCodeInGroup = null;
    }

    public removeAllFromGroup(): void {
        this.associatesInGroup.forEach(source => {
            source.IsGroup = false;
            this.associatesNotInGroup.push(source);
        });

        this.associatesInGroup = [];
        this.associateCodeNotInGroup = null;
    }

    public removeFromGroup(): void {
        this.selectedAssociatesInGroup.forEach(source => {
            source.IsGroup = false;
            this.associatesNotInGroup.push(source);
            this.associatesInGroup = this.associatesInGroup.filter(obj => obj.Id !== source.Id);
        });

        this.selectedAssociatesInGroup = [];
        this.associateCodeNotInGroup = null;
    }
    submit() {
        this.submitted = true;
        if (this.projectGroup.Name && this.projectGroup.StartDate && this.associatesInGroup.length > 0) {

            this.projectGroup.StartDate = this.getDate(this.projectGroup.StartDate);
            switch (this.dbops) {
                case DBOperation.create:
                    this.createGroup();
                    break;
                case DBOperation.update:
                    this.updateGroup();
                    break;
            }
        }
    }

    private getDate(value: Date): Date {
        if (value) {
            value = new Date(value);
            let date = new Date(Date.UTC(value.getFullYear(), value.getMonth(), value.getDate()));
            value.setUTCFullYear(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate());
        }
        return value;
    }

    private createGroup()
    {
        this.addAssociate = []; 
        this.associatesInGroup.filter(i => i.AssociateGroupId == null).forEach(source => {
            let associate = new Associate(source.Id, source.Code, source.Name, source.RoleId, this.projectGroup.ProjectId);
            this.addAssociate.push(associate);
        });

        let createProjectGroup = new CreateProjectGroup(this.projectGroup.ProjectId, this.projectGroup.Name, this.projectGroup.StartDate, this.addAssociate);

        this.projectGroupService.post(createProjectGroup).subscribe(
            data => {
                this.dialogRef.close("success");
            },
            error => {
                this.dialogRef.close("error");
            }
        );
    }

    private updateGroup() {
        this.addAssociate = []; 
        this.deleteAssociate = []; 

        this.associatesInGroup.filter(i => i.AssociateGroupId == null).forEach(source => {
            let associate = new Associate(source.Id, source.Code, source.Name, source.RoleId, this.projectGroup.ProjectId);
            this.addAssociate.push(associate);
        });

        this.associatesNotInGroup.filter(i => i.AssociateGroupId != null).forEach(source => {
            let associate = new Associate(source.Id, source.Code, source.Name, source.RoleId, this.projectGroup.ProjectId);
            this.deleteAssociate.push(associate);
        });

        let updateProjectGroup = new UpdateProjectGroup(this.projectGroup.Id, this.projectGroup.Name, this.projectGroup.StartDate , this.addAssociate, this.deleteAssociate);

        this.projectGroupService.put(this.projectGroup.Id, updateProjectGroup).subscribe(
            data => {
                this.dialogRef.close("success");
            },
            error => {
                this.dialogRef.close("error");
            }
        );
    }
}