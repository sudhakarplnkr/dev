import { HomeDashboard, Team } from '../typings/ApiClient';
import service from '../services/Service';

export const DASHBOARD_FAILED_RESPONCE = 'dashboard/DASHBOARD_FAILED_RESPONCE';
export const UPDATE_DASHBOARD = 'dashboard/UPDATE_DASHBOARD';
export const LOAD_DASHBOARD = 'dashboard/LOAD_DASHBOARD';
export const LOAD_DASHBOARDTEAM = 'dashboard/LOAD_DASHBOARDTEAM';
export const LOAD_DASHBOARDTEAM_FAILED_RESPONSE = 'dashboard/LOAD_DASHBOARDTEAM_FAILED_RESPONSE';

export type Action = {
    type: string,
    payload: HomeDashboard[]
};

export const loadDashboard = () => {
    return (dispatch: any) => {
        service.DashboardClient.get()
            .then((response: HomeDashboard) => {
                dispatch({
                    type: UPDATE_DASHBOARD,
                    payload: response
                });
            }).catch(() => {
                dispatch({
                    type: DASHBOARD_FAILED_RESPONCE
                });
            });
    };
};

export const loadDashboardTeam = (teamId: string) => {
    return (dispatch: any) => {
        service.DashboardClient.query(teamId)
            .then((response: Team[]) => {
                dispatch({
                    type: LOAD_DASHBOARDTEAM,
                    payload: response
                });
            }).catch(() => {
                dispatch({
                    type: LOAD_DASHBOARDTEAM_FAILED_RESPONSE
                });
            });
    };
};
