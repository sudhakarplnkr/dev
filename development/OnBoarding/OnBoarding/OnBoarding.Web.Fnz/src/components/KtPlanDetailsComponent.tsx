import * as React from 'react';
import 'react-fa';
import { FileAssociatePlan } from '../models/KtDetails';
import ModalDialogComponent from './Shared/ModalDialogComponent';

type Props = {
    updatePlanDetail: (fileAssociatePlan?: FileAssociatePlan) => void;
    AssociatePlan: FileAssociatePlan;
};

const KtPlanDetailsComponent = (props: Props) => {
    if (!props.AssociatePlan) {
        return (null);
    }
    return (
        <ModalDialogComponent
            showDialog={!!props.AssociatePlan}
            title={'Plan Detail'}
            cancelLabel={'Close'}
            hideOk={true}
            Cancel={() => props.updatePlanDetail()}
            element={
                <form className="form-horizontal" noValidate={true}>
                    <div className="form-group">
                        <label className="col-sm-2 text-right" htmlFor="KnowledgeTransfer">KT Title:</label>
                        <div className="col-sm-4">
                            {props.AssociatePlan.knowledgeTransferTitle}
                        </div>
                        <label className="col-sm-2 text-right" htmlFor="Mode">Mode:</label>
                        <div className="col-sm-4">
                            {props.AssociatePlan.modeName}
                        </div>
                    </div>
                    <div className="form-group">
                        {props.AssociatePlan.ownerName && <div>
                            <label className="col-sm-2 text-right" htmlFor="Owner">Owner:</label>
                            <div className="col-sm-4">
                                {props.AssociatePlan.ownerName}
                            </div>
                        </div>}
                        <label className="col-sm-2 text-right" htmlFor="Week">Week:</label>
                        <div className="col-sm-1">
                            {props.AssociatePlan.week}
                        </div>
                    </div>
                    <div className="form-group">
                        <label className="col-sm-2 text-right" htmlFor="Day">Day:</label>
                        <div className="col-sm-4">
                            {props.AssociatePlan.day}
                        </div>
                        <label className="col-sm-3 text-right" htmlFor="ScheduledDate">Scheduled Date:</label>
                        <div className="col-sm-3">
                            {props.AssociatePlan.scheduledDate.toLocaleDateString()}
                        </div>
                    </div>
                    <div className="form-group">
                        <label className="col-sm-2 text-right" htmlFor="Reference">Reference:</label>
                        <div className="col-sm-10 word-wrap">
                            {props.AssociatePlan.reference}
                        </div>
                    </div>
                </form>}
        />
    );
};
export default KtPlanDetailsComponent;