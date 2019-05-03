import { Component, OnInit, ElementRef } from "@angular/core";
import { AssociatePlanService } from '../../service/associatePlan.service';
import { DownloadService } from '../../service/download.service';
import { IAssociatePlan } from '../../model/associatePlan';
import { Observable } from 'rxjs/Rx';
import { UpdateAssociatePlan } from '../../model/update-associate-plan';
import { AssociatePlanDetailComponent } from './associatePlanDetail.component';
import { MatDialog, MatDialogRef } from '@angular/material';
import { AlertService } from '../../shared/alert.service';
import * as moment from 'moment';

@Component({
    templateUrl: '../associatePlan/associatePlan.component.html'
})

export class AssociatePlanComponent {

    associatePlans: IAssociatePlan[];

    constructor(private _AssociatePlanService: AssociatePlanService, private downloadService: DownloadService,
        private elem: ElementRef, private dialog: MatDialog, private alertService: AlertService) {

    }

    ngOnInit(): void {
        this.loadData();
    }

    private loadData(): void {
        this._AssociatePlanService.query()
            .subscribe(associatePlans => {
                this.associatePlans = associatePlans
                this.associatePlans.forEach(element => {
                    if (element.CompletionDate) {
                        element.CompletionDate = moment(element.CompletionDate).utc().toDate();
                    }
                    });
            });
    }

    public uploadFile(associatePlan: IAssociatePlan, fileId: string): void {
        let files = this.elem.nativeElement.querySelector("#" + fileId).files;
        let file = files[0];
        if (typeof file === 'undefined') {
            return;
        }
        if (file.type != "image/jpeg" && file.type != "image/png") {
            this.alertService.error("Only JPEG/PNG files are allowed to upload");
            return;
        }
        if (file.size > 2000000) {
            this.alertService.error("Plesae upload 2MB Image");
            return;
        }

        let formData = new FormData();
        formData.append('selectfile', file, file.name);
        this._AssociatePlanService.uploadFile(associatePlan.Id, formData).subscribe(file => {
            associatePlan.Proof = file
            this.alertService.success("Proof Uploaded Successfully.");
        });
    }

    public updateAssociatePlan(associatePlan: IAssociatePlan): void {
        let updateAssociatePlan = new UpdateAssociatePlan(associatePlan.Id, true, associatePlan.CompletionDate);
        updateAssociatePlan.CompletionDate = this.getDate(updateAssociatePlan.CompletionDate);
        this._AssociatePlanService.put(associatePlan.Id, updateAssociatePlan).subscribe(result => {
            this.loadData();
            this.alertService.success("Date Updated Successfully.");
        });
    }

   private getDate(value: Date): Date {
        if (value) {
            value = new Date(value);
            let date = new Date(Date.UTC(value.getFullYear(), value.getMonth(), value.getDate()));
            value.setUTCFullYear(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate());
        }
        return value;
    }

    public downloadFile(file: string, filename: string): void {
        this.downloadService.downloadFile(file, filename)
    }

    public openDialog(associatePlan: IAssociatePlan) {
        let dialogRef = this.dialog.open(AssociatePlanDetailComponent);
        dialogRef.componentInstance.associatePlan = associatePlan;
    }
}