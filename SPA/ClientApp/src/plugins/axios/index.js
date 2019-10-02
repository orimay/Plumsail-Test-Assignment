import axios from "axios";

axios.defaults.baseURL = "https://localhost:5001/api/";
axios.defaults.headers.common["Accept"] = "application/json";
axios.defaults.headers.common["Content-Type"] = "application/json";
axios.defaults.headers.common["Access-Control-Allow-Origin"] = "*";

axios.interceptors.response.use(
  response => {
    return {
      isSuccess: true,
      data: response.data
    };
  },
  error => {
    console.error(error);
    return {
      isSuccess: false,
      message: error.message,
      data: error
    };
  }
);

export default {};
