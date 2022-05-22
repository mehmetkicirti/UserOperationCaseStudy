import { configureStore } from "@reduxjs/toolkit";
import UserReducer from "./features/user/userSlice"; 

export default configureStore({
    reducer:{
        user: UserReducer
    }
});