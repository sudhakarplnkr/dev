import * as React from 'react';
import 'react-accessible-accordion/dist/fancy-example.css';
import {
    Accordion,
    AccordionItem,
    AccordionItemHeading,
    AccordionItemButton,
    AccordionItemPanel,
} from 'react-accessible-accordion';
import { Dashboard, HomeDashboard, Team } from '../typings/ApiClient';
import DashboardDetailsStatusComponent from '../components/DashboardDetailsStatusComponent';

type Props = {
    homeDashBoard: HomeDashboard,
    projectId: string,
    team: Team[];
    teamId?: string,
    loadDashboardTeam: (projectId: string) => void;
};

const DashboardDetailsComponent = (props: Props) => {

    return (
        <div className="container-bottom-space">

            {props.homeDashBoard && props.homeDashBoard.dashboard && props.projectId &&
                Array.from(new Set(props.homeDashBoard.dashboard.filter(u => u.projectId === props.projectId).map((single: Dashboard) => single.projectId)))
                    .map((item: string) => {
                        let dashboard = props.homeDashBoard.dashboard && props.homeDashBoard.dashboard.filter(
                            (singleDashboard: Dashboard) => singleDashboard.projectId === item);

                        return <div key={item} className="col-sm-12">
                            <h3 className="font-weight-bold">{dashboard && dashboard[0].projectName}</h3>
                            <ul key={item}>
                                {props.team && props.team.map((role: Team, roleIndex: number) =>
                                    <Accordion key={roleIndex} allowZeroExpanded={true} allowMultipleExpanded={false} >
                                        <AccordionItem>
                                            <AccordionItemHeading>
                                                <AccordionItemButton style={{ outline: 'none' }}>{role.name}
                                                </AccordionItemButton>
                                            </AccordionItemHeading>
                                            <AccordionItemPanel>
                                                <DashboardDetailsStatusComponent
                                                    homeDashBoard={props.homeDashBoard}
                                                    teamId={role.id}
                                                    projectId={props.projectId}
                                                />
                                            </AccordionItemPanel>
                                        </AccordionItem>
                                    </Accordion>
                                )}
                            </ul>
                        </div>;
                    })
            }
        </div>
    );
};

export default DashboardDetailsComponent;