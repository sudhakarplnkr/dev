import * as React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { loadDashboard } from '../actions/DashboardActions';
import DashboardComponent from '../components/DashboardComponent';
import { IDashboardProps, IDashboardState } from '../models/Dashboard';

class DashboardContainer extends React.Component<IDashboardProps, IDashboardState> {
    public componentWillMount() {
        this.props.loadDashboard();
    }

    public render() {
        return (
            <DashboardComponent homeDashboard={this.props.homeDashboard} />
        );
    }
}
const mapStateToProps = (state: any) => {
    return {
        homeDashboard: state.data.homeDashboard,
        isAdmin: state.login.isAdmin
    };
};

const mapDispatchToProps = (dispatch: any) =>
    bindActionCreators(
        {
            loadDashboard
        },
        dispatch
    );

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(DashboardContainer);
