export default class QueryService {
  async getQuerys() {
    return fetch("http://localhost:4000/enquiries")
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
  async addQuery(newQuery) {
    return fetch("http://localhost:4000/enquiries", {
      method: "POST",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newQuery),
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
  async updateQuerys(updateQuery) {
    return fetch("http://localhost:4000/enquiries/" + updateQuery.id, {
      method: "PUT",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(updateQuery),
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
  handleResponseError(response) {
    throw new Error("HTTP error, status = " + response.status);
  }
  handleError(error) {
    console.log(error.message);
  }
}
