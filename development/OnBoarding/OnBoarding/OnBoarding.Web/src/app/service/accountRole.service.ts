import { Injectable } from '@angular/core';
import { Response, Headers, ResponseOptions, Http } from '@angular/http';
import { IAccountRole } from '../model/accountRole';
import { HttpInterceptorService } from '../shared/httpInterceptor.service';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class AccountRoleService {

    private baseUrl: string;

    constructor(private httpInterceptorService: HttpInterceptorService) {
        this.baseUrl = "AccountRole";
    }

    get(): Observable<IAccountRole[]> {
        return this.httpInterceptorService.get(this.baseUrl)
            .map((response: Response) => <IAccountRole[]>response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || "Server Error");
    }
}