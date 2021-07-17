import React, { Component } from "react";
import ProgramService from "../../services/programServices";

export default class AllProgram extends Component {
  constructor(props) {
    super(props);
    this.programService = new ProgramService();
    this.state = {
      programs: [],
      errors: {},
      isAdmin: false,
    };
  }
  handleProgramDelete = (programId) => {
    this.programService.deletePrograms(programId);
    window.location.reload();
  };

  componentDidMount() {
    let result = JSON.parse(localStorage.getItem("currentuser"));
    this.programService.getPrograms().then((jsonData) => {
      this.setState({
        programs: jsonData,
        isAdmin: result[0].role === "admin" ? true : false,
      });
    });
  }

  render() {
    const { isAdmin } = this.state;
    return (
      <div className="col-md-12">
        {this.state.programs.map((details, index) => {
          return (
            <React.Fragment key={details.id}>
              <div className="col-md-10">
                <div className="card col-md-10" key={details.id}>
                  <div className="form-group col-md-12" key={details.id}>
                    <br />
                    <div className="row">
                      <h3 key={details.id} className="col-md-5">
                        {details.programName}
                      </h3>
                      <p className="col-md-3"></p>
                      {isAdmin && (
                        <button
                          className="btn btn-outline-danger col-md-3"
                          onClick={() => this.handleProgramDelete(details.id)}
                        >
                          Delete -
                          <svg
                            width="20"
                            height="20"
                            fill="currentColor"
                            className="bi bi-trash"
                            viewBox="0 0 16 16"
                          >
                            <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" />
                            <path
                              fillRule="evenodd"
                              d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4L4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"
                            />
                          </svg>
                        </button>
                      )}
                    </div>
                  </div>
                  <label>Description</label>
                  <div className="form-group">
                    <textarea
                      key={details.id}
                      type="textArea"
                      className="form-control lead col-md-9"
                      value={details.description}
                      readOnly
                    />
                  </div>
                  <div className="form-group">
                    <label>Duration</label>
                    <input
                      key={details.id}
                      type="text"
                      className="form-control col-md-5"
                      value={details.durationInMonths}
                      readOnly
                    />
                  </div>
                  <div className="form-group">
                    <label>Price</label>
                    <input
                      key={details.id}
                      type="text"
                      className="form-control col-md-5"
                      value={details.price}
                      readOnly
                    />
                  </div>
                  <div className="form-group">
                    <label>Dsicount Rate</label>
                    <input
                      key={details.id}
                      type="text"
                      className="form-control col-md-5"
                      value={details.discountRate}
                      readOnly
                    />
                  </div>
                  <div className="form-group">
                    <label>Current Price</label>
                    <input
                      key={details.id}
                      type="text"
                      className="form-control col-md-5"
                      value={details.currentPrice}
                      readOnly
                    />
                  </div>
                  <div className="form-group">
                    <label>Active</label>
                    <input
                      key={details.id}
                      type="text"
                      className="form-control col-md-5"
                      value={
                        details.isActive === true ? "Active" : "Not Active"
                      }
                      readOnly
                    />
                  </div>
                </div>
              </div>

              <div className="row col-md-10 invisible">S</div>
              <div className="row col-md-10 invisible">S</div>
            </React.Fragment>
          );
        })}
      </div>
    );
  }
}
