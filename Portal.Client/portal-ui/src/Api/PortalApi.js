import Api from './Api';

class PortalApi {
  getAllEmploye() {
    return Api.get('/Employee');
  }

  getEmployeById(id) {
    return Api.get('/Employee/' + id);
  }

  getEmployeContent(id) {
    return Api.get('/EmployeeContent/EmployeeContent/' + id);
  }

  postEmployeeContent(content){
    return Api.post('/EmployeeContent', content);
  }
}

export default new PortalApi();
