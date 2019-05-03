import * as React from 'react';
import 'react-fa';
import { Role, Project, ProjectPlan, KnowledgeTransfer } from '../typings/ApiClient';
import ProjectPlanAddComponent from './ProjectPlanAddComponent';
import { ProjectPlanDetails, ProjectPlanModel } from '../models/ProjectPlan';

type Props = {
    loadAddProjectPlan(isAddEdit: boolean): void;
    isAddEdit: boolean;
    loadProjectPlan: (projectId: string) => void;
    projectPlan: ProjectPlan[];
    role: Role[];
    loadProjectAndRole(): void;
    loadProjectPlanProject: (projectId: string) => void;
    loadProjectPlanRole: (roleId: string) => void;
    project: Project[];
    knowledgeTransfer: KnowledgeTransfer[];
    addProjectPlan: (projectPlan: ProjectPlan) => void;
    updateProjectPlanDetail: (projectPlanDetails?: ProjectPlanDetails) => void;
    editProjectPlanDetail: (projectPlanDetails?: ProjectPlanDetails) => void;
    projectPlanDetails: ProjectPlanDetails;
    showModal(show: Boolean): void;
    onAddProjectPlanDetail: () => void;
    showDialog: Boolean;
    formHandler: () => void;
    deleteProjectPlan: () => void;
    updateProjectPlanModel: (projectPlanModel?: ProjectPlanModel) => void;
    projectPlanModel: ProjectPlanModel;
    // PageRequest?: PageRequest;
    // OnPageChange(pageNumber: number): void;
};

const ProjectPlanComponent = (props: Props) => {
    return (
        <React.Fragment>
            {props.isAddEdit ? <ProjectPlanAddComponent projectPlan={props.projectPlan} projectPlanDetails={props.projectPlanDetails} updateProjectPlanDetail={(projectPlanDetails: ProjectPlanDetails) => props.updateProjectPlanDetail(projectPlanDetails)} role={props.role} project={props.project} knowledgeTransfer={props.knowledgeTransfer} loadAddProjectPlan={(isAddEdit: boolean) => props.loadAddProjectPlan(isAddEdit)} formHandler={() => props.formHandler()} /> : ''}
            {!props.isAddEdit && <div className="col-md-12">
                <button type="button" className="btn btn-link btn pull-right" onClick={() => props.onAddProjectPlanDetail()}>Add ProjectPlan</button>
            </div>}
            {!props.isAddEdit &&
                <div className="col-md-12">
                    <div className="col-md-4">
                        <div className="dropdown">
                            <label>Project</label>
                            <select className="form-control" value={props.projectPlanDetails.selectedProjectId} onChange={(event) => props.loadProjectPlanRole(event.target.value)} >
                                <option key="0" value="Select Cognizant Project">Select Project</option>
                                {props.project && props.project.map((project: Project) => {
                                    return (
                                        <option key={project.id} value={project.id}>{project.name}</option>
                                    );
                                })}
                            </select>
                        </div>
                    </div>
                    
                </div>
            }

            {!props.isAddEdit ? <div>
                <table id="dtBasicExample" className="table table-striped table-bordered table-sm" cellSpacing="2">
                    <thead>
                        <tr>
                            <th className="th-sm">Knowledge Transfer
                    </th>
                            <th className="th-sm">Week
                    </th>
                            <th className="th-sm">Day
                    </th>

                        </tr>
                    </thead>
                    <tbody>
                        {props.projectPlanDetails.projectPlan ? props.projectPlanDetails.projectPlan.map((projectPlan: ProjectPlan, index: number) => {
                            return (
                                <tr key={index}>
                                    <td>{projectPlan.knowledgeTransfer ? projectPlan.knowledgeTransfer.name : ''}</td>
                                    <td>{projectPlan.week}</td>
                                    <td>{projectPlan.day}</td>
                                </tr>);
                        }) : null}
                    </tbody>
                </table>
            </div> : ''}
        </React.Fragment >
    );
};

export default ProjectPlanComponent;