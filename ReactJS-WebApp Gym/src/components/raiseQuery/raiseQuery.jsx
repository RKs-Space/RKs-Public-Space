import React, { Component } from "react";
import QueryService from "../../services/queryServices";

export default class RaiseQuery extends Component {
  constructor(props) {
    super(props);
    this.queryService = new QueryService();
    this.state = {
      queries: {
        name: props.name,
        email: props.email,
        mobile: props.mobile,
        query: props.queries,
      },
      errors: {},
    };
    this.handleInput = this.handleInput.bind(this);
    this.handleRaiseQuery = this.handleRaiseQuery.bind(this);
  }

  handleInput(e, element) {
    const { queries } = this.state;
    queries[element] = e.target.value;
    this.setState({ queries });
  }
  handleValidation() {
    let fields = this.state.queries;
    let errors = {};
    let formIsValid = true;
    if (!fields.name) {
      formIsValid = false;
      errors["name"] = "Enter Your Name";
    }
    if (!fields.email) {
      formIsValid = false;
      errors["email"] = "Enter Your Email";
    }
    if (!fields.mobile) {
      formIsValid = false;
      errors["mobile"] = "Enter Your Mobile";
    }
    if (!fields.query) {
      formIsValid = false;
      errors["query"] = "Enter Your Query";
    }
    this.setState({ errors: errors });
    return formIsValid;
  }
  handleReset = () => {
    //document.querySelectorAll("input");
    this.setState({
      program: [{}],
    });
  };

  handleRaiseQuery(event) {
    let result = {};
    let errors = {};
    if (this.handleValidation() === true) {
      result = this.queryService.addQuery(this.state.queries);
      if (!!result) {
        errors["queryAddSuccess"] = "Query Raised Successfully";
        alert(errors["queryAddSuccess"]);
        this.setState({ errors: errors });
        this.handleReset();
        event.preventDefault();
      } else {
        event.preventDefault();
      }
    } else {
      event.preventDefault();
    }
  }

  render() {
    const { queries } = this.state;
    const { name, email, mobile, query } = queries;
    return (
      <React.Fragment>
        <form
          className="card col-md-9 margin-left row"
          onSubmit={this.handleRaiseQuery.bind(this)}
        >
          <br />
          <h3>Raise Query</h3>
          <span style={{ color: "green" }}>
            {this.state.errors["queryAddSuccess"]}
          </span>
          <br />
          <div className="form-group">
            <label>Query Name</label>
            <input
              type="text"
              className="form-control col-md-9"
              placeholder="Your Name"
              value={name}
              onChange={(e) => this.handleInput(e, "name")}
            />
            <span style={{ color: "red" }}>{this.state.errors["name"]}</span>
          </div>
          <div className="form-group">
            <label>Email</label>
            <input
              type="email"
              className="form-control col-md-9"
              placeholder="Your Email"
              value={email}
              onChange={(e) => this.handleInput(e, "email")}
            />
            <span style={{ color: "red" }}>{this.state.errors["email"]}</span>
          </div>
          <div className="form-group">
            <label>Mobile</label>
            <input
              type="text"
              className="form-control col-md-5"
              placeholder="Your Mobile"
              value={mobile}
              onChange={(e) => this.handleInput(e, "mobile")}
            />
            <span style={{ color: "red" }}>{this.state.errors["mobile"]}</span>
          </div>
          <div className="form-group">
            <label>Query</label>
            <textarea
              type="textArea"
              className="form-control col-md-9"
              placeholder="Your Query Here"
              value={query}
              onChange={(e) => this.handleInput(e, "query")}
            />
            <span style={{ color: "red" }}>{this.state.errors["query"]}</span>
          </div>
          <br />
          <button className="btn btn-primary btn-block col-md-3">
            Raise Query
          </button>
          <br />
          <br />
        </form>
        <div className="row col-md-10 invisible">S</div>
        <div className="row col-md-10 invisible">S</div>
        <div className="row col-md-10 invisible">S</div>
        <div className="row col-md-10 invisible">S</div>
        <div className="row col-md-10 invisible">S</div>
      </React.Fragment>
    );
  }
}
