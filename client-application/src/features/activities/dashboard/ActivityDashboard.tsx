import React from "react";
import { Grid, GridColumn } from "semantic-ui-react";
import { IActivity } from "../../../app/models/activity";
import ActivityList from "./ActivityList";
import ActivityDetails from "./details/ActivityDetails";

interface IProps {
  activities: IActivity[];
}

const ActivityDashboard: React.FC<IProps> = ({ activities }) => {
  return (
    <Grid>
      <GridColumn width={10}>
        <ActivityList activities={activities} />
      </GridColumn>
      <Grid.Column width={6}>
        <ActivityDetails />
      </Grid.Column>
    </Grid>
  );
};

export default ActivityDashboard;
