import axios from 'axios';

export default axios.create({
    baseURL: 'http://seafoodapi.azurewebsites.net/api'
});