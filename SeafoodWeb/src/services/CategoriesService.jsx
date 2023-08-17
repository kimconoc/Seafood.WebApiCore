import axios from "axios"

const fetchAllCategory = ()=>{
    return axios.get("http://localhost:5678/api/Category/getList");
}

export {fetchAllCategory};