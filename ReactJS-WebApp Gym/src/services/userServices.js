class UserService {
  async registerUser(newUser) {
    let result = await fetch("http://localhost:4000/users", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newUser),
    });
    result = await result.json();
    //result = JSON.parse(localStorage.getItem("currentuser"));
    return result;
  }
}

export default UserService;
