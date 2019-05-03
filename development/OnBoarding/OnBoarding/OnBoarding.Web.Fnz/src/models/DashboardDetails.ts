import { Dashboard } from '../typings/ApiClient';

export interface IDashboardDetailsProps {
    loadDashboard(): void;
    dashboard: Dashboard[];
    isAdmin: boolean;
}

export interface IDashboardDetailsState {
    dashboard: Dashboard[];
    message: string;
}

export class DashboardRole {
    public constructor(
        public Role: string,
        public CompletedCount: number,
        public TotalCount: number,
        public AssociateId: string,
        public AssociateName: string,
        public Fse: string
    ) {

    }
}