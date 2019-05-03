import { toastr } from 'react-redux-toastr';
import { MessageConstants } from '../constants/MessageConstants';
import { FileAssociatePlan } from '../models/KtDetails';
import service from '../services/Service';
import { UpdateAssociatePlan } from '../typings/ApiClient';
import { FileParameter } from '../typings/FileManagementService';

export const GET_ASSOCIATEPLAN = 'ktdetails/GET_ASSOCIATEPLAN';
export const UPDATE_ASSOCIATEPLAN = 'ktdetails/UPDATE_ASSOCIATEPLAN';
export const UPLOAD_ASSOCIATEPLAN = 'ktdetails/UPLOAD_ASSOCIATEPLAN';
export const UPDATE_PLAN_DETAIL = 'ktdetails/UPDATE_PLAN_DETAIL';

export const uploadPlan = (associatePlanId: string, file: any) => {
    const fileParameter = {
        data: file,
        fileName: associatePlanId
    } as FileParameter;
    return (dispatch: any) => {
        service.FileManagementClient.upload(associatePlanId, fileParameter)
            .then((response: any) => {
                dispatch({
                    type: UPLOAD_ASSOCIATEPLAN,
                    payload: { fileData: response, associateId: associatePlanId }
                });
                toastr.success(MessageConstants.ASSOCIATE_PLAN_TITLE_MESSAGE, MessageConstants.SAVE_SUCCESS_MESSAGE);
            }).catch(() => {
                toastr.success(MessageConstants.ASSOCIATE_PLAN_TITLE_MESSAGE, MessageConstants.SAVE_ERROR_MESSAGE);
            });
    };
};

export const updatePlan = (associatePlans: FileAssociatePlan[], id: string, plan: FileAssociatePlan) => {
    const updateAssociatePlan = {
        id: id,
        status: true,
        completionDate: plan.completionDate
    } as UpdateAssociatePlan;
    return (dispatch: any) => {
        service.AssociatePlanClient.put(id, updateAssociatePlan)
            .then(() => {
                const plans: FileAssociatePlan[] = [...associatePlans];
                const filePlan = plans.find(u => u.id === id);
                if (filePlan) {
                    filePlan.completionDate = plan.completionDate;
                }
                dispatch({
                    type: UPDATE_ASSOCIATEPLAN,
                    payload: plans
                });
                toastr.success(MessageConstants.ASSOCIATE_PLAN_TITLE_MESSAGE, MessageConstants.SAVE_SUCCESS_MESSAGE);
            }).catch(() => {
                toastr.success(MessageConstants.ASSOCIATE_PLAN_TITLE_MESSAGE, MessageConstants.SAVE_ERROR_MESSAGE);
            });
    };
};

export const onFileChange = (associatePlans: FileAssociatePlan[], associatePlanId: string, file: any) => {
    const plans: FileAssociatePlan[] = [...associatePlans];
    const updatedPlanIndex = plans.findIndex(single => single.id === associatePlanId);
    if (updatedPlanIndex !== -1) {
        plans[updatedPlanIndex].file = file;
        return (dispatch: any) => {
            dispatch({
                type: UPDATE_ASSOCIATEPLAN,
                payload: plans
            });
        };
    }
    return (dispatch: any) => {
        dispatch({
            type: UPDATE_ASSOCIATEPLAN,
            payload: associatePlans
        });
    };
};

export const updatePlanDetail = (associatePlans: FileAssociatePlan[]) => {
    return (dispatch: any) => {
        dispatch({
            type: UPDATE_ASSOCIATEPLAN,
            payload: associatePlans
        });
    };
};

export const planDetail = (associatePlan: FileAssociatePlan) => {
    return (dispatch: any) => {
        dispatch({
            type: UPDATE_PLAN_DETAIL,
            payload: associatePlan
        });
    };
};

export const getAssociatePlans = () => {
    return (dispatch: any) => {
        service.AssociatePlanClient.query()
            .then((response: FileAssociatePlan[]) => {
                dispatch({
                    type: GET_ASSOCIATEPLAN,
                    payload: response
                });
            }).catch(() => {
                toastr.success(MessageConstants.ASSOCIATE_PLAN_TITLE_MESSAGE, MessageConstants.FETCH_ERROR_MESSAGE);
            });
    };
};
