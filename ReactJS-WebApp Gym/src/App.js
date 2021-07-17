import React, { Component } from "react";
// Css Style For App
import "./App.css";
// Bootstrap Styles
import "bootstrap/dist/css/bootstrap.min.css";
import Navbar from "react-bootstrap/Navbar";
import Row from "react-bootstrap/Row";
import Container from "react-bootstrap/Container";
// model
import User from "./models/Users";
// services
import AuthService from "./services/auth.service";

// Components
import Footer from "./components/footer/footer";
import Home from "./components/home/home";
import Login from "./components/login/login";
import Register from "./components/register/register";
import AddProgram from "./components/addProgram/addProgram";
import ManageProgram from "./components/manageProgram/manageProgram";
import AllQueries from "./components/allQueries/allQueries";
import AllPrograms from "./components/allPrograms/allPrograms";
import RaiseQuery from "./components/raiseQuery/raiseQuery";
// Routes
import { PrivateRoute } from "./components/privateRoute/privateRoute";
import { Switch, Route, Router } from "react-router-dom";
import { createBrowserHistory } from "history";
export let history = createBrowserHistory();

// App Class
export default class App extends Component {
  constructor(props) {
    super(props);
    this.user = new User();
    this.authService = new AuthService();
    this.state = {
      isHome: false,
      isUser: false,
      isAdmin: false,
      isMarketing: false,
    };
    this.logout = this.logout.bind(this);
  }
  componentDidMount() {
    //console.log("Check Local Storage ", localStorage.getItem("currentuser"));
    if (!localStorage.getItem("currentuser")) {
      this.setState({
        isHome: true,
      });
    } else {
      console.log("Home Or Not", this.state.isHome);
      this.user = JSON.parse(localStorage.getItem("currentuser"));
      console.log("The Logged in User App --", this.user[0].email);
      console.log("The Logged in User Role --", this.user[0].role);
      this.setState({
        isAdmin: this.user && this.user[0].role === "admin",
        isUser: this.user && this.user[0].role === "user",
        isMarketing: this.user && this.user[0].role === "marketing",
      });
    }
  }

  logout() {
    this.authService.logout();
    window.location.reload();
  }

  render() {
    const { isHome, isAdmin, isMarketing, isUser } = this.state;
    return (
      <div>
        <Container>
          <Router history={history}>
            <Row className="row-header">
              <Navbar bg="dark" variant="dark" fixed="top">
                <Navbar.Brand href="/home">Goldies Gym</Navbar.Brand>
                {isHome && (
                  <Navbar.Collapse className="justify-content-end">
                    <Navbar.Brand id="signIn" href="/signin">
                      Sign In
                    </Navbar.Brand>
                    <Navbar.Brand id="signUp" href="/signup">
                      Sign Up
                    </Navbar.Brand>
                  </Navbar.Collapse>
                )}
                ,
                {!isHome && (
                  <Navbar.Collapse className="justify-content-left">
                    {isAdmin && (
                      <Navbar.Collapse>
                        <Navbar.Brand id="admin" href="/addProgram">
                          Add Programs
                        </Navbar.Brand>
                        <Navbar.Brand href="/manageProgram">
                          Manage Program
                        </Navbar.Brand>
                      </Navbar.Collapse>
                    )}
                    ,
                    {isMarketing && (
                      <Navbar.Collapse>
                        <Navbar.Brand href="/allQueries">
                          All Queries
                        </Navbar.Brand>
                      </Navbar.Collapse>
                    )}
                    ,
                    {isUser && (
                      <Navbar.Collapse>
                        <Navbar.Brand href="/allPrograms">
                          All Programs
                        </Navbar.Brand>
                        <Navbar.Brand href="/query">Raise Query</Navbar.Brand>
                      </Navbar.Collapse>
                    )}
                    <Navbar.Collapse className="justify-content-end">
                      <Navbar.Brand href="/signout" onClick={this.logout}>
                        Sign Out
                      </Navbar.Brand>
                    </Navbar.Collapse>
                  </Navbar.Collapse>
                )}
              </Navbar>
            </Row>
            <br />
            <Row className="row-content justify-content-md-center">
              <Switch>
                <Route exact path="/home" component={Home}></Route>
                <Route exact path="/signin" component={Login}></Route>
                <Route exact path="/signup" component={Register}></Route>
                <Route exact path="/signout" component={Home}></Route>
              </Switch>
              <PrivateRoute
                exact
                path="/addProgram"
                component={AddProgram}
              ></PrivateRoute>
              <PrivateRoute
                exact
                path="/manageProgram"
                component={ManageProgram}
              ></PrivateRoute>
              <PrivateRoute
                exact
                path="/allQueries"
                component={AllQueries}
              ></PrivateRoute>
              <PrivateRoute
                exact
                path="/allPrograms"
                component={AllPrograms}
              ></PrivateRoute>
              <PrivateRoute
                exact
                path="/query"
                component={RaiseQuery}
              ></PrivateRoute>
            </Row>
          </Router>
        </Container>

        {/*<div>
          <Footer />
        </div>*/}
      </div>
    );
  }
}
