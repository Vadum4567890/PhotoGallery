import React, { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { Button, Box, Typography, Modal } from '@mui/material'; // Import necessary Material-UI components
import { editAlbum } from '../../features/album/albumSlice'; // Import editAlbum thunk
import { FaEdit } from 'react-icons/fa'; // Import FaEdit icon
import { jwtDecode } from 'jwt-decode';

const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
  };


const EditModal = ({ album }) => {
  const [open, setOpen] = useState(false); // State to control modal open/close
  const [albumName, setAlbumName] = useState(album.name); // State to store album name for editing
  const dispatch = useDispatch();
  const [currentUser, setCurrentUser] = useState(null);

  useEffect(() => {
    const token = localStorage.getItem('token');
    if (token) {
      const user = jwtDecode(token).IdUser;
      setCurrentUser(user);
    }
  }, [dispatch]);




  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  const handleEditAlbum = () => {
    const updatedAlbum = {
      ...album,
      name: albumName,
      // Add other properties to update if needed
    };
    dispatch(editAlbum({ albumId: album.id, updatedAlbum }));
    handleClose(); // Close the modal after editing album
  };

  return (
    <div>
      <Button onClick={handleOpen}>
        <FaEdit />
      </Button>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={ style }>
          <Typography variant="h6" component="h2" style={{color:"black"}}>
            Edit Album
          </Typography>
          <input
            type="text"
            value={albumName}
            onChange={(e) => setAlbumName(e.target.value)}
            placeholder="Album Name"
            style={{ color:"gray", width: '100%', marginTop: '10px', marginBottom: '10px' }}
          />
          <Button onClick={handleEditAlbum} variant="contained" color="primary">
            Save Changes
          </Button>
        </Box>
      </Modal>
    </div>
  );
};

export default EditModal;
