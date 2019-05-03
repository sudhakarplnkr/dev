import { Injectable } from '@angular/core';
import { HttpInterceptorService } from '../shared/httpInterceptor.service';
import { Observable } from 'rxjs/Observable';
import { IAssociateDetail } from '../model/associateDetail';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';


@Injectable()
export class AssociateDetailService {

    private baseUrl: string;
    private header: Headers;
    private options: RequestOptions;

    constructor(private httpInterceptorService: HttpInterceptorService, private http: Http) {
        this.baseUrl = "AssociateDetails";
        this.header = new Headers({ "Content-Type": "application/json" });
        this.options = new RequestOptions({ headers: this.header });
    }

    getAssociate(associateId?: string): Observable<IAssociateDetail[]> {
        //return this.httpInterceptorService.get(this.baseUrl + "?AssociateId=" + associateId)
        return this.httpInterceptorService.get(this.baseUrl + "?Id=" + associateId)
            .map((response: Response) => <IAssociateDetail[]>response.json())
            .catch(this.handleError);

    }
    post(modal: IAssociateDetail): Observable<IAssociateDetail> {
        let body = JSON.stringify(modal);
        return this.httpInterceptorService.post(this.baseUrl, body, this.options)
            .map((response: Response) => <IAssociateDetail>response.json())
            .catch(this.handleError);
    }
    put(modal: IAssociateDetail): Observable<IAssociateDetail> {
        let body = JSON.stringify(modal);
        return this.httpInterceptorService.put(this.baseUrl, body, this.options)
            .map((response: Response) => <IAssociateDetail>response.json())
            .catch(this.handleError);
    }
    deleteAssociate(associateId: string): Observable<any> {
        return this.httpInterceptorService.delete(this.baseUrl + "?Id=" + associateId)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }
    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Server Error');
    }
}