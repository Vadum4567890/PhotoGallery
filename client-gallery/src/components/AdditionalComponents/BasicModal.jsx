import * as React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';
import { jwtDecode } from 'jwt-decode';
import { useDispatch } from 'react-redux';
import { createAlbum } from '../../features/album/albumSlice';

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

export default function BasicModal() {
  const [open, setOpen] = React.useState(false);
  const [albumName, setAlbumName] = React.useState(''); // State to store album name
  
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false); 
  const dispatch = useDispatch();

  const handleCreateAlbum = () => {
    try {
      const token = localStorage.getItem('token');
      const userId = jwtDecode(token);
      const payload = {
        name: albumName, // Use the albumName state variable
        userId: userId.IdUser,
        photoIds: [],
      };
      dispatch(createAlbum(payload));
      handleClose(); // Close the modal after creating album
    } catch (error) {
      console.error('Error creating album:', error);
    }
  };



  return (
    <div>
    <Button style={{color:"black"}} onClick={handleOpen}>Create Album</Button>
    <Modal
      open={open}
      onClose={handleClose}
      aria-labelledby="modal-modal-title"
      aria-describedby="modal-modal-description"
    >
      <Box sx={style}>
        <Typography id="modal-modal-title" variant="h6" component="h2" style={{color:"black"}}>
          Create Album
        </Typography>
        <input
          type="text"
          value={albumName}
          onChange={(e) => setAlbumName(e.target.value)}
          placeholder="Album Name"
          style={{ color:"gray", width: '100%', marginTop: '10px', marginBottom: '10px' }}
        />
        <Button style={{ color:"white", width: '100%', marginTop: '10px', marginBottom: '10px' }}  onClick={handleCreateAlbum} variant="contained" color="primary">
          Create
        </Button>
      </Box>
    </Modal>
  </div>
  );
}