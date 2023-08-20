import axios from "axios";
import authHeader from "../commons/auth-header.common";

class BaseAPI {
  constructor(path) {
    this.base_url = "https://seafoodapi.azurewebsites.net/api/" + path;
    // const API_URL ="https://seafoodapi.azurewebsites.net/api"
  }

  getAll() {
    return axios.get(this.base_url, authHeader());
  }

  getById(slug, id) {
    return axios.get(this.base_url + slug + "?id=" + id, authHeader());
  }

  create(model) {
    return axios.post(this.base_url, model, authHeader());
  }

  update(id, model) {
    return axios.put(this.base_url + "?id=" + id, model, authHeader());
  }

  delete(id) {
    return axios.delete(this.base_url + "?id=" + id, authHeader());
  }
}

export default BaseAPI;
