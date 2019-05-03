import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../../service/dashboard.service';
import { IDashboard } from '../../model/dashboard';
import { Observable } from 'rxjs/Rx';

@Component({
    templateUrl: '../dashboard/dashboard.component.html'
})

export class DashboardComponent implements OnInit {

    dashboard: IDashboard[];
    dashboardView: DashboardView[];
    private associateId: string;
    constructor(private dashboardService: DashboardService) {
    }

    ngOnInit(): void {
        this.loadDashboard();
    }

    private loadDashboard(): void {
        this.dashboardService.get()
            .subscribe(dashboard => {
                this.dashboard = dashboard
                this.dash();
            });
    }

    private dash() {
        let unique = Array.from(new Set(this.dashboard.map(item => item.ProjectId + item.TeamId)));

        this.dashboardView = [];
        unique.forEach(item => {
            var dashboard = this.dashboard.filter(
                dashboard => dashboard.ProjectId + dashboard.TeamId === item);

            var completedPercent = Math.round((dashboard.map(c => c.CompletedCount).reduce((a, b) => a + b, 0) / dashboard.map(c => c.Count).reduce((a, b) => a + b, 0)) * 100);
            completedPercent = isNaN(completedPercent) ? 100 : completedPercent;
            var balancePercent = 100 - completedPercent;

            let roles: DashboardRole[] = [];

            dashboard.forEach(item => {
                if (item.RoleName) {
                    let role = new DashboardRole(item.RoleName, item.CompletedCount, item.Count)
                    roles.push(role);
                }
            });

            this.dashboardView.push(new DashboardView(dashboard[0].ProjectName, dashboard[0].TeamName, [completedPercent, balancePercent], roles));
        });
    }

    // Doughnut
    public doughnutChartData: number[] = [45, 55];
    public doughnutChartType: string = 'doughnut';
    public doughnutChartColours: any[] = [{
        backgroundColor: ['#6d3583', '#e6e6ff']
    }];
    public doughnutOptions: any = {
        cutoutPercentage: 80,
        hover: { mode: null },
        tooltips: { enabled: false },
        elements: {
            arc: {
                borderWidth: 0
            }
        }
    };

    // events
    public chartClicked(e: any): void {
       // console.log(e);
    }

    public chartHovered(e: any): void {
       // console.log(e);
    }
}

export class DashboardView {
    constructor(
        public Project: string,
        public Team: string,
        public DoughnutChartData: number[],
        public Roles: DashboardRole[]
    ) {

    }
}

export class DashboardRole {
    constructor(
        public Role: string,
        public CompletedCount: number,
        public TotalCount: number
    ) {

    }
}