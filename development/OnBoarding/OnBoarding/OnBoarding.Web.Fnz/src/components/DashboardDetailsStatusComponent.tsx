import * as React from 'react';
import { DashboardRole } from '../models/Dashboard';
import { Dashboard, HomeDashboard } from '../typings/ApiClient';
import { BarMetric } from 'salad-ui.chart';

type Props = {
    homeDashBoard: HomeDashboard,
    teamId?: string,
    projectId?: string
};
const DashboardDetailsStatusComponent = (props: Props) => {
    return (
        <React.Fragment>
            {props.homeDashBoard && props.homeDashBoard.dashboard && props.teamId && props.projectId &&
                Array.from(new Set(props.homeDashBoard.dashboard.filter(u => u.projectId === props.projectId && u.teamId === props.teamId).map((single: Dashboard) => single.teamId)))
                    .map((item: string) => {
                        let dashboard = props.homeDashBoard.dashboard && props.homeDashBoard.dashboard.filter(
                            (singleDashboard: Dashboard) => singleDashboard.teamId === item);

                        let roles: DashboardRole[] = [];

                        if (dashboard) {
                            let completedPercent = Math.round((dashboard.map((c: Dashboard) => c.completedCount).reduce((a: number, b: number) => a + b, 0) / dashboard.map((c: Dashboard) => c.count).reduce((a: number, b: number) => a + b, 0)) * 100);
                            completedPercent = completedPercent && isNaN(completedPercent) ? 100 : completedPercent;
                        }

                        if (dashboard) {
                            dashboard.filter((roleDashboard: Dashboard) => {
                                if (roleDashboard.teamName) {
                                    let role = new DashboardRole(roleDashboard.teamName, roleDashboard.completedCount, roleDashboard.count, roleDashboard.podCompletionPercentage, roleDashboard.teamId, roleDashboard.roleName, roleDashboard.associateId, roleDashboard.associateName, roleDashboard.fse, roleDashboard.fseEligibility);
                                    roles.push(role);
                                }
                            });
                        }
                        const option = {
                            metricName: '',
                            metricPadding: 200,
                            metricColor: '#777',
                            barHeight: 7,
                            barRailColor: '#ddd',
                            barColor: 'rgb(31, 207, 101)',
                            label: '',
                            value: ''
                        };
                        return (
                            <ul key={item}>
                                <table id="dtBasicExample" className="table table-striped table-bordered table-sm" cellSpacing="0">
                                    <thead>
                                        <tr><th className="th-sm">AssociateID</th>
                                            <th className="th-sm">Associate Name</th>
                                            <th className="th-sm">Role</th>
                                            <th className="th-sm">FSE</th>
                                            <th className="th-sm">Completion Status</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {roles && roles.map((role: DashboardRole, roleIndex: number) =>
                                            <tr key={roleIndex}>
                                                <td>{role.AssociateId}</td>
                                                <td>{role.AssociateName}</td>
                                                <td>{role.RoleName}</td>
                                                <td>{(role.FSE ? 'Yes' : 'No')}</td>
                                                <td>
                                                    <div className="col-sm-12">
                                                        <div className="col-sm-10">
                                                            <BarMetric {...option} percent={role.podCompletionPercentage} />
                                                        </div>
                                                        <span>{role.podCompletionPercentage}%</span>
                                                    </div>
                                                </td>
                                            </tr>)}
                                    </tbody>
                                </table>
                            </ul>
                        );
                    })
            }
        </React.Fragment>
    );
};

export default DashboardDetailsStatusComponent;
