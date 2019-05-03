import { Component } from '@angular/core';
import { IAssociatePlan } from '../../model/associatePlan';
import { MatDialog, MatDialogRef } from '@angular/material';

@Component({
    templateUrl: '../associatePlan/associatePlanDetail.component.html'
})

export class AssociatePlanDetailComponent {
    associatePlan: IAssociatePlan;

    constructor(public dialogRef: MatDialogRef<AssociatePlanDetailComponent>) {
    }
}