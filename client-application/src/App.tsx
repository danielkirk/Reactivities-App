import React, { Component } from "react";
import "./App.css";
import { Header, Icon, List } from "semantic-ui-react";
import axios from "axios";

class App extends Component {
  state = {
    values: []
  };

  componentDidMount() {
    axios.get("http://localhost:5000/api/values").then(resp => {
      this.setState({
        values: resp.data
      });
    });
  }
  render() {
    return (
      <div>
        <Header as="h2">
          <Icon name="plug" />
          <Header.Content>Uptime Guarantee</Header.Content>
        </Header>
        <List>
          {this.state.values.map((item: any) => (
            <List.Item key={item.id}>{item.name}</List.Item>
          ))}
        </List>
      </div>
    );
  }
}

export default App;
