import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { IDashboard } from '../model/Dashboard';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { HttpInterceptorService } from '../shared/httpInterceptor.service';

@Injectable()
export class DashboardService {
    private baseUrl:string

    constructor(public httpInterceptorService: HttpInterceptorService) {
        this.baseUrl = "Dashboard"
    }

    get(): Observable<IDashboard[]> {
        return this.httpInterceptorService.get(this.baseUrl)
            .map((response: Response) => <IDashboard[]>response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}