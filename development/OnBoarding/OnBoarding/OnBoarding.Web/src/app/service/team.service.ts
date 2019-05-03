import { Injectable } from '@angular/core';
import { HttpInterceptorService } from '../shared/httpInterceptor.service';
import { Iteam } from '../model/team';
import { Observable } from 'rxjs/Observable';
import { Response, Request, Http } from '@angular/http';

@Injectable()
export class TeamService {

    private baseUrl: string;

    constructor(private httpInterceptorService: HttpInterceptorService) {
        this.baseUrl = "ProjectTeam";
    }

    getTeamList(projectId: string): Observable<Iteam[]> {
        return this.httpInterceptorService.get(this.baseUrl + "?projectId=" + projectId)
            .map((res = Response) => <Iteam[]>res.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || "Server Error");
    }
}