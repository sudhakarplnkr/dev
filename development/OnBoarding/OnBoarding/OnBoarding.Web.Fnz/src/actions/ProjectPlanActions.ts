import { ProjectPlan, Role, Project, KnowledgeTransfer, ProcessUpdateProjectPlan, CreateProjectPlan } from '../typings/ApiClient';
import service from '../services/Service';
import { ProjectPlanDetails, ProjectPlanModel } from '../models/ProjectPlan';
import { toastr } from 'react-redux-toastr';
import { MessageConstants } from '../constants/MessageConstants';
import { bindActionCreators } from 'redux';

export const PROJECTPLAN_FAILED_RESPONSE = 'projectPlan/PROJECTPLAN_FAILED_RESPONSE';
export const LOAD_PROJECTPLAN = 'projectPlan/LOAD_PROJECTPLAN';
export const ADD_PROJECTPLAN = 'projectPlan/ADD_PROJECTPLAN';
export const LOAD_ROLE = 'projectPlan/LOAD_ROLE';
export const LOAD_ROLE_FAILED_RESPONSE = 'projectPlan/LOAD_ROLE_FAILED_RESPONSE';
export const LOAD_PROJECT = 'projectPlan/LOAD_PROJECT';
export const LOAD_PROJECT_FAILED_RESPONSE = 'projectPlan/LOAD_PROJECT_FAILED_RESPONSE';
export const LOAD_ACCOUNT_ROLE = 'projectPlan/LOAD_ACCOUNT_ROLE';
export const LOAD_ACCOUNT_ROLE_FAILED_RESPONSE = 'projectPlan/LOAD_ACCOUNT_ROLE_FAILED_RESPONSE';
export const LOAD_TEAM = 'project/LOAD_TEAM';
export const LOAD_TEAM_FAILED_RESPONSE = 'project/LOAD_TEAM_FAILED_RESPONSE';
export const ADD_DATA_PROJECTPLAN = 'project/ADD_DATA_PROJECTPLAN';
export const ADD_DATA_PROJECTPLAN_FAILED_RESPONSE = 'project/ADD_DATA_PROJECTPLAN_FAILED_RESPONSE';
export const UPDATE_PROJECTPLAN_DETAILS = 'projectPlan/UPDATE_PROJECTPLAN_DETAILS';
export const UPDATE_PROJECTPLAN = 'projectPlan/UPDATE_PROJECTPLAN';
export const DELETE_PROJECTPLAN_DETAILS = 'projectPlan/DELETE_PROJECTPLAN_DETAILS';
export const UPDATE_PROJECTPLAN_MODEL = 'projectPlan/UPDATE_PROJECTPLAN_MODEL';
export const RESET_PAGE_MODEL = 'projectPlan/RESET_PAGE_MODEL';
export const LOAD_KNOWLEDGE_TRANSFER = 'knowledgeTransfer/LOAD_KNOWLEDGE_TRANSFER';
export const LOAD_KNOWLEDGE_TRANSFER_FAILED_RESPONSE = 'knowledgeTransfer/LOAD_KNOWLEDGE_TRANSFER_FAILED_RESPONSE';
export type Action = {
    type: string,
    payload: ProjectPlan[]
};

export const loadProjectPlan = (projectId: string) => {
    return (dispatch: any) => {
        service.ProjectPlanClient.query(projectId)
            .then((response: ProjectPlan[]) => {
                dispatch({
                    type: LOAD_PROJECTPLAN,
                    payload: response
                });
            }).catch(() => {
                dispatch({
                    type: PROJECTPLAN_FAILED_RESPONSE
                });
            });
    };
};

export const loadProjectAndRole = () => {
    return (dispatch: any) => {
        service.RoleClient.get()
            .then((response: Role[]) => {
                dispatch({
                    type: LOAD_ROLE,
                    payload: response
                });
            }).catch(() => {
                dispatch({
                    type: LOAD_ROLE_FAILED_RESPONSE,
                    payload: []
                });
            });
        service.ProjectClient.get()
            .then((response: Project[]) => {
                dispatch({
                    type: LOAD_PROJECT,
                    payload: response
                });
            }).catch(() => {
                dispatch({
                    type: LOAD_PROJECT_FAILED_RESPONSE,
                    payload: []
                });
            });
    };
};

export const addProjectPlan = (processCreateProjectPlan: CreateProjectPlan) => {
    return () => {
        service.ProjectPlanClient.post(processCreateProjectPlan)
            .then(() => {
                toastr.success(MessageConstants.PROJECT_PLAN_TITLE_MESSAGE, MessageConstants.SAVE_SUCCESS_MESSAGE);
            })
            .catch(() => {
                toastr.error(MessageConstants.PROJECT_PLAN_TITLE_MESSAGE, MessageConstants.SAVE_ERROR_MESSAGE);
            });
    };
};
export const loadAddProjectPlan = (isAddEdit: boolean) => {
    return (dispatch: any) => {
        dispatch({
            type: ADD_PROJECTPLAN,
            payload: isAddEdit
        });
        service.RoleClient.get()
            .then((response: Role[]) => {
                dispatch({
                    type: LOAD_ROLE,
                    payload: response
                });
            }).catch(() => {
                dispatch({
                    type: LOAD_ROLE_FAILED_RESPONSE,
                    payload: []
                });
            });
        service.ProjectClient.get()
            .then((response: Project[]) => {
                dispatch({
                    type: LOAD_PROJECT,
                    payload: response
                });
            }).catch(() => {
                dispatch({
                    type: LOAD_PROJECT_FAILED_RESPONSE,
                    payload: []
                });
            });
        service.KnowledgeTransferClient.get()
            .then((response: KnowledgeTransfer[]) => {
                dispatch({
                    type: LOAD_KNOWLEDGE_TRANSFER,
                    payload: response
                });
            }).catch(() => {
                dispatch({
                    type: LOAD_KNOWLEDGE_TRANSFER_FAILED_RESPONSE,
                    payload: []
                });
            });
    };
};

export const addProjectPlanDetails = (projectPlan: ProjectPlan, processUpdateProjectPlan: ProcessUpdateProjectPlan) => {
    return (dispatch: any) => {
        {
            service.ProjectPlanClient.put(projectPlan.id, processUpdateProjectPlan)
                .then(() => {
                    dispatch({
                        type: ADD_PROJECTPLAN,
                        payload: false
                    });
                    toastr.success(MessageConstants.PROJECT_PLAN_TITLE_MESSAGE, MessageConstants.SAVE_SUCCESS_MESSAGE);
                    bindActionCreators({ loadProjectPlan }, dispatch).loadProjectPlan(projectPlan.id);
                }).catch(() => {
                    toastr.error(MessageConstants.PROJECT_PLAN_TITLE_MESSAGE, MessageConstants.SAVE_ERROR_MESSAGE);
                });
        }
    };
};
export const loadProjectPlanProject = (projectId: string) => {
    return (dispatch: any) => {
        service.ProjectPlanClient.query(projectId)
            .then((response: ProjectPlan[]) => {
                dispatch({
                    type: UPDATE_PROJECTPLAN,
                    payload: { role: response, selectedProjectId: projectId, selectedRole: undefined, projectPlan: [] }
                });
            }).catch(() => {
                dispatch({
                    type: UPDATE_PROJECTPLAN,
                    payload: { role: [], selectedProjectId: projectId }
                });
            });
    };
};

export const loadProjectPlanRole = (roleId: string) => {
    return (dispatch: any) => {
        service.ProjectPlanClient.query(roleId)
            .then((response: ProjectPlan[]) => {
                dispatch({
                    type: UPDATE_PROJECTPLAN,
                    payload: { projectPlan: response, selectedRoleId: roleId }
                });
            }).catch(() => {
                dispatch({
                    type: UPDATE_PROJECTPLAN,
                    payload: { projectPlan: [], selectedRoleId: roleId }
                });
            });
    };
};

export const updateProjectPlan = (projectPlanDetails: ProjectPlanDetails) => {
    return (dispatch: any) => {
        dispatch({
            type: UPDATE_PROJECTPLAN_DETAILS,
            payload: projectPlanDetails
        });
    };
};

export const updateProjectPlanModel = (projectPlanModel: ProjectPlanModel) => {
    return (dispatch: any) => {
        dispatch({
            type: UPDATE_PROJECTPLAN_MODEL,
            payload: projectPlanModel
        });
    };
};

export const deleteProjectPlan = (id: string) => {
    return (dispatch: any) => {
        service.ProjectPlanClient.delete(id)
            .then(() => {
                bindActionCreators({ loadProjectPlan }, dispatch).loadProjectPlan(id);
                toastr.success(MessageConstants.PROJECT_PLAN_TITLE_MESSAGE, MessageConstants.DELETE_SUCCESS_MESSAGE);
            }).catch(() => {
                toastr.error(MessageConstants.PROJECT_PLAN_TITLE_MESSAGE, MessageConstants.DELETE_ERROR_MESSAGE);
            });
    };
};

export const showModal = (show: Boolean) => {
    return (dispatch: any) => {
        dispatch({
            type: DELETE_PROJECTPLAN_DETAILS,
            payload: { showDialog: show }
        });
    };
};