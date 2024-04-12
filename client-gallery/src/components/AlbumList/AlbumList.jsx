import React, { useEffect } from 'react';
import { NavLink } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
// import { getCategories } from '../../features/categories/categoriesSlice';
import { Audio } from 'react-loader-spinner';
import styles from "../../styles/AlbumList.module.css";
import { getAllAlbums } from '../../features/album/albumSlice';

const AlbumList = () => {
  const { albums, isLoading } = useSelector((state) => state.album);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getAllAlbums());
    
  }, [dispatch]);

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
                <NavLink to={`/album/${album.id}`}>
                  <div className={styles.album_item}>
                    <h3>{album.name}</h3>
                    <p>{album.userId}</p> {/* You can display other album properties as needed */}
                  </div>
                </NavLink>
              </li>
            ))}
          </ul>
        )}
      </div>
    </main>
  );
};

export default AlbumList;