import { Component, OnInit, ElementRef, HostListener } from '@angular/core';
import { Alert, AlertType } from './alert';
import { AlertService } from './alert.service';


@Component({
    selector: 'alert',   
    templateUrl: '../shared/alert.component.html'
})

export class AlertComponent implements OnInit {
    alerts: Alert[] = [];
    constructor(private alertService: AlertService, private elementRef: ElementRef) {
    }

    ngOnInit() {
        this.alertService.getAlert().subscribe((alert: Alert) => {
            if (!alert) {
                this.alerts = [];
                return;
            }
            this.alerts.push(alert);
        }
        );
    } 
    applyCssClass(alert: Alert) {
        if (!alert) {
            return;
        }
        switch (alert.type) {
            case AlertType.Success:
                return 'alert alert-success';
            case AlertType.Error:
                return 'alert alert-danger';
            case AlertType.Information:
                return 'alert alert-info';
        }
    }
    removeAlert(alert: Alert) {
        this.alerts = this.alerts.filter(m => m !== alert);
    }
}