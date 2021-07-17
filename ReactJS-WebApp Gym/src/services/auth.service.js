import { history } from "../App";

export default class AuthService {
  logout() {
    localStorage.removeItem("currentuser");
    history.replace("/home");
    window.location.reload();
  }

  login(email, password) {
    let item = { email, password };
    return this.performAuthentication(item);
    // this.App = new App();
    // this.App.performAuthentication(item);
  }

  async performAuthentication(item) {
    let result = await fetch("http://localhost:4000/users", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
      //body: JSON.stringify(item),
    });
    result = await result.json();
    //let present = false;
    const loginAuth = !!result.find((result) => {
      return result.email === item.email && result.password === item.password;
    });
    if (loginAuth === true) {
      const logedUser = result.filter(
        (us) =>
          us.email.includes(item.email) && us.password.includes(item.password)
      );
      localStorage.setItem("currentuser", JSON.stringify(logedUser));

      result = JSON.parse(localStorage.getItem("currentuser"));
      console.log(" Auth Called ", result);
      if (result != null && result[0].role === "admin") {
        history.replace("/addProgram");
      }
      if (result != null && result[0].role === "marketing") {
        history.replace("/allQueries");
      }
      if (result != null && result[0].role === "user") {
        history.replace("/allPrograms");
      }
      window.location.reload();
    } else {
      history.replace("/home");
    }
    return loginAuth;
  }
}
