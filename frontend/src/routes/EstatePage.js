import { useEffect, useState, useCallback } from 'react';
import { useLocation, useNavigate, useParams } from 'react-router-dom';
import { GoogleMap, useJsApiLoader } from '@react-google-maps/api';
import Header from '../components/Header';
import { MarkerF } from '@react-google-maps/api';
import Table from 'react-bootstrap/Table';
import ThreeDRotationIcon from '@mui/icons-material/ThreeDRotation';
import { Button, Icon, IconButton } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import { useAuth } from '../utils/Auth';
import DeleteIcon from '@mui/icons-material/Delete';
const containerStyle = {
  width: '100%',
  height: '200px',
  margin: "0 auto"
};


function EstatePage() {
  const { id } = useParams();// estate ID
  const {state} = useLocation();
  const { profile } = useAuth();
  console.log(state);
  const {coordX, coordY, title, price, owner_id, m2,
    balconyCount, bathroomCount, location_il, vr_id,room_type,buildingFees,
    isFurnished,
    floors,
    buildingAge} =state.estate;
  console.log(title);
  const { isLoaded } = useJsApiLoader({
    id: 'google-map-script',
    googleMapsApiKey: "AIzaSyCcwb_SbKqbxXJWktAikadVeCNlKSt9iAQ"
  })
  const navigate = useNavigate();
  const [map, setMap] = useState(null)
  const [isUserOwner, setIsUserOwner] = useState(profile.id===owner_id)
  console.log(profile);
  const onLoad = useCallback(function callback(map) {
    // const bounds = new window.google.maps.LatLngBounds({lat:parseFloat(coordinatesX) , lng:parseFloat(coordinatesY)});
    // map.fitBounds(bounds);

    map.panTo({lat:parseFloat(coordX) , lng:parseFloat(coordY)});

  }, [])

  const onUnmount = useCallback(function callback(map) {
    setMap(null)
  }, []);

  const deleteEstate = async (e)=>{
    const data={
      id:id,
      ownerId:owner_id
    }
    const response = await fetch('http://localhost:5002/estate/delete?id='+id+'&ownerId='+owner_id, {
      method: "POST", // *GET, POST, PUT, DELETE, etc.
      cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
      credentials: "same-origin", // include, *same-origin, omit
      headers: {
        "Content-Type": "application/json",
      },
      referrerPolicy: "no-referrer", // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
      // body: JSON.stringify(data), // body data type must match "Content-Type" header
    });
   navigate("/");//can be looked!
  }
  return(<>
    <Header />
    {
      isLoaded ? 
      <GoogleMap
        mapContainerStyle={containerStyle}
        center={{lat:parseFloat(coordX) , lng:parseFloat(coordY)}}
        zoom={11.9}
        onLoad={onLoad}
        onUnmount={onUnmount}
      >
        <MarkerF position={{lat:parseFloat(coordX) , lng:parseFloat(coordY)}}></MarkerF>
      </GoogleMap> : <></>
    }
    <div style={{display:"flex",margin:"0 auto", flexDirection:"column",maxWidth:"800px", justifyContent:"center", alignItems:"center",}}>
    <div style={{display:"flex", flexDirection:"row",justifyContent:"center",alignItems:"center", marginTop:"1rem", gap:"1rem"}}>
    <h1>{title}</h1> {
      isUserOwner && <IconButton style={{textAlign:"center"}} onClick={deleteEstate} variant="contained" color="error"><DeleteIcon sx={{fill:"#CA1929"}} /></IconButton>
    }
    {/* <div style={{fontSize:"20px", color:"#5a79c8"}}>${price} </div> */}
      
    </div>
    <Table striped bordered hover>
     
      <tbody>
        {
          location_il &&
            <tr>
              <td>City</td>
              <td>{location_il.charAt(0).toUpperCase()+location_il.slice(1)}</td>
            </tr>
        }
        <tr>
          <td>Size (m²)</td>
          <td className='tdEdit'>{m2} {isUserOwner && <IconButton size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>}</td>
        </tr>
        <tr>
          <td>Number of Balconies</td>
          <td className='tdEdit'>{balconyCount}
          {isUserOwner && <IconButton size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>}</td>
        </tr>
        <tr>
          <td>Number of Bathrooms</td>
          <td className='tdEdit'>{bathroomCount} 
          {isUserOwner && <IconButton size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>} </td>
        </tr>
        <tr>
          <td>Room Type</td>
          <td className='tdEdit'>{room_type} 
          {isUserOwner && <IconButton size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>} </td>
        </tr>
        <tr>
          <td>Building Fees</td>
          <td className='tdEdit'>{buildingFees} 
          {isUserOwner && <IconButton size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>} </td>
        </tr>
        <tr>
          <td>Furnished</td>
          <td className='tdEdit'>{isFurnished} 
          {isUserOwner && <IconButton size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>} </td>
        </tr>
        <tr>
          <td>Floor</td>
          <td className='tdEdit'>{floors} 
          {isUserOwner && <IconButton size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>} </td>
        </tr>
        <tr>
          <td>Building Age</td>
          <td className='tdEdit'>{buildingAge} 
          {isUserOwner && <IconButton size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>} </td>
        </tr>
      
      </tbody>
    </Table>

    {
      vr_id && <Button style={{textAlign:"center"}} variant="contained">Display in VR <ThreeDRotationIcon style={{fill:"white", marginLeft:"8px"}}/></Button>
    }
     
   
    </div>
    
    </>
  );
    
}

export default EstatePage;