import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { USER_URL } from "../../utils/constants";

export const getAllPhotos = createAsyncThunk(
    "photos/getAllPhotos",
    async(_, thunkApi) => {
        try {
            const res = await axios.get(`${USER_URL}/Photos`);
            console.log(res);
            return res.data;
            
        } catch(err) {
            console.log(err);
            return thunkApi.rejectWithValue(err);
        }
    }
)


export const addPhoto = createAsyncThunk(
    "photos/addPhoto",
    async (payload, thunkAPI) => {
        try {
            const token = localStorage.getItem("token");
            // Set up request headers with the JWT token
            const config = {
                headers: {
                    "Authorization": `Bearer ${token}`
                }
            };

            const res = await axios.post(`${USER_URL}/Photos`, payload, config);
            console.log(res);
        }
        catch (err) {
        console.error(err);  // Log the full error for debugging purposes

        // Return a serializable error object
        return thunkAPI.rejectWithValue({
            message: err.message,
            name: err.name,
            code: err.code,
            // Add other properties as needed
        });
        }
    }   
)


export const editPhoto = createAsyncThunk(
    "photos/editPhoto",
    async ({ photoId, updatedPhoto }, thunkAPI) => {
      try {
        const token = localStorage.getItem("token");
        const config = {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        };
  
        const res = await axios.put(`${USER_URL}/Photos/${photoId}`, updatedPhoto, config);
        console.log(res);
        return res.data; // Assuming the response contains the updated album data
      } catch (err) {
        console.error(err);
        return thunkAPI.rejectWithValue(err.response.data); // Return error message on failure
      }
    }
  );
  

export const deletePhoto = createAsyncThunk(
    "photos/deletePhoto",
    async (photoId, thunkAPI) => {
      try {
        const token = localStorage.getItem("token");
        const config = {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        };
  
        // Send a DELETE request to delete the album by ID
        await axios.delete(`${USER_URL}/Photos/${photoId}`, config);
        return photoId; // Return the deleted album ID on success
      } catch (err) {
        console.error(err);
        return thunkAPI.rejectWithValue(err.response.data); // Return error message on failure
      }
    }
  );
  


const photoSlice = createSlice({
    name: "photo",
    initialState: {
        photos: [],
        isLoading: false, 
    },
    reducers: {
        // Your reducer functions here if needed
    },
    extraReducers: (builder) => {
        builder.addCase(getAllPhotos.pending, (state) => {
            state.isLoading = true;
        });
        builder.addCase(getAllPhotos.fulfilled, (state, {payload}) => {
            state.photos = payload;
            state.isLoading = false;
        })
        builder.addCase(getAllPhotos.rejected, (state) => {
            state.isLoading = false;
        });
        builder.addCase(deletePhoto.pending, (state) => {
            state.isLoading = true;
          });
          builder.addCase(deletePhoto.fulfilled, (state, { payload: deletedPhotoId }) => {
            // Remove the deleted album from state
            state.photos = state.photos.filter((photo) => photo.id !== deletedPhotoId);
            state.isLoading = false;
          });
          builder.addCase(deletePhoto.rejected, (state) => {
            state.isLoading = false;
          });
    }
});

  export const {  } = photoSlice.actions;
  export default photoSlice.reducer;
  
  