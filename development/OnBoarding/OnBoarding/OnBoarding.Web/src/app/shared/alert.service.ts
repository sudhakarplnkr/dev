import { Injectable,HostListener,ElementRef } from '@angular/core';
import { Alert, AlertType } from './alert';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs/Subject';
import { NavigationStart, Router } from '@angular/router';


@Injectable()
export class AlertService {
    private subject = new Subject<Alert>();
    private isRouteChange: boolean = false;

    constructor(private router: Router) {
        router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                if (this.isRouteChange) {
                    this.isRouteChange = false;
                }
                else {
                    this.clear();
                }
            }
        });
    }

    success(message: string, isRouteChange = false) {       
        this.alertDetails(AlertType.Success, message, isRouteChange);
    }
    error(message: string, isRouteChange = false) {     
        this.alertDetails(AlertType.Error, message, isRouteChange);
    }
    information(message: string, isRouteChange = false) {
        this.alertDetails(AlertType.Information, message, isRouteChange);
    }
    alertDetails(type: AlertType, message: string, isRouteChange = false) {
        this.clear();
        this.isRouteChange = isRouteChange;
        this.subject.next(<Alert>{ type: type, message: message });   
        window.scrollTo(0, 0);   
    }
    getAlert(): Observable<any> {        
        return this.subject.asObservable();
    }
    clear() {
        this.subject.next();
    }
}