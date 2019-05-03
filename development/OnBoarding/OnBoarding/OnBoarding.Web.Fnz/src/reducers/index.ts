import { reducer as toastrReducer } from 'react-redux-toastr';
import { combineReducers } from 'redux';
import AppReducer from './AppReducer';
import AssociateReducer from './AssociateReducer';
import dashboard from './DashboardReducer';
import KtDetailsReducer from './KtDetailsReducer';
import LoginReducer from './LoginReducer';
import ProjectBatchReducer from './ProjectBatchReducer';
import ProjectPlanReducer from './ProjectPlanReducer';

export default combineReducers({
    app: AppReducer,
    data: dashboard,
    login: LoginReducer,
    ktDetails: KtDetailsReducer,
    associate: AssociateReducer,
    projectBatch: ProjectBatchReducer,
    projectPlan: ProjectPlanReducer,
    toastr: toastrReducer
});
