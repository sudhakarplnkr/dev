import * as React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { loadProjectPlan, loadAddProjectPlan, addProjectPlan, updateProjectPlan, showModal, deleteProjectPlan, updateProjectPlanModel, loadProjectAndRole, loadProjectPlanProject, loadProjectPlanRole } from '../actions/ProjectPlanActions';
import ProjectPlanComponent from '../components/ProjectPlanComponent ';
import { IProjectPlanProps, ProjectPlanDetails, ProjectPlanModel } from '../models/ProjectPlan';
import { ProjectPlan } from '../typings/ApiClient';
import { toastr } from 'react-redux-toastr';
import { MessageConstants } from '../constants/MessageConstants';

class ProjectPlanContainer extends React.Component<IProjectPlanProps, {}> {
    public componentWillMount() {
        this.props.loadProjectAndRole();
        if (this.props.projectPlanDetails.projectId) {
            this.props.loadProjectPlan(this.props.projectPlanDetails.projectId);
        }
    }

    private addProjectPlan() {
        const projectPlan = { ...this.props.projectPlanDetails } as ProjectPlan;

        if (!projectPlan.projectId) {
            toastr.error(MessageConstants.PROJECT_PLAN_TITLE_MESSAGE, MessageConstants.PROJECT_PLAN_ROLE_REQUIRED_MESSAGE);
            return;
        }
        if (!projectPlan.knowledgeTransferId) {
            toastr.error(MessageConstants.PROJECT_PLAN_TITLE_MESSAGE, MessageConstants.PROJECT_PLAN_KNOWLEDGE_TRANSFER_REQUIRED_MESSAGE);
            return;
        }
        this.props.addProjectPlan(projectPlan);
    }

    private onEditProjectPlanDetail(projectPlanDetails: ProjectPlanDetails) {
        this.updateProjectPlan(projectPlanDetails);
        this.props.loadAddProjectPlan(true);
    }

    private onAddProjectPlanDetail() {
        this.props.updateProjectPlan({});
        this.props.loadAddProjectPlan(true);
    }

    private updateProjectPlan(projectPlanDetails: ProjectPlanDetails) {
        const projectPlanDetail = { ...this.props.projectPlanDetails, ...projectPlanDetails };
        this.props.updateProjectPlan(projectPlanDetail);
    }

    private deleteProjectPlan() {
        if (this.props.projectPlanModel && this.props.projectPlanModel.deletingProjectId) {
            const model = { ...this.props.projectPlanModel};
            this.props.updateProjectPlanModel(model);
            this.props.deleteProjectPlan(this.props.projectPlanModel.deletingProjectId);
        }
    }
    private onProjectSelect(projectId: string) {
        const project = this.props.projectPlanDetails.project && this.props.projectPlanDetails.project.filter(u => u.id === projectId).pop();
        const model = { ...this.props.projectPlanDetails, selectedProject: project};
        this.props.updateProjectPlan(model);
        this.props.loadProjectPlanProject(projectId);
    }

    private onRoleSelect(roleId: string) {
        const role = this.props.projectPlanDetails.projectPlan && this.props.projectPlanDetails.projectPlan.filter(u => u.id === roleId).pop();
        const model = { ...this.props.projectPlanDetails, selectedRole: role };
        this.props.updateProjectPlan(model);
        this.props.loadProjectPlanRole(roleId);
    }
    public render() {
        return (
            <ProjectPlanComponent
                editProjectPlanDetail={(projectPlanDetails: ProjectPlanDetails) => this.onEditProjectPlanDetail(projectPlanDetails)}
                loadProjectPlan={this.props.loadProjectPlan}
                projectPlanModel={this.props.projectPlanModel}
                updateProjectPlanModel={(projectPlanModel?: ProjectPlanModel) => this.props.updateProjectPlanModel(projectPlanModel)}
                projectPlanDetails={this.props.projectPlanDetails}
                projectPlan={this.props.projectPlan}
                addProjectPlan={this.props.addProjectPlan}
                isAddEdit={this.props.isAddEdit}
                updateProjectPlanDetail={(projectPlanDetails: ProjectPlanDetails) => this.updateProjectPlan(projectPlanDetails)}
                loadAddProjectPlan={(isAddEdit: boolean) => this.props.loadAddProjectPlan(isAddEdit)}
                onAddProjectPlanDetail={() => this.onAddProjectPlanDetail()}
                role={this.props.Role}
                loadProjectPlanProject={(projectId: string) => this.onProjectSelect(projectId)}
                loadProjectPlanRole={(roleId: string) => this.onRoleSelect(roleId)}
                project={this.props.Project}
                deleteProjectPlan={() => this.deleteProjectPlan()}
                knowledgeTransfer={this.props.KnowledgeTransfer}
                formHandler={() => this.addProjectPlan()}
                showModal={(show: Boolean) => this.props.showModal(show)}
                showDialog={this.props.showDialog}
                loadProjectAndRole={this.props.loadProjectAndRole}
            />
        );
    }
}
const mapStateToProps = (state: any) => {
    return {
        isAddEdit: state.projectPlan.isAddEdit,
        Role: state.projectPlan.Role,
        Project: state.projectPlan.Project,
        ProjectPlan: state.projectPlan.ProjectPlan,
        KnowledgeTransfer: state.projectPlan.KnowledgeTransfer,
        projectPlanDetails: state.projectPlan.projectPlanDetails ? state.projectPlan.projectPlanDetails : {},
        showDialog: state.associate.showDialog,
        projectPlanModel: state.projectPlan.projectPlanModel
    };
};

const mapDispatchToProps = (dispatch: any) =>
    bindActionCreators(
        {
            loadProjectPlan,
            loadAddProjectPlan,
            addProjectPlan,
            updateProjectPlan,
            showModal,
            deleteProjectPlan,
            updateProjectPlanModel,
            loadProjectAndRole,
            loadProjectPlanProject,
            loadProjectPlanRole
        },
        dispatch
    );

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(ProjectPlanContainer);