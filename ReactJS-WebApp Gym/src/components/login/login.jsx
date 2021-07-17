import React, { Component } from "react";
import AuthService from "../../services/auth.service";

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.authService = new AuthService();
    this.state = {
      user: {
        email: props.email,
        password: props.password,
      },
      errors: {},
    };
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
    console.log(" Login Called ", formIsValid);
    this.setState({ errors: errors });
    return formIsValid;
  }
  handleLogin = (event) => {
    if (this.handleValidation() === true) {
      //console.log(" Login Called ");
      this.authService.login(this.state.user.email, this.state.user.password);
      //this.state.authUser = this.authService.login(
      //   this.state.user.email,
      //  this.state.user.password
      //);
    } else {
      event.preventDefault();
    }

    //const loginAuth = this.authService.login(this.state.user.email,this.state.user.password);
    //console.log("Return Value ", loginAuth);
    //let item = { email, password };
    //this.performAuthentication();
  };

  handleEmailEntered(event) {
    var user = this.state.user;
    user.email = event.target.value;
    this.setState({ user: user });
  }
  handlePasswordEntered(event) {
    var user = this.state.user;
    user.password = event.target.value;
    this.setState({ user: user });
  }

  render() {
    return (
      <form className="card col-md-5" onSubmit={this.handleLogin.bind(this)}>
        <span style={{ color: "red" }}>
          {this.state.errors["userNotFound"]}
        </span>
        <br />
        <h3>Sign In</h3>
        <br />
        <div className="form-group">
          <label>Email address</label>
          <input
            type="email"
            className="form-control"
            placeholder="Enter email"
            value={this.state.user.email || ""}
            onChange={this.handleEmailEntered.bind(this)}
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
            onChange={this.handlePasswordEntered.bind(this)}
          />
          <span style={{ color: "red" }}>{this.state.errors["password"]}</span>
          <br />

          <button
            className="btn btn-primary btn-block"
            //type="submit"
            //onClick={this.handleLogin}
          >
            Login
          </button>

          <p className="forgot-password text-right">
            New User <a href="/signup">Register ?</a>
          </p>
        </div>
        {/* Remember Me - Not Required,Forgot Password Not Required - Rk
        <div className="form-group">
          <div className="custom-control custom-checkbox">
            <input
              type="checkbox"
              className="custom-control-input"
              id="customCheck1"
            />
          
            <label className="custom-control-label" htmlFor="customCheck1">
              Remember me
            </label>
          
          </div>
           
        </div>
         
        <p className="forgot-password text-right">
          Forgot <a href="#">password?</a>
        </p>
        */}
      </form>
    );
  }
}
