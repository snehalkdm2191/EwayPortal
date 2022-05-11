import axios from 'axios';

const BASE_URL = 'https://localhost:5001/api';

const Api = axios.create({
  baseURL: BASE_URL
});

// Exporting Api into the global namespace for introspecting
//window.Api = Api;

export default Api;
