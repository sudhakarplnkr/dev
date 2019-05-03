import { Injectable } from '@angular/core';
import {
    Http,
    ConnectionBackend,
    RequestOptions,
    RequestOptionsArgs,
    Response,
    Headers,
    Request
} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import { PreLoaderService } from "./preLoader.service";
import { environment } from '../../environments/environment.prod';

@Injectable()
export class HttpInterceptorService extends Http {

    constructor(backend: ConnectionBackend, defaultOptions: RequestOptions, private preloaderService: PreLoaderService) {
        super(backend, defaultOptions);
    }
    private associateId: string;
    get(url: string, options?: RequestOptionsArgs): Observable<any> {
        this.beforeRequest();
        return super.get(this.getFullUrl(url), this.requestOptions(options))
            .catch(this.onCatch)
            .do((res: Response) => {
                //this.onSuccess(res);
            }, (error: any) => {
                //this.onError(error);
            })
            .finally(() => {
                this.onFinally();
            });
    }

    post(url: string, body: any, options?: RequestOptionsArgs): Observable<any> {
        this.beforeRequest();
        return super.post(this.getFullUrl(url), body, this.requestOptions(options))
            .catch(this.onCatch)
            .do((res: Response) => {
                //this.onSuccess(res);
            }, (error: any) => {
                //this.onError(error);
            })
            .finally(() => { this.onFinally(); });


    }

    put(url: string, body: any, options?: RequestOptionsArgs): Observable<any> {
        this.beforeRequest();
        return super.put(this.getFullUrl(url), body, this.requestOptions(options))
            .catch(this.onCatch)
            .do((res: Response) => {
                //this.onSuccess(res);
            }, (error: any) => {
                //this.onError(error);
            })
            .finally(() => { this.onFinally(); });


    }

    delete(url: string, options?: RequestOptionsArgs): Observable<any> {
        this.beforeRequest();
        return super.delete(this.getFullUrl(url), this.requestOptions(options))
            .catch(this.onCatch)
            .do((res: Response) => {
                //this.onSuccess(res);
            }, (error: any) => {
                //this.onError(error);
            })
            .finally(() => {
                this.onFinally();
            });
    }


    private requestOptions(options?: RequestOptionsArgs): RequestOptionsArgs {
        if (options == null) {
            options = new RequestOptions();
        }
        if (options.headers == null) {
            options.headers = new Headers(
                { "Authorization": "Bearer " + sessionStorage.getItem("AssociateId") }
            );
        }
        //For Windows authentication
        // options.withCredentials = true;
        return options;
    }

    private getFullUrl(url: string): string {
        return environment.apiUrl + url;
    }

    private beforeRequest(): void {
        this.preloaderService.showPreloader();
    }

    private afterRequest(): void {
        this.preloaderService.hidePreloader();
    }

    private onCatch(error: any, caught: Observable<any>): Observable<any> {
        return Observable.throw(error);
    }
    private onSuccess(res: Response): void {
        //console.log(res);
    }

    private onError(error: any): void {
        //console.log(error);
    }
    private onFinally(): void {
        this.afterRequest();
    }
}