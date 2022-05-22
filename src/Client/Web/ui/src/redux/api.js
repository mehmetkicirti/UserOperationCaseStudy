const { axios } = require("axios");

const API = axios.create({
    baseURL:"https://localhost:44316/api",
    headers:{
        "Content-Type": 'application/json;charset=UTF-8',
        "Access-Control-Allow-Origin": "*"
    }
});

export const getAllUsers = () => API.get('/users');
export const getByIdUser = (id) => API.get(`/users/${id}`);
export const addUser = (user) => API.post(`/users`, user);
export const updateUser = (user) => API.put(`/users`, user);
export const deleteUser = (id) => API.delete(`/users/${id}`);