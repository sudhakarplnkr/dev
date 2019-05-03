import { HomeDashboard, Team } from '../typings/ApiClient';

export interface IDashboardProps {
    loadDashboard(): void;
    loadDashboardTeam(teamId: string): void; 
    projectId: string;
    teamId?: string;
    homeDashboard: HomeDashboard;
    team: Team[];
    isAdmin: boolean;
}

export interface IDashboardState {
    homeDashboard: HomeDashboard;
    team: Team[];
    projectId: string;
    message: string;
}

export class DashboardRole {
    public constructor(
        public ProjectName: string,
        public CompletedCount: number,
        public TotalCount: number,
        public podCompletionPercentage: number,
        public TeamId?: string,
        public RoleName?: string,
        public AssociateId?: string,
        public AssociateName?: string,
        public FSE?: boolean,
        public FseEligiblity?: boolean
    ) {

    }
}