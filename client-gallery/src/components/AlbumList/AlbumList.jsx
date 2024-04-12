import React, { useEffect, useState } from 'react';
import { NavLink } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { Audio } from 'react-loader-spinner';
import styles from "../../styles/AlbumList.module.css";
import { deleteAlbum, getAllAlbums } from '../../features/album/albumSlice';
import { jwtDecode } from 'jwt-decode';
import { FaTrash } from 'react-icons/fa';
import EditModal from '../AdditionalComponents/EditModal';

const AlbumList = () => {
  const { albums, isLoading } = useSelector((state) => state.album);
  const dispatch = useDispatch();

  const [currentUser, setCurrentUser] = useState(null);

  useEffect(() => {
    dispatch(getAllAlbums());
    const token = localStorage.getItem('token');
    if (token) {
      const user = jwtDecode(token).IdUser;
      setCurrentUser(user);
    }
  }, [dispatch]);


  const handleDeleteAlbum = (albumId, userId) => {
    if (currentUser !== userId) {
      alert('You do not have permission to delete this album.');
      return;
    }
    const confirmDelete = window.confirm('Are you sure you want to delete this album?');
    if (confirmDelete) {
      dispatch(deleteAlbum(albumId));
    }
  };


  return (
    <main>
      <div className={styles.album_list}>
        {isLoading ? (
          <Audio
            height={180}
            width={180}
            radius={9}
            color="orange"
            ariaLabel="loading"
          /> 
        ) : (
          <ul>
            {albums.map((album) => (
              <li key={album.id}>
                <div to={`/album/${album.id}`}>
                  <div className={styles.album_item}>
                    <h3>{album.name}</h3>
                    <p>{album.userId}</p> {/* You can display other album properties as needed */}
                    {currentUser === album.userId && (
                    <>
                      <EditModal album={album} />
                      <button className={styles.delete_button} onClick={() => handleDeleteAlbum(album.id, album.userId)}>
                      <FaTrash style={{color:"black"}} />
                      </button>
                      
                    </>
                  )}
                
                  </div>
                </div>
              </li>
            ))}
          </ul>
        )}
      </div>
    </main>
  );
};

export default AlbumList;