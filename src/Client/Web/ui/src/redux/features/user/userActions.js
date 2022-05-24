import { createAsyncThunk } from "@reduxjs/toolkit";
import { createBrowserHistory } from "history";
import * as api from "../../api";
const history = createBrowserHistory();
export const getUserById = createAsyncThunk("users/getUserById", async ({id}, {rejectWithValue}) => {
    try {
        const response = await api.getByIdUser(id);
        return response.data;
    } catch (error) {
        return rejectWithValue(getErrorMessage(error));
    }
});

export const getUsers = createAsyncThunk("users/getUsers", async ({},{rejectWithValue}) => {
    try {
        const response = await api.getAllUsers();
        return response.data;
    } catch (error) {
        return rejectWithValue(getErrorMessage(error));
    }
});

export const createUser = createAsyncThunk("users/createUser", async ({formData, toast, setOpen},{rejectWithValue}) => {
    try {
        const response = await api.addUser(formData);
        toast.success(response.data.message);
        setOpen(false);
        toNavigate();
    } catch (error) {
        setOpen(true);
        return rejectWithValue(getErrorMessage(error));
    }
});

export const updateUser = createAsyncThunk("users/updateUser", async ({formData, toast},{rejectWithValue}) => {
    try {
        const response = await api.updateUser(formData);
        toast.success(response.data.message);
    } catch (error) {
        return rejectWithValue(getErrorMessage(error));
    }
});

export const deleteUser = createAsyncThunk("users/deleteUser", async ({id, toast},{rejectWithValue}) => {
    try {
        const response = await api.deleteUser(id);
        toast.success(response.data.message);
        toNavigate();
    } catch (error) {
        return rejectWithValue(getErrorMessage(error));
    }
});

const toNavigate = () => {
    setTimeout(()=>{
        history.push("/");
        history.go();
      },500);
}

const getErrorMessage = (error) => error.response.data ?? error.message; 