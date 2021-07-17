import React, { Component } from "react";
import UserService from "../../services/userServices";

export default class Register extends Component {
  constructor(props) {
    super(props);
    this.userService = new UserService();
    this.state = {
      user: {
        email: props.email,
        password: props.password,
        role: props.role,
      },
      errors: {},
    };
  }

  handleEmailRegistered(event) {
    var user = this.state.user;
    user.email = event.target.value;
    this.setState({ user: user });
  }
  handlePasswordRegistered(event) {
    var user = this.state.user;
    user.password = event.target.value;
    this.setState({ user: user });
  }
  handleRoleRegistered(event) {
    var user = this.state.user;
    user.role = event.target.value;
    this.setState({ user: user });
  }

  handleValidation() {
    let fields = this.state.user;
    let errors = {};
    let formIsValid = true;
    if (!fields.email) {
      formIsValid = false;
      errors["email"] = "Enter Email";
    }
    if (!fields.password) {
      formIsValid = false;
      errors["password"] = "Enter Password";
    }
    if (!fields.role) {
      formIsValid = false;
      errors["role"] = "Choose Role";
    }
    this.setState({ errors: errors });
    return formIsValid;
  }
  handleReset = () => {
    //document.querySelectorAll("input");
    this.setState({
      user: [{}],
    });
  };
  handleRegister(event) {
    let result = {};
    let errors = {};
    if (this.handleValidation() === true) {
      result = this.userService.registerUser(this.state.user);
      if (!!result) {
        console.log("Result is If");
        errors["registerSuccess"] = "Successfully Registered!! Sign In";
        this.setState({ errors: errors });
        event.preventDefault();
        this.handleReset();
      } else {
        event.preventDefault();
      }
    } else {
      event.preventDefault();
    }
  }

  render() {
    return (
      <form className="card col-md-5" onSubmit={this.handleRegister.bind(this)}>
        <br />
        <h3>Sign Up</h3>
        <span style={{ color: "green" }}>
          {this.state.errors["registerSuccess"]}
        </span>
        <br />
        <div className="form-group">
          <label>Email address</label>
          <input
            type="email"
            className="form-control"
            placeholder="Enter email"
            value={this.state.user.email || ""}
            onChange={this.handleEmailRegistered.bind(this)}
          />
          <span style={{ color: "red" }}>{this.state.errors["email"]}</span>
        </div>

        <div className="form-group">
          <label>Password</label>
          <input
            type="password"
            className="form-control"
            placeholder="Enter password"
            value={this.state.user.password || ""}
            onChange={this.handlePasswordRegistered.bind(this)}
          />
          <span style={{ color: "red" }}>{this.state.errors["password"]}</span>
        </div>
        <div className="form-group">
          <label>Role</label>
          <select
            className="custom-select"
            id="inputGroupSelect04"
            value={this.state.user.role}
            onChange={this.handleRoleRegistered.bind(this)}
          >
            <option defaultValue>Choose...</option>
            <option value="admin">Admin</option>
            <option value="user">User</option>
            <option value="marketing">Marketing</option>
          </select>
          <span style={{ color: "red" }}>{this.state.errors["role"]}</span>
        </div>
        <button className="btn btn-primary btn-block">Sign Up</button>
        <p className="forgot-password text-right">
          Already registered <a href="/signin">Sign in?</a>
        </p>
      </form>
    );
  }
}
