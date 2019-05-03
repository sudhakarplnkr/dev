import * as React from 'react';
import 'react-fa';
import { Role, Project, KnowledgeTransfer, ProjectPlan } from '../typings/ApiClient';
import { ProjectPlanDetails } from '../models/ProjectPlan';

type Props = {
    role: Role[];
    project: Project[];
    knowledgeTransfer: KnowledgeTransfer[];
    projectPlan: ProjectPlan[];
    loadAddProjectPlan: (isAddEdit: boolean) => void;
    formHandler: () => void;
    updateProjectPlanDetail: (projectPlanDetails?: ProjectPlanDetails) => void;
    projectPlanDetails: ProjectPlanDetails;
};

class ProjectPlanAddComponent extends React.Component<Props, {}> {
    private constructor(props: Props) {
        super(props);
    }
    
    private onNumberChangeWeek = (value: string) => {
        if (value) {
            this.props.updateProjectPlanDetail({ week: Number(value) });
        }
    }
    private onNumberChangeDay = (value: string) => {
        if (value) {
            this.props.updateProjectPlanDetail({ day: Number(value) });
        }
    }
    public render() {
        return (
            <div className="container-fluid">
                <div className="col-md-12">
                    <button name="associatedetails" type="button" onClick={() => this.props.loadAddProjectPlan(false)} value="add" className=" btn btn-link btn pull-left">Associate Details</button>
                </div>
                <div className="col-md-12">
                    <form>
                        <fieldset>
                            <legend>Project Plan</legend>
                            <div className="form-group col-md-4">
                                <label>Project</label>
                                <select className="form-control" value={this.props.projectPlanDetails.projectId} onChange={(event) => this.props.updateProjectPlanDetail({ projectId: event.target.value })} >
                                    <option key="0" value="Select  Cognizant Project">Select Cognizant Project</option>
                                    {this.props.project && this.props.project.map((project: Project) => {
                                        return (
                                            <option key={project.id} value={project.id}>{project.name}</option>
                                        );
                                    })}
                                </select>
                            </div>
                            
                            <div className="form-group col-md-4">
                                <label>Knowledge Transfer</label>
                                <select className="form-control" value={this.props.projectPlanDetails.knowledgeTransferId} onChange={(event) => this.props.updateProjectPlanDetail({ knowledgeTransferId: event.target.value })}>
                                    <option key="0" value="Select Knowledge Transfer">Select Knowledge Transfer</option>
                                    {this.props.knowledgeTransfer && this.props.knowledgeTransfer.map((knowledgeTransfer: KnowledgeTransfer) => {
                                        return (
                                            <option key={knowledgeTransfer.id} value={knowledgeTransfer.id}>{knowledgeTransfer.name}</option>
                                        );
                                    })}
                                </select>
                            </div>
                            
                        </fieldset>
                        <fieldset>
                            
                            <div className="form-group col-md-4">
                                <label>Week</label>
                                <input type="number" className="form-control" defaultValue={`${this.props.projectPlanDetails.week ? this.props.projectPlanDetails.week : ''}`} onChange={(event) => this.onNumberChangeWeek(event.target.value)} id="Week" />
                            </div>

                            <div className="form-group col-md-4">
                                <label>Day</label>
                                <input type="number" className="form-control" defaultValue={`${this.props.projectPlanDetails.day ? this.props.projectPlanDetails.day : ''}`} onChange={(event) => this.onNumberChangeDay(event.target.value)} id="Day" />
                            </div>
                        </fieldset>
                        <div className="form-group  col-md-6 col-md-offset-5">
                            <button name="add" type="button" onClick={() => this.props.formHandler()} value="add" className="btn btn-primary">Add</button>&nbsp;
                            <button name="back" type="button" onClick={() => this.props.loadAddProjectPlan(false)} value="add" className="btn btn-danger">Back</button>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}

export default ProjectPlanAddComponent;