import * as React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { getAssociatePlans, onFileChange, planDetail, updatePlan, updatePlanDetail, uploadPlan } from '../actions/KtDetailsActions';
import KtDetailsComponent from '../components/KtDetailsComponent';
import { FileAssociatePlan, IKtDetailsProps } from '../models/KtDetails';
import DownloadClient from '../utils/DownloadService';

class KtDetailsContainer extends React.Component<IKtDetailsProps, {}> {

    public componentDidMount() {
        if (this.props.getAssociatePlans) {
            this.props.getAssociatePlans();
        }
    }

    private onUploadPlan(associatePlanId: string, file: FileList) {
        if (this.props.AssociatePlans && this.props.onFileChange) {
            this.props.onFileChange(this.props.AssociatePlans, associatePlanId, file[0]);
        }
    }

    private onCompletionDateChange = (fileAssociatePlan?: FileAssociatePlan, completedDate?: string) => {
        if (this.props.AssociatePlans && fileAssociatePlan && completedDate) {
            const plans = [...this.props.AssociatePlans] as FileAssociatePlan[];
            const plan = plans.find(u => u.id === fileAssociatePlan.id);
            if (plan) {
                plan.completionDate = new Date(completedDate);
                this.props.updatePlanDetail(plans);
            }
        }
    }

    public render() {
        return (
            <KtDetailsComponent
                planDetail={this.props.planDetail}
                updatePlan={this.props.updatePlan}
                onCompletionDateChange={this.onCompletionDateChange}
                updatePlanDetail={this.props.updatePlanDetail}
                AssociatePlans={this.props.AssociatePlans}
                AssociatePlan={this.props.AssociatePlan}
                onChange={(associatePlanId: string, file: FileList) => this.onUploadPlan(associatePlanId, file)}
                uploadPlan={this.props.uploadPlan}
                downloadPlan={(file: string, fileName: string) => DownloadClient.downloadFile(file, fileName)}
            />
        );
    }
}

const mapStateToProps = (state: any) => {
    return {
        AssociatePlans: state.ktDetails.AssociatePlans,
        AssociatePlan: state.ktDetails.AssociatePlan
    };
};

const mapDispatchToProps = (dispatch: any) =>
    bindActionCreators(
        {
            getAssociatePlans,
            uploadPlan,
            onFileChange,
            updatePlanDetail,
            updatePlan,
            planDetail
        },
        dispatch
    );

export default connect(mapStateToProps, mapDispatchToProps)(KtDetailsContainer);
