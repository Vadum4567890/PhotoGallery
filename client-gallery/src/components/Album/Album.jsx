import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'

import styles from '../../styles/Album.module.css'
import { addPhoto, clearPhotos, deletePhoto, getAllPhotos } from '../../features/photo/photoSlice';
import { useParams } from 'react-router-dom';
import { jwtDecode } from 'jwt-decode';
import { FaTrash } from 'react-icons/fa';
import { getAlbumById } from '../../features/album/albumSlice';

const Album = () => {
  const dispatch = useDispatch();
  const [file, setFile] = useState(null);
  const [userId, setUserId] = useState(''); // Set the userId
  const  { photos, isLoading }  = useSelector((state) => state.photo);
  const { album } = useSelector((state) => state.album);

  const albumId = useParams().id;
  const handleFileChange = (e) => {
    setFile(e.target.files[0]);
  };


  useEffect(() => {
    dispatch(getAllPhotos(albumId));
    dispatch(getAlbumById(albumId));
    const token = localStorage.getItem('token');
    if (token) {
      const user = jwtDecode(token).IdUser;
      setUserId(user);
    }
    return () => {
      dispatch(clearPhotos()); // Define a clearPhotos action in your photoSlice.js
    };
  }, [dispatch, albumId]);



  const handleSubmit = (e) => {
    e.preventDefault();
    const formData = new FormData();

    formData.append('userId', userId); // Append the user ID
    formData.append('albumId', albumId); // Append the album ID
    formData.append('imageFile', file); // Append the file to the formData

    dispatch(addPhoto(formData)); // Dispatch the addPhoto action with the formData
    alert('Photo added successfully, please update your page!');
  };


  const handleDeletePhoto = (photoId) => {
    if (window.confirm('Are you sure you want to delete this photo?')) {
      dispatch(deletePhoto(photoId));
    }
  };


  return (
    <>
  {isLoading ? (
    <div>Loading...</div>
  ) : (
    album && (
      <>
        <div className={styles.album_title}>Album: {album.name}</div>
        {album.userId === userId && (
          <div className={styles.album}>
            <h2>Upload Photo</h2>
            <form onSubmit={handleSubmit}>
              <div className={styles.fileInputContainer}>
                <label htmlFor="image" className={styles.fileInputLabel}>Select Image</label>
                <input type="file" id="image" accept="image/*" onChange={handleFileChange} className={styles.fileInput} />
              </div>
              <button className={styles.uploadButton} type="submit">Upload</button>
            </form>
          </div>
        )}
        <div className={styles.album}>
          <h2>Photos</h2>
          <div className={styles.photos}>
            {photos.map((photo) => (
              <div key={photo.id} className={styles.photo}>
                <img src={photo.imageSrc} alt={photo.caption} />
                <p>{photo.caption}</p>
                {album.userId === userId && (
                  <FaTrash className={styles.trashIcon} onClick={() => handleDeletePhoto(photo.id)} />
                )}
              </div>
            ))}
          </div>
        </div>
      </>
    )
  )}
</>

  )
}

export default Album