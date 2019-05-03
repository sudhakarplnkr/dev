import { toastr } from 'react-redux-toastr';
import { MessageConstants } from '../constants/MessageConstants';
import service from '../services/Service';
import { UserRole } from '../typings/ApiClient';
import SessionManagement from '../utils/SessionManagement';

export const ON_LOGIN = 'login/ON_LOGIN';
export const CHANGE_ASSOCIATE_ID = 'login/CHANGE_ASSOCIATE_ID';

export const onLogin = (associateId?: number) => {
    return (dispatch: any) => {
        service.RoleServiceClient.get(associateId).then((response: UserRole[]) => {
            if (response.length > 0) {
                const isAdmin = response.filter(u => u.role === 'Admin').length === 1;
                SessionManagement.SetToken({ AssociateId: btoa(`${associateId}:`), isAdmin: isAdmin });
                dispatch({
                    type: ON_LOGIN,
                    payload: { associateId: associateId, isAdmin: isAdmin }
                });
            } else {
                toastr.error(MessageConstants.LOGIN_TITLE_MESSAGE, MessageConstants.LOGIN_FAILED_MESSAGE);
            }
        }).catch(() => {
            toastr.error(MessageConstants.LOGIN_TITLE_MESSAGE, MessageConstants.LOGIN_FAILED_MESSAGE);
        });
    };
};

export const onAssociateIdChange = (associateId?: number) => {
    return (dispatch: any) => {
        dispatch({
            type: CHANGE_ASSOCIATE_ID,
            payload: associateId
        });
    };
};
