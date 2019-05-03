export interface IDashboard {
    ProjectId: string,
    TeamId: string,
    RoleId: string,
    ProjectName: string,
    TeamName: string,
    RoleName: string,
    Count: number,
    CompletedCount: number
}

export class Dashboard implements IDashboard {

    constructor(
        public ProjectId: string,
        public TeamId: string,
        public RoleId: string,
        public ProjectName: string,
        public TeamName: string,
        public RoleName: string,
        public Count: number,
        public CompletedCount: number) {
    }
}