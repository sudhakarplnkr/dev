import { Injectable } from "@angular/core";
import { Http, Response, Headers, RequestOptions } from "@angular/http";
import { Observable } from 'rxjs/Observable';
import { IUserRole } from '../model/userRole';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { HttpInterceptorService } from '../shared/httpInterceptor.service';
import { environment } from '../../environments/environment.prod';


@Injectable()
export class UserRoleService {
    private baseUrl: string;
    constructor(public httpInterceptorService: HttpInterceptorService) {
        this.baseUrl = "UserRole";
    }
    get(): Observable<IUserRole[]> {
        return this.httpInterceptorService.get(this.baseUrl)
            .map((response: Response) => <IUserRole[]>response.json())
            .catch(this.handleError);
    }
    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}