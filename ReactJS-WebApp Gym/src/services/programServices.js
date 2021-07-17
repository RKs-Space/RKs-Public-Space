export default class PogramService {
  async getPrograms() {
    return fetch("http://localhost:4000/programs")
      .then((response) => {
        if (!response.ok) {
          this.handleResponseError(response);
        }
        return response.json();
      })
      .then((json) => {
        const programsArray = json;
        return programsArray;
      })
      .catch((error) => {
        this.handleError(error);
      });
  }
  async addPrograms(newProgram) {
    return fetch("http://localhost:4000/programs", {
      method: "POST",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newProgram),
    })
      .then((response) => {
        if (!response.ok) {
          this.handleResponseError(response);
        }
        return response.json();
      })
      .catch((error) => {
        this.handleError(error);
      });
  }
  async deletePrograms(id) {
    return fetch("http://localhost:4000/programs/" + id, {
      method: "DELETE",
      mode: "cors",
    })
      .then((response) => {
        if (!response.ok) {
          this.handleResponseError(response);
        }
        return response;
      })
      .catch((error) => {
        this.handleError(error);
      });
  }
}
