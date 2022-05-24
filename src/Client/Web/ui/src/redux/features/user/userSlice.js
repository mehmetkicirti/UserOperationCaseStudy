import { createSlice } from "@reduxjs/toolkit";
import {getUserById, getUsers, createUser, updateUser, deleteUser} from "./userActions";


const initialState = {
    appUsers: [],
    appUser: null,
    loading: false,
    error: ""
}


const userSlice = createSlice({
    name:"users",
    initialState,
    extraReducers: {
/* Get User By Id */
        [getUserById.pending]: (state, action) => {
            state.loading = true;
            state.error = "";
        },
        [getUserById.fulfilled]: (state, action) => {
            state.loading = false;
            state.appUser = action.payload.data; 
            state.error = "";
        },
        [getUserById.rejected]: (state, action) => {
            state.loading = false;
            state.error = action.payload.Message;
        },
/* Get All Users */
        [getUsers.pending]: (state, action) => {
            state.loading = true;
            state.error = "";
        },
        [getUsers.fulfilled]: (state, action) => {
            state.loading = false;
            state.appUsers = action.payload.data; 
            state.error = "";
        },
        [getUsers.rejected]: (state, action) => {
            state.loading = false;
            state.error = action.payload.Message;
        },
/* Add User */
        [createUser.pending]: (state, action) => {
            state.loading = true;
            state.error = "";
        },
        [createUser.fulfilled]: (state, action) => {
            state.loading = false;
            state.error = "";
        },
        [createUser.rejected]: (state, action) => {
            state.loading = false;
            state.error = action.payload.Message ?? action.error.message;
        },
/* Update User */
        [updateUser.pending]: (state, action) => {
            state.loading = true;
            state.error = "";
        },
        [updateUser.fulfilled]: (state, action) => {
            state.loading = false;
            state.error = "";
        },
        [updateUser.rejected]: (state, action) => {
            state.loading = false;
            state.error = action.payload.Message ?? action.error.message;
        },
/* Delete User */
        [deleteUser.pending]: (state, action) => {
            state.loading = true;
            state.error = "";
        },
        [deleteUser.fulfilled]: (state, action) => {
            state.loading = false;
            state.error = "";
        },
        [deleteUser.rejected]: (state, action) => {
            state.loading = false;
            state.error = action.payload.Message ?? action.error.message;
        },
    }
});


export default userSlice.reducer;