import { GET_ASSOCIATEPLAN, UPDATE_ASSOCIATEPLAN, UPDATE_PLAN_DETAIL, UPLOAD_ASSOCIATEPLAN } from '../actions/KtDetailsActions';
import { FileAssociatePlan, IKtDetailsState } from '../models/KtDetails';

const initialState: IKtDetailsState = {
    AssociatePlans: []
};

const KtDetailsReducer = (state = initialState, action: any) => {
    switch (action.type) {
        case GET_ASSOCIATEPLAN:
            return {
                ...state,
                AssociatePlans: action.payload
            };
        case UPLOAD_ASSOCIATEPLAN:
            let associatePalns = [...state.AssociatePlans];
            updateAssociatePlan(associatePalns, action.payload);
            return {
                ...state,
                AssociatePlans: associatePalns
            };
        case UPDATE_ASSOCIATEPLAN:
            return {
                ...state,
                AssociatePlans: action.payload
            };
            case UPDATE_PLAN_DETAIL:
            return {
                ...state,
                AssociatePlan: action.payload
            };
        default:
            return state;
    }
};

const updateAssociatePlan = (associatePlans: FileAssociatePlan[], associatePlan: FileAssociatePlan) => {
    const updatedPlan = associatePlans.filter((associate: FileAssociatePlan) => associate.id === associatePlan.associateId).pop();
    if (updatedPlan) {
        updatedPlan.proof = associatePlan.fileData;
    }
};

export default KtDetailsReducer;
