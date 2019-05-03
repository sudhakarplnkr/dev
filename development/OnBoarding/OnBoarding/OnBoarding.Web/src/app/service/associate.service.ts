import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { IAssociate } from '../model/associate'
import { IAssociateProjectGroup } from '../model/associateProjectGroup'
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { HttpInterceptorService } from '../shared/httpInterceptor.service';

@Injectable()
export class AssociateService {
    private baseUrl:string

    constructor(public httpInterceptorService: HttpInterceptorService) {
        this.baseUrl = "Associate"
    }

    get(): Observable<IAssociate[]> {
        return this.httpInterceptorService.get(this.baseUrl)
            .map((response: Response) => <IAssociate[]>response.json())
            .catch(this.handleError);
    }

    getAssociateByProjectGroup(projectId: string, projectGroupId: string): Observable<IAssociateProjectGroup[]> {
        return this.httpInterceptorService.get(this.baseUrl + "?projectId=" + projectId + "&projectGroupId=" + projectGroupId)
            .map((response: Response) => <IAssociateProjectGroup[]>response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}