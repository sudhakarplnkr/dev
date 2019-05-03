import { Component, OnInit, Inject, Input } from '@angular/core';
import { UserRoleService } from '../service/userRole.service';
import { IUserRole } from '../model/userRole'; 
import { Observable } from 'rxjs/Observable';
import { DOCUMENT } from '@angular/common';
import { Routes, Router, CanActivate, RouterModule, ActivatedRouteSnapshot, RouterStateSnapshot, ActivatedRoute, Params } from "@angular/router";

@Component({
    selector: 'onboard',
    template: '<p>Loading...</p>'
})

export class RedirectOnBoardComponent implements OnInit {
    private associateId: string;
    constructor(private userRoleService: UserRoleService, @Inject(DOCUMENT) private document: Document, private router: Router, private route: ActivatedRoute) {
        this.route.queryParams.subscribe(params => { this.associateId = params["id"] });
        if (sessionStorage.getItem("AssociateId") == "" && this.associateId != "") {
            sessionStorage.setItem("AssociateId", this.associateId);
        }
        else if (sessionStorage.getItem("AssociateId") != this.associateId && this.associateId != "") {
            sessionStorage.setItem("AssociateId", this.associateId);
        }
    }
    ngOnInit(): void {
        this.router.navigate(['/']);
    }
}
