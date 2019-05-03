import { LOAD_PROJECTPLAN, ADD_PROJECTPLAN, LOAD_PROJECT, LOAD_KNOWLEDGE_TRANSFER_FAILED_RESPONSE, LOAD_PROJECT_FAILED_RESPONSE, LOAD_ROLE, LOAD_ROLE_FAILED_RESPONSE, PROJECTPLAN_FAILED_RESPONSE, Action, UPDATE_PROJECTPLAN_DETAILS, UPDATE_PROJECTPLAN_MODEL, LOAD_KNOWLEDGE_TRANSFER, UPDATE_PROJECTPLAN } from '../actions/ProjectPlanActions';
import { IProjectPlanState, ProjectPlanModel, ProjectPlanDetails } from '../models/ProjectPlan';

const initialState: IProjectPlanState = {
    Role: [],
    Project: [],
    ProjectPlan: [],
    KnowledgeTransfer: [],
    isAddEdit: false,
    showDialog: false,
    message: '',
    projectPlanDetails: {
        project: [],
        knowledgeTransfer: [],
        role: [],
        projectPlan: []
    } as ProjectPlanDetails,
    projectPlanModel: {
       
    } as ProjectPlanModel
};

const ProjectPlanReducer = (state = initialState, action: Action) => {
    switch (action.type) {
        case LOAD_PROJECTPLAN:
            return {
                ...state,
                PROJECTPLAN: action.payload
            };
        case ADD_PROJECTPLAN:
            return {
                ...state,
                isAddEdit: action.payload
            };
        case PROJECTPLAN_FAILED_RESPONSE:
            return {
                ...state,
                PROJECTPLAN: action.payload
            };
        case LOAD_ROLE:
            return {
                ...state,
                Role: action.payload
            };
        case LOAD_ROLE_FAILED_RESPONSE:
            return {
                ...state,
                Role: action.payload
            };
        case LOAD_PROJECT:
            return {
                ...state,
                Project: action.payload
            };
        case LOAD_PROJECT_FAILED_RESPONSE:
            return {
                ...state,
                Project: action.payload
            };

        case LOAD_KNOWLEDGE_TRANSFER:
            return {
                ...state,
                KnowledgeTransfer: action.payload
            };
            case LOAD_KNOWLEDGE_TRANSFER_FAILED_RESPONSE:
            return {
                ...state,
                KnowledgeTransfer: action.payload
            };
        
        case UPDATE_PROJECTPLAN_DETAILS:
            return {
                ...state,
                projectPlanDetails: action.payload
            };

        case UPDATE_PROJECTPLAN:
            return {
                ...state,
                projectPlanDetails: action.payload
            };
        case UPDATE_PROJECTPLAN_MODEL:
            return {
                ...state,
                projectPlanModel: action.payload
            };

        default:
            return state;
    }
};

export default ProjectPlanReducer;
