import React, { Component } from "react";

export default class Home extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoggedIn: false,
    };
  }
  componentDidMount() {
    let result = JSON.parse(localStorage.getItem("currentuser"));
    this.setState({
      isLoggedIn: !result ? true : false,
    });
  }
  render() {
    const { isLoggedIn } = this.state;
    return (
      <div className="jumbotron col-md-7">
        <h1 className="text-center">Goldies Gym</h1>
        <p className="lead text-center">Welcomes</p>

        <hr className="my-4" />
        {!!isLoggedIn && (
          <div className="text-center">
            <a className="btn btn-primary btn-lg" href="/signin" role="button">
              Sign In
            </a>
          </div>
        )}
      </div>
    );
  }
}
