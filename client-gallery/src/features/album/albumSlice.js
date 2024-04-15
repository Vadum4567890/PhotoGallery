import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios from "axios";
import { USER_URL } from "../../utils/constants";

export const getAllAlbums = createAsyncThunk(
    "albums/getAllAlbums",
    async(_, thunkApi) => {
        try {
            const res = await axios.get(`${USER_URL}/Albums`);
            console.log(res);
            return res.data;
            
        } catch(err) {
            console.log(err);
            return thunkApi.rejectWithValue(err);
        }
    }
)

export const getAlbumById = createAsyncThunk(
    "albums/getAlbumById",
    async(albumId, thunkApi) => {
      try {
        const res = await axios.get(`${USER_URL}/Albums/${albumId}`);
        console.log(res);
        return res.data;
    }
    catch (err) {
    console.error(err);  // Log the full error for debugging purposes

    // Return a serializable error object
    return thunkApi.rejectWithValue({
        message: err.message,
        name: err.name,
        code: err.code,
    });
    }
    }
);



export const createAlbum = createAsyncThunk(
    "albums/createAlbum",
    async (payload, thunkAPI) => {
        try {
            const token = localStorage.getItem("token");
            // Set up request headers with the JWT token
            const config = {
                headers: {
                    "Authorization": `Bearer ${token}`
                }
            };

            const res = await axios.post(`${USER_URL}/Albums`, payload, config);
            console.log(res);
            return res.data;
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


export const editAlbum = createAsyncThunk(
    "albums/editAlbum",
    async ({ albumId, updatedAlbum }, thunkAPI) => {
      try {
        const token = localStorage.getItem("token");
        const config = {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        };
  
        const res = await axios.put(`${USER_URL}/Albums/${albumId}`, updatedAlbum, config);
        console.log(res);
        return res.data; // Assuming the response contains the updated album data
      } catch (err) {
        console.error(err);
        return thunkAPI.rejectWithValue(err.response.data); // Return error message on failure
      }
    }
  );
  

export const deleteAlbum = createAsyncThunk(
    "albums/deleteAlbum",
    async (albumId, thunkAPI) => {
      try {
        const token = localStorage.getItem("token");
        const config = {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        };
  
        // Send a DELETE request to delete the album by ID
        await axios.delete(`${USER_URL}/Albums/${albumId}`, config);
        return albumId; // Return the deleted album ID on success
      } catch (err) {
        console.error(err);
        return thunkAPI.rejectWithValue(err.response.data); // Return error message on failure
      }
    }
  );
  


const albumSlice = createSlice({
    name: "album",
    initialState: {
        albums: [],
        isLoading: false,
        album: null, 
    },
    reducers: {
        // Your reducer functions here if needed
    },
    extraReducers: (builder) => {
          builder.addCase(getAllAlbums.pending, (state) => {
              state.isLoading = true;
          });
           builder.addCase(getAllAlbums.fulfilled, (state, {payload}) => {
              state.albums = payload;
              state.isLoading = false;
          })
          builder.addCase(getAllAlbums.rejected, (state) => {
              state.isLoading = false;
          });
          builder.addCase(deleteAlbum.pending, (state) => {
            state.isLoading = true;
          });

          builder.addCase(deleteAlbum.fulfilled, (state, { payload: deletedAlbumId }) => {
            // Remove the deleted album from state
            state.albums = state.albums.filter((album) => album.id !== deletedAlbumId);
            state.isLoading = false;
          });
          builder.addCase(deleteAlbum.rejected, (state) => {
            state.isLoading = false;
          });

          builder.addCase(getAlbumById.fulfilled, (state, { payload }) => {
            // Handle the fulfilled action for getAlbumById if needed
            state.isLoading = false;
            state.album = payload;
          })
          builder.addCase(getAlbumById.rejected, (state) => {
            state.isLoading = false;
          });

    }
});

  export const { clearPhotos } = albumSlice.actions;
  export default albumSlice.reducer;
  
  