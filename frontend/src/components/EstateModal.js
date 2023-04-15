import * as React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';
import Image from 'react-bootstrap/Image'  
const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    borderRadius:'10px',
    boxShadow: 24,
    p: 4,
  };

export default function EstateModal({open, handleOpen, handleClose, estate,onGoEstate}){

 
  return (
    <div>
      
      <Modal
        open={open===estate.id}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <Typography id="modal-modal-title" variant="h6" component="h2">
            {"Title: "+estate.title}
          </Typography>
          {
                estate.price && <span>${estate.price}  <br/></span>
            }
          {
            estate.image?
                <Image style={{ maxHeight:"120px", maxWidth:"120px"}} src={estate.image} rounded={true}/>
                :<></>          }
          <Typography id="modal-modal-description" sx={{ mt: 2 }}>
            {
                estate.location_il && <span>{estate.location_il}  <br/></span>
            }
            {
                estate.location_ilce && <span>{estate.location_ilce}  <br/></span>
            }
            {
                estate.room_type && <span>{estate.room_type}  <br/></span>
            }
            {
                estate.m2 && <span>{estate.m2+"m²"} <br/></span>
            }

           
          </Typography>
          <Button onClick={onGoEstate}> Go Estate Page</Button>
        </Box>
      </Modal>
    </div>
  );
}