﻿import { Action, initialPageRequest, UPDATE_ASSOCIATE_MODEL } from '../actions/AssociateActions';
import { AssociateModel, IAssociateState } from '../models/Associate';

const initialState: IAssociateState = {
    Associate: [],
    Role: [],
    Project: [],
    isAddEdit: false,
    accountRole: [],
    team: [],
    associateModel: {
        PageRequest: initialPageRequest()
    } as AssociateModel
};

const AssociateReducer = (state = initialState, action: Action) => {
    switch (action.type) {
        case UPDATE_ASSOCIATE_MODEL:
            return {
                ...state,
                associateModel: { ...state.associateModel, ...action.payload }
            };
        default:
            return state;
    }
};

export default AssociateReducer;
