import { Component, OnInit, Inject, Input, ViewChild, AfterViewInit } from '@angular/core';
import { UserRoleService } from './service/userRole.service';
import { IUserRole } from './model/userRole';
import { Observable } from 'rxjs/Observable';
import { DOCUMENT } from '@angular/common';
import { Routes, Router, CanActivate, RouterModule, ActivatedRouteSnapshot, RouterStateSnapshot, ActivatedRoute, Params } from "@angular/router";

@Component({
    selector: 'app-root',
    templateUrl: '../app/app.component.html'
})

export class AppComponent implements OnInit {
    isAdmin: boolean;
    constructor(private userRoleService: UserRoleService, @Inject(DOCUMENT) private document: Document, private router: Router, private route: ActivatedRoute) {
        
    }
    ngOnInit(): void {
        this.router.events.subscribe((params)=>{
            if(!sessionStorage.getItem("AssociateId") &&
               params["urlAfterRedirects"] != undefined &&
               params["urlAfterRedirects"]["queryParams"]  != undefined &&
               params["urlAfterRedirects"]["queryParams"]["id"]  != undefined)
               {
                    sessionStorage.setItem("AssociateId", params["urlAfterRedirects"]["queryParams"]["id"]);
                    this.LoginUserRole();
               }
               else {
                    this.LoginUserRole();
               }
        });
    }
    private LoginUserRole(): void {
        this.userRoleService.get()
            .subscribe(model => {
                this.isAdmin = model.filter(i => i.Role == "Admin").length == 1;
            });
    }
}
