import React, { useState } from 'react'
import { useDispatch } from 'react-redux'

import styles from '../../styles/Album.module.css'
import { addPhoto } from '../../features/photo/photoSlice';
import { useParams } from 'react-router-dom';

const Album = () => {
  const dispatch = useDispatch();
  const [file, setFile] = useState(null);
  const [userId, setUserId] = useState(''); // Set the userId
  const albumId = useParams().id;
  const handleFileChange = (e) => {
    setFile(e.target.files[0]);
  };


  const handleSubmit = (e) => {
    e.preventDefault();
    const formData = new FormData();
    formData.append('imageFile', file); // Append the file to the formData
    formData.append('userId', userId); // Append the user ID
    formData.append('albumId', albumId); // Append the album ID

    dispatch(addPhoto(formData)); // Dispatch the addPhoto action with the formData
  };


  return (
    <>
    <div className={styles.album}>Album</div>
    <div className={styles.album}>
      <h2>Upload Photo</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="image">Select Image:</label>
          <input type="file" id="image" accept="image/*" onChange={handleFileChange} />
        </div>
        <button style={{color:"red"}} type="submit">Upload</button>
      </form>
    </div>
    </>
  )
}

export default Album