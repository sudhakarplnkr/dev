import { Component, OnInit } from '@angular/core';
import { AssociatePlanService } from '../../service/associatePlan.service';
import { IAssociatePlan } from '../../model/associatePlan';
import { MatDialog, MatDialogRef } from '@angular/material';
import { DownloadService } from '../../service/download.service';
import { Observable } from 'rxjs/Rx';

@Component({
    templateUrl: '../associatePlan/associatePlanStatus.component.html',
    providers: [AssociatePlanService]
    
})
export class AssociatePlanStatusComponent implements OnInit {

    associatePlan: IAssociatePlan[];
    projectGroupPlanId: string;

    constructor(private associatePlanService: AssociatePlanService, private downloadService: DownloadService, public dialogRef: MatDialogRef<AssociatePlanStatusComponent>) {       
    }

    ngOnInit(): void {
        this.loadStaticData();
    }

    private loadStaticData(): void{
        this.associatePlanService.getAssociatePlanStatus(this.projectGroupPlanId)
            .subscribe(modal => { this.associatePlan = modal });
    }

    public downloadFile(file: string, filename: string): void {
        this.downloadService.downloadFile(file, filename)
    } 
}
