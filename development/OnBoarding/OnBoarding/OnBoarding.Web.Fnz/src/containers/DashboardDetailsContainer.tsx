import * as React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { loadDashboard, loadDashboardTeam } from '../actions/DashboardActions';
import DashboardDetailsComponent from '../components/DashboardDetailsComponent';
import { IDashboardProps, IDashboardState } from '../models/Dashboard';

class DashboardDetailsContainer extends React.Component<IDashboardProps, IDashboardState> {
    public componentWillMount() {
        this.props.loadDashboard();
        if (this.props.projectId) {
            this.props.loadDashboardTeam(this.props.projectId);
        }
    }

    public render() {
        return (
            <DashboardDetailsComponent
                homeDashBoard={this.props.homeDashboard}
                projectId={this.props.projectId}
                teamId={this.props.teamId}
                loadDashboardTeam={(teamId: string) => this.props.loadDashboardTeam(teamId)}
                team={this.props.team}
            />
        );
    }
}
const mapStateToProps = (state: any, ownProps: any) => {
    return {
        homeDashboard: state.data.homeDashboard,
        isAdmin: state.login.isAdmin,
        projectId: ownProps.match.params.projectId,
        team: state.data.team
    };
};

const mapDispatchToProps = (dispatch: any) =>
    bindActionCreators(
        {
            loadDashboard,
            loadDashboardTeam
        },
        dispatch
    );

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(DashboardDetailsContainer);
