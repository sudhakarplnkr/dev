import * as React from 'react';
import { Link /* ,Redirect*/ } from 'react-router-dom';
import { CirclePie } from 'salad-ui.chart';
import { Dashboard, HomeDashboard } from '../typings/ApiClient';

type Props = {
    homeDashboard: HomeDashboard,
};

class DashboardComponent extends React.Component<Props, {}> {
    public constructor(props: Props) {
        super(props);
    }
    public render() {
        const fse = this.props.homeDashboard.fse && this.props.homeDashboard.fse;
        const completedFseCount = fse && fse.completedFse ? fse.completedFse : 0;
        const totalFseCount = fse && fse.fseCount ? fse.fseCount : 0;
        const completedFsePercent = Math.round((completedFseCount) / (totalFseCount) * 100);
        const fseOption = {
            width: 100,
            height: 100,
            strokeWidth: 7,
            percent: completedFsePercent,
            strokeColor: 'rgb(31, 207, 101)'
        };
        const sdetOption = {
            width: 100,
            height: 100,
            strokeWidth: 7,
            percent: 0,
            strokeColor: 'rgb(31, 207, 101)'
        };
        return (
            <div className="container-bottom-space">
                <div key="circle-pie" className="col-sm-12">
                    <div className="col-sm-12">
                        <h3>Fse</h3>
                    </div>
                    <div className="col-sm-4">
                        <CirclePie {...fseOption} />
                    </div>
                </div>
                <div key={1} className="col-sm-12">
                    <div className="col-sm-12">
                        <h3>SDET</h3>
                    </div>
                    <div className="col-sm-4">
                        <CirclePie {...sdetOption} />
                    </div>
                </div>
                <div className="container-bottom-space">
                    {
                        this.props.homeDashboard && this.props.homeDashboard.dashboard &&
                        Array.from(new Set(this.props.homeDashboard.dashboard.map((single: Dashboard) => single.projectId)))
                            .map((item: string) => {
                                let dashboard = this.props.homeDashboard.dashboard ? this.props.homeDashboard.dashboard.filter(
                                    (singleDashboard: Dashboard) => singleDashboard.projectId === item) : [];

                                var completedPercent = Math.round((dashboard.map((c: Dashboard) => c.completedCount).reduce((a: number, b: number) => a + b, 0) / dashboard.map((c: Dashboard) => c.count).reduce((a: number, b: number) => a + b, 0)) * 100);
                                completedPercent = completedPercent && isNaN(completedPercent) ? 100 : completedPercent;

                                const option = {
                                    width: 100,
                                    height: 100,
                                    strokeWidth: 7,
                                    percent: completedPercent,
                                    strokeColor: 'rgb(31, 207, 101)'
                                };
                                return <div key={item} className="col-sm-2">
                                    <div className="col-sm-12">
                                        <h3>{dashboard[0].projectName}</h3>
                                    </div>
                                    <div className="col-sm-6">
                                        <Link to={`/dashBoard-details/${dashboard[0].projectId}`}><CirclePie {...option} /></Link>
                                    </div>
                                </div>;
                            })
                    }
                </div>
            </div>
        );
    }
}
export default DashboardComponent;
