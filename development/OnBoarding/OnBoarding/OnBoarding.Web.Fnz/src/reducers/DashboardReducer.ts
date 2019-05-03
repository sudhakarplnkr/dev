import { UPDATE_DASHBOARD, DASHBOARD_FAILED_RESPONCE, LOAD_DASHBOARDTEAM, LOAD_DASHBOARDTEAM_FAILED_RESPONSE, Action } from '../actions/DashboardActions';
import { IDashboardState } from '../models/Dashboard';
import { HomeDashboard } from '../typings/ApiClient';

const initialState: IDashboardState = {
    homeDashboard: { } as HomeDashboard,
    team: [],
    message: '',
    projectId: ''
};

const DashboardReducer = (state = initialState, action: Action) => {
    switch (action.type) {
        case UPDATE_DASHBOARD:
            return {
                ...state,
                homeDashboard: action.payload
            };
        case DASHBOARD_FAILED_RESPONCE:
            return {
                ...state,
                homeDashboard: action.payload
            };
         case LOAD_DASHBOARDTEAM:
            return {
                ...state,
                team: action.payload
            };
         case LOAD_DASHBOARDTEAM_FAILED_RESPONSE:
            return {
                ...state,
                team: action.payload
            };
        default:
            return state;
    }
};

export default DashboardReducer;
