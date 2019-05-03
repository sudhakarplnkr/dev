import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { IProject } from '../model/project'
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { HttpInterceptorService } from '../shared/httpInterceptor.service';

@Injectable()
export class ProjectService {
    private baseUrl:string

    constructor(private httpInterceptorService: HttpInterceptorService) {
        this.baseUrl = "Project"
    }

    get(): Observable<IProject[]> {
        return this.httpInterceptorService.get(this.baseUrl)
            .map((response: Response) => <IProject[]>response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}