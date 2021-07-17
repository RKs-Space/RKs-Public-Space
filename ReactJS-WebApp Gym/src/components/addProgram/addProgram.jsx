import React, { Component } from "react";
import ProgramService from "../../services/programServices";

export default class AddProgram extends Component {
  constructor(props) {
    super(props);
    this.programService = new ProgramService();
    this.state = {
      program: {
        programName: props.programName,
        description: props.description,
        durationInMonths: props.durationInMonths,
        price: props.price,
        discountRate: props.discountRate,
        currentPrice: props.currentPrice,
        isActive: props.isActive,
      },
      errors: {},
    };
    this.handleChange = this.handleInput.bind(this);
    this.handleSubmit = this.handleAddProgram.bind(this);
  }

  handleInput(e, element) {
    const { program } = this.state;
    program[element] = e.target.value;
    this.setState({ program });
  }
  handleValidation() {
    let fields = this.state.program;
    let errors = {};
    let formIsValid = true;
    if (!fields.programName) {
      formIsValid = false;
      errors["program"] = "Enter Program Name";
    }
    if (!fields.description) {
      formIsValid = false;
      errors["description"] = "Enter Description";
    }
    if (!fields.durationInMonths) {
      formIsValid = false;
      errors["duration"] = "Enter Duration";
    }
    if (!fields.price) {
      formIsValid = false;
      errors["price"] = "Enter Price";
    }
    if (!fields.discountRate) {
      formIsValid = false;
      errors["discountRate"] = "Enter Discount";
    }
    if (!fields.currentPrice) {
      formIsValid = false;
      errors["currentPrice"] = "Enter Current Price";
    }
    if (!fields.isActive) {
      formIsValid = false;
      errors["isActive"] = "Choose Active Status";
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

  handleAddProgram(event) {
    let result = {};
    let errors = {};
    if (this.handleValidation() === true) {
      result = this.programService.addPrograms(this.state.program);
      if (!!result) {
        console.log("Result is If");
        errors["programAddSuccess"] = "Program Added Successfully";
        alert(errors["programAddSuccess"]);
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
    const { program } = this.state;
    const {
      programName,
      description,
      durationInMonths,
      price,
      discountRate,
      currentPrice,
      isActive,
    } = program;
    return (
      <React.Fragment>
        <form
          className="card col-md-9 margin-left row"
          onSubmit={this.handleAddProgram.bind(this)}
        >
          <br />
          <h3>Add Program</h3>
          <span style={{ color: "green" }}>
            {this.state.errors["programAddSuccess"]}
          </span>
          <br />
          <div className="form-group">
            <label>Program Name</label>
            <input
              type="text"
              className="form-control col-md-9"
              placeholder="Program Name"
              value={programName}
              onChange={(e) => this.handleInput(e, "programName")}
            />
            <span style={{ color: "red" }}>{this.state.errors["program"]}</span>
          </div>
          <div className="form-group">
            <label>Description</label>
            <textarea
              type="textArea"
              className="form-control col-md-9"
              placeholder="Description"
              value={description}
              onChange={(e) => this.handleInput(e, "description")}
            />
            <span style={{ color: "red" }}>
              {this.state.errors["description"]}
            </span>
          </div>
          <div className="form-group">
            <label>Duration</label>
            <input
              type="text"
              className="form-control col-md-5"
              placeholder="Duration in Months"
              value={durationInMonths}
              onChange={(e) => this.handleInput(e, "durationInMonths")}
            />
            <span style={{ color: "red" }}>
              {this.state.errors["duration"]}
            </span>
          </div>
          <div className="form-group">
            <label>Price</label>
            <input
              type="text"
              className="form-control col-md-5"
              placeholder="Price"
              value={price}
              onChange={(e) => this.handleInput(e, "price")}
            />
            <span style={{ color: "red" }}>{this.state.errors["price"]}</span>
          </div>
          <div className="form-group">
            <label>Discount Rate</label>
            <input
              type="text"
              className="form-control col-md-5"
              placeholder="Discount Rate"
              value={discountRate}
              onChange={(e) => this.handleInput(e, "discountRate")}
            />
            <span style={{ color: "red" }}>
              {this.state.errors["discountRate"]}
            </span>
          </div>
          <div className="form-group">
            <label>Current Price</label>
            <input
              type="text"
              className="form-control col-md-5"
              placeholder="Current Price"
              value={currentPrice}
              onChange={(e) => this.handleInput(e, "currentPrice")}
            />
            <span style={{ color: "red" }}>
              {this.state.errors["currentPrice"]}
            </span>
          </div>
          <div className="form-group">
            <label>Active/Not</label>
            <select
              className="custom-select"
              id="inputGroupSelect05"
              value={isActive}
              onChange={(e) => this.handleInput(e, "isActive")}
            >
              <option defaultValue>Choose...</option>
              <option value="true">Active</option>
              <option value="false">Inactive</option>
            </select>
            <span style={{ color: "red" }}>
              {this.state.errors["isActive"]}
            </span>
          </div>
          <br />
          <button className="btn btn-primary btn-block col-md-3">
            Add Program
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
