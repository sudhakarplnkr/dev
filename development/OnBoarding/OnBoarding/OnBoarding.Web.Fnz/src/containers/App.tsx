import * as React from 'react';
import { connect } from 'react-redux';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import { bindActionCreators } from 'redux';
import { onLogout } from '../actions/AppActions';
import Footer from '../components/Footer';
import Header from '../components/Header';
import LinksComponent from '../components/LinkComponent';
import { PrivateRoute } from '../components/PrivateRoute/PrivateRoute';
import { IAppProps, Link } from '../models/App';
import SessionManagement from '../utils/SessionManagement';
import AssociateContainer from './AssociateContainer';
import Dashboard from './DashboardContainer';
import KtDetailsContainer from './KtDetailsContainer';
import LoginContainer from './LoginContainer';
import LogoutContainer from './LogoutContainer';
import ProjectBatchContainer from './ProjectBatchContainer';
import DashboardDetailsContainer from './DashboardDetailsContainer';
import ProjectPlanContainer from './ProjectPlanContainer';

class AppComponent extends React.Component<IAppProps, {}> {
    public render() {
        const menuLinks: Link[] = [
            { name: 'Dashboard', to: '/', isAdmin: true },
            { name: 'Project Batch', to: '/project-batch', isAdmin: true },
            { name: 'Associate Details', to: '/associate-detail', isAdmin: true },
            { name: 'KT Details', to: '/kt-detail', isAdmin: false },
            { name: 'Project Plan', to: '/project-plan', isAdmin: true },
            { name: 'Logout', to: '/logout', isAdmin: false }
        ];

        return (
            <React.Fragment>
                <Header />
                <Router>
                    <React.Fragment>
                        <LinksComponent links={menuLinks} isAuthenticated={this.props.isAuthenticated} isAdmin={this.props.isAdmin} />
                        <PrivateRoute path="/" exact={true} component={Dashboard} />
                        <Route path="/login" component={() => <LoginContainer />} />
                        <Route path="/logout" component={() => <LogoutContainer onLogout={() => this.props.onLogout()} />} />
                        <PrivateRoute path="/project-batch" component={ProjectBatchContainer} />
                        <PrivateRoute path="/associate-detail" component={AssociateContainer} />
                        <PrivateRoute path="/project-plan" component={ProjectPlanContainer} />
                        <PrivateRoute path="/kt-detail" component={KtDetailsContainer} />
                        <Route path="/dashBoard-details/:projectId" component={DashboardDetailsContainer} />
                    </React.Fragment>
                </Router>
                <Footer />
            </React.Fragment>);
    }
}

const mapStateToProps = (state: any) => {
    const userToken = SessionManagement.GetToken();
    if (userToken) {
        return {
            isAuthenticated: true,
            isAdmin: userToken.isAdmin
        };
    }
    return {
        isAuthenticated: state.app.isAuthenticated,
        isAdmin: state.login.isAdmin
    };

};

const mapDispatchToProps = (dispatch: any) =>
    bindActionCreators(
        {
            onLogout
        },
        dispatch
    );

export default connect(mapStateToProps, mapDispatchToProps)(AppComponent);