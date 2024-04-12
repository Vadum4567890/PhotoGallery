import { configureStore } from "@reduxjs/toolkit";
import userSlice from "./user/userSlice";
import albumSlice from "./album/albumSlice";
import photoSlice from "./photo/photoSlice";

export const store = configureStore({
    reducer: {
        photo: photoSlice,
        user: userSlice,
        album: albumSlice,
    },
    devTools: true
});