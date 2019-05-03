import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { IRole } from '../model/role'
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { HttpInterceptorService } from '../shared/httpInterceptor.service';


@Injectable()
export class RoleService {
    private baseUrl:string

    constructor(public httpInterceptorService: HttpInterceptorService) {
        this.baseUrl = "Role"
    }

    get(): Observable<IRole[]> {
        return this.httpInterceptorService.get(this.baseUrl)
            .map((response: Response) => <IRole[]>response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}