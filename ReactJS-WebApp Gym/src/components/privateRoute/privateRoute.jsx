import React from "react";
import { Redirect, Route } from "react-router-dom";
import Home from "../../components/home/home";

export const PrivateRoute = ({ component: Component, ...rest }) => (
  <Route
    {...rest}
    render={(props) =>
      localStorage.getItem("currentuser") != null ? (
        <Component {...props} />
      ) : (
        <Redirect
          to={{
            pathname: "/home",
            component: Home,
            state: { from: props.location },
          }}
        />
      )
    }
  />
);
