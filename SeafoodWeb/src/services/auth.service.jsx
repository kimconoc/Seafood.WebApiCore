import axios from "axios";
import Cookies from "universal-cookie";
import BaseAPI from "../api/BaseApi";
// const API_URL ="http://localhost:5678/api";
// const API_URL ="https://seafoodapi.azurewebsites.net/api"

class UserApi extends BaseAPI {
  cookies = new Cookies();
  async signIn(username, password) {
    return axios
      .post(this.base_url + "user/signIn", { username, password })
      .then((res) => {
        // this.cookies.set("token", res.data.token);
        if (res.data.token) {
          localStorage.setItem(
            "user",
            JSON.stringify({
              token: res.data.token,
              role: res.data.response.roles,
            })
          );
          axios.defaults.headers.common[
            "Authorization"
          ] = `Bearer ${res.data.token}`;
        }
      });
  }
  async signup(signUpModel) {
    return axios.post(this.base_url + "user/signup", signUpModel);
  }
}
function logout() {
  localStorage.removeItem("user");
}

const getCurrentUser = () => {
  return JSON.parse(localStorage.getItem("user"));
};
const userAPI = new UserApi("");
const authService = {
  userAPI,
  logout,
  getCurrentUser,
};

export default authService;
