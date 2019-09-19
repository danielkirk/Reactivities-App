import React, { Component } from "react";
import { Header, Icon, List } from "semantic-ui-react";
import axios from "axios";
import { IActivity } from "../models/activity";

interface IState {
  activities: IActivity[];
}

class App extends Component<{}, IState> {
  state: IState = {
    activities: []
  };

  componentDidMount() {
    axios.get<IActivity[]>("http://localhost:5000/api/activity").then(resp => {
      this.setState({
        activities: resp.data
      });
    });
  }
  render() {
    return (
      <div>
        <Header as="h2">
          <Icon name="users" />
          <Header.Content>Reactivities</Header.Content>
        </Header>
        <List>
          {this.state.activities.map(activity => (
            <List.Item key={activity.id}>{activity.title}</List.Item>
          ))}
        </List>
      </div>
    );
  }
}

export default App;
