import * as React from 'react';
import { FileAssociatePlan, IKtDetailsProps } from '../models/KtDetails';
import { DateExtension } from '../utils/DateExtension';
import KtPlanDetailsComponent from './KtPlanDetailsComponent';

const KtDetailsComponent = (props: IKtDetailsProps): JSX.Element => {
    return (
        <React.Fragment>
            <KtPlanDetailsComponent AssociatePlan={props.AssociatePlan} updatePlanDetail={() => props.planDetail()} />
            <table id="dtBasicExample" className="table table-striped table-bordered table-sm" cellSpacing="0">
                <thead>
                    <tr>
                        <th className="th-sm">Week</th>
                        <th className="th-sm">Day</th>
                        <th className="th-sm">Title</th>
                        <th className="th-sm">Schedule Date</th>
                        <th className="th-sm">Upload</th>
                        <th className="th-sm text-center">Download</th>
                    </tr>
                </thead>
                <tbody>
                    {props.AssociatePlans && props.AssociatePlans.map((plan: FileAssociatePlan, index: number) =>
                        <tr key={index}>
                            <td>{plan.week}</td>
                            <td>{plan.day}</td>
                            <td><div className="link" onClick={() => props.planDetail(plan)}>{plan.knowledgeTransferTitle}</div></td>
                            <td>{plan.scheduledDate.toDateString()}</td>
                            <td>{plan.proofType === 1 && <input title="png &amp; jpeg file types will be accepted." accept="image/x-png,image/jpeg" type="file" onChange={(event: any) => props.onChange(plan.id, event.target.files)} />}
                                {plan.proofType === 1 && plan.file && <input type="button" onClick={() => props.uploadPlan(plan.id, plan.file)} value="Upload" className="btn" />}
                                {plan.proofType === 2 && <React.Fragment>
                                    <input
                                        type="date"
                                        className="form-control"
                                        defaultValue={DateExtension.formatDate(plan.completionDate)}
                                        onChange={(event) => props.onCompletionDateChange(plan, event.target.value)}
                                        placeholder="dd-MM-yyyy"
                                    />
                                    <input type="button" onClick={() => props.AssociatePlans && props.updatePlan(props.AssociatePlans, plan.id, plan)} value="Update" className="btn" />
                                </React.Fragment>}
                            </td>
                            <td className="download text-center">
                                {plan.proof && <i onClick={() => props.downloadPlan(plan.proof, plan.id)} className="fa fa-download" />}
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        </React.Fragment>
    );
};

export default KtDetailsComponent;