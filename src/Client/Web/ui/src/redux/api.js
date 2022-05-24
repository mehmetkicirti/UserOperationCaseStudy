import axios from "axios";

const API = axios.create({
    baseURL:"https://localhost:7221/api",
    headers:{
        "Content-Type": 'application/json;charset=UTF-8',
        "Access-Control-Allow-Origin": "*"
    }
});

const setUserData = (user) => {
    const formData = new FormData();
    formData.append("image", user.image);
    formData.append("name", user.name);
    formData.append("surname", user.surname);
    formData.append("birthDate", user.birthDate);
    if(user.id){
     formData.append("id", user.id);
    }
    return formData;
}

export const getAllUsers = () => API.get('/users');
export const getByIdUser = (id) => API.get(`/users/${id}`);
export const addUser = (user) => API.post(`/users`, setUserData(user), {
    headers:{
        "Content-Type":'multipart/form-data;'
    }
});
export const updateUser = (user) => API.put(`/users`, setUserData(user),{
    headers:{
        "Content-Type":'multipart/form-data;'
    }
});
export const deleteUser = (id) => API.delete(`/users/${id}`);