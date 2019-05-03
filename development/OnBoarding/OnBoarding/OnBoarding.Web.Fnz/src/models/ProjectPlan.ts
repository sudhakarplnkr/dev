import { ProjectPlan, Project, PageRequest, KnowledgeTransfer } from '../typings/ApiClient';
import { Role } from '../typings/ApiClient';
import { IModalDialogProps } from './ModalDialog';

export interface IProjectPlanProps {
    loadProjectPlan(projectId?: string): void;
    loadProjectAndRole(): void;
    loadPageRequest(pageRequest?: PageRequest): void;
    loadProjectPlanProject: (projectId: string) => void;
    loadProjectPlanRole: (roleId: string) => void;
    loadAddProjectPlan(isAddEdit: boolean): void;
    projectPlan: ProjectPlan[];
    loadKnowledgeTransfer(projectId?: string): void;
    projectPlanDetails: ProjectPlanDetails;
    isAddEdit: boolean;
    Role: Role[];
    Project: Project[];
    KnowledgeTransfer: KnowledgeTransfer[];
    addProjectPlan: (projectPlan: ProjectPlan) => void;
    updateProjectPlan: (projectPlanDetails?: ProjectPlanDetails) => void;
    showModal(show: Boolean): void;
    dialogProps: IModalDialogProps;
    showDialog: Boolean;
    deleteProjectPlan: (id: string) => void;
    updateProjectPlanModel: (projectPlanModel?: ProjectPlanModel) => void;
    projectPlanModel: ProjectPlanModel;
    // OnPageChange(pageNumber: number): void;
}

export interface IProjectPlanState {
    ProjectPlan: ProjectPlan[];
    Role: Role[];
    Project: Project[];
    isAddEdit: boolean;
    KnowledgeTransfer: KnowledgeTransfer[];
    showDialog: Boolean;
    message: string;
    projectPlanModel: ProjectPlanModel;
    projectPlanDetails: ProjectPlanDetails;
}

export interface ProjectPlanDetails {
    id?: string;
    projectId?: string;
    roleId?: string;
    week?: number | undefined;
    day?: number | undefined;
    knowledgeTransferId?: string;
    selectedProject?: Project;
    selectedRole?: Role;
    role?: Role[];
    project?: Project[];
    projectPlan?: ProjectPlan[];
    knowledgeTransfer?: KnowledgeTransfer[];
    selectedProjectId?: string;
    selectedRoleId?: string;
}

export interface ProjectPlanModel {
    deletingProjectId?: string;
    
}