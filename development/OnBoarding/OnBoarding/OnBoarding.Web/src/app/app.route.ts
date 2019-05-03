import { NgModule, Injectable } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { ProjectGroupPlanComponent } from './components/projectGroupPlan/projectGroupPlan.component';
import { AssociatePlanComponent } from './components/associatePlan/associatePlan.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { RouteAuthorization } from './service/routeAuthorization.service';
import { AssociateListComponent } from './components/associatePlan/associateList.component';
import { AssociateDetailComponent } from './components/associatePlan/associateDetail.component';
import { RedirectOnBoardComponent } from './shared/redirect-onboard.component';

const routes: Routes = [
    { path: '', pathMatch: 'full', canActivate: [RouteAuthorization], component: DashboardComponent },
    { path: 'associatePlan', component: AssociatePlanComponent },
    { path: 'onboarding', component: RedirectOnBoardComponent },
    { path: 'projectGroupPlan', component: ProjectGroupPlanComponent },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'associateList', component: AssociateListComponent },
    { path: 'associateDetail/:id', component: AssociateDetailComponent },
    { path: '**', pathMatch: 'full', canActivate: [RouteAuthorization], component: DashboardComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes, { useHash: true })],
    providers: [RouteAuthorization],
    exports: [RouterModule],
})
export class AppRoutingModule { }

export const RoutingComponents = [ProjectGroupPlanComponent, AssociatePlanComponent, AssociateListComponent, DashboardComponent];