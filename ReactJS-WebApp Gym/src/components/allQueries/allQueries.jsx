import React, { Component } from "react";
import QueryServices from "../../services/queryServices";

export default class AllQueries extends Component {
  constructor(props) {
    super(props);
    this.queryService = new QueryServices();
    this.state = {
      queries: [],
      errors: {},
      ElementStyle: {
        display: "none",
        readOnly: true,
        disabled: true,
        update: false,
      },
      updateQuery: {
        email: props.email,
        mobile: props.mobile,
        query: props.queries,
        status: props.status,
        cseRemarks: props.cseRemarks,
      },
    };
    this.handleChange = this.handleInput.bind(this);
  }
  handleInput(event) {
    console.log("fIELD ", event);
  }

  handleUpdateQuery = (queryUpdate) => {
    // console.log(" Delete Called Working ", deleteResult);
    //window.location.reload();
    console.log("Called ", queryUpdate);
    this.queryService.updateQuerys(this.state.queries);
  };
  handleQueryUpdateEnable = (event) => {
    this.setState({
      ElementStyle: {
        readOnly: false,
        disabled: false,
        display: "block",
        update: true,
      },
    });
  };

  componentDidMount() {
    this.queryService.getQuerys().then((jsonData) => {
      this.setState({
        queries: jsonData,
      });
    });
  }

  render() {
    const { updateQuery } = this.state;
    const { email, mobile, query, status, cseRemarks } = updateQuery;
    return (
      <div className="container-fluid">
        <div>
          {this.state.queries.map((details, index) => {
            return (
              <div className="row" key={details.id}>
                <React.Fragment key={details.id}>
                  <div className="card col-md-9" key={details.id}>
                    <div className="form-group col-md-9" key={details.id}>
                      <br />
                      <div className="row">
                        <h3 key={details.id} className="col-md-7">
                          {details.name}
                        </h3>
                        <p className="col-md-1"></p>
                        <button
                          className="btn btn-outline-warning col-md-4"
                          onClick={() => this.handleQueryUpdateEnable(details)}
                        >
                          Update -
                          <svg
                            width="16"
                            height="16"
                            fill="currentColor"
                            className="bi bi-pencil-fill"
                            viewBox="0 0 16 16"
                          >
                            <path d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z" />
                          </svg>
                        </button>
                      </div>
                      <br />
                      <span style={{ color: "green" }}>
                        {this.state.errors["queryUpdateSuccess"]}
                      </span>
                    </div>
                    <label>User Email</label>
                    <div className="form-group">
                      <input
                        key={details.id}
                        type="textArea"
                        className="form-control lead col-md-7"
                        value={details.email}
                        readOnly={this.state.ElementStyle.readOnly}
                      />
                    </div>
                    <div className="form-group">
                      <label>User's Mobile</label>
                      <input
                        key={details.id}
                        type="text"
                        className="form-control col-md-7"
                        value={details.mobile}
                        readOnly={this.state.ElementStyle.readOnly}
                      />
                    </div>
                    <div className="form-group">
                      <label>User's Query</label>
                      <textarea
                        key={details.id}
                        type="text"
                        className="form-control col-md-7"
                        value={details.query || query}
                        readOnly={this.state.ElementStyle.readOnly}
                      />
                    </div>
                    <div className="form-group">
                      <label>Query Status</label>
                      <br />
                      <select
                        key={details.id}
                        className="custom-select col-md-7"
                        id="inputGroupSelect06"
                        value={details.status}
                        disabled={this.state.ElementStyle.disabled}
                      >
                        <option defaultValue>Choose...</option>
                        <option value="active">Active</option>
                        <option value="inactive">In-Active</option>
                      </select>
                    </div>
                    <div className="form-group">
                      <label>Closing Remarks</label>
                      <input
                        key={details.id}
                        type="text"
                        className="form-control col-md-7"
                        value={details.cseRemarks}
                        readOnly={this.state.ElementStyle.readOnly}
                      />
                    </div>
                    <br />
                    <button
                      className="btn btn-primary btn-block col-md-7"
                      style={this.state.ElementStyle}
                      onClick={this.handleUpdateQuery()}
                    >
                      Update Query
                    </button>
                    <br />
                  </div>
                  <div className="row col-md-10 invisible">S</div>
                  <div className="row col-md-10 invisible">S</div>
                </React.Fragment>
              </div>
            );
          })}
        </div>
      </div>
    );
  }
}
