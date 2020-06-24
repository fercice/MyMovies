import http from "../helper/apiEndpoint";

class BaseService {
  getAll(endpoint) {
    return http.get(endpoint);
  }

  get(endpoint, id) {
    return http.get(`${endpoint}/${id}`);
  }

  create(endpoint, data) {
    return http.post(endpoint, data);
  }

  update(endpoint, id, data) {
    return http.put(`${endpoint}/${id}`, data);
  }

  delete(endpoint, id) {
    return http.delete(`${endpoint}/${id}`);
  }
}

export default new BaseService();
