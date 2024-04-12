import { configureStore } from "@reduxjs/toolkit";
import userSlice from "./user/userSlice";
import albumSlice from "./album/albumSlice";

export const store = configureStore({
    reducer: {
        // categories: categoriesSlice,
        user: userSlice,
        album: albumSlice,
        // subcategories: subcategoriesSlice,
        // products: productsSlice,
        // brands: brandsSlice
    },
    devTools: true
});