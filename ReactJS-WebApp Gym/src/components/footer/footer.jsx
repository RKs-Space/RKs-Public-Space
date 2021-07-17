import React, { Component } from "react";

export default class Footer extends Component {
  render() {
    return (
      <React.Fragment>
        <br />
        <div className="text-center fixed-bottom bg-dark mt-auto">
          <label className="navbar-text text-white">
            © FSE labelvt Ltd- RKV
          </label>
        </div>
      </React.Fragment>
    );
  }
}
