import { useEffect, useState, useCallback } from 'react';
import { useLocation, useNavigate, useParams } from 'react-router-dom';
import { GoogleMap, useJsApiLoader } from '@react-google-maps/api';
import Header from '../components/Header';
import { MarkerF } from '@react-google-maps/api';
import Table from 'react-bootstrap/Table';
import ThreeDRotationIcon from '@mui/icons-material/ThreeDRotation';
import {  Button, Icon, IconButton, Input } from '@mui/material';
import Alert from 'react-bootstrap/Alert';
import EditIcon from '@mui/icons-material/Edit';
import { useAuth } from '../utils/Auth';
import DeleteIcon from '@mui/icons-material/Delete';
import DoneIcon from '@mui/icons-material/Done';
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';

const containerStyle = {
  width: '100%',
  height: '200px',
  margin: "0 auto"
};


function EstatePage() {
  const {state} = useLocation();
  const {location_il, owner_id, vr_id} = state.estate;
  const [coordX, setCoordX] = useState(state.estate.coordX);
  const [coordY, setCoordY] = useState(state.estate.coordY);
  const [title, setTitle] = useState(state.estate.title);
  const [price, setPrice] = useState(state.estate.price);
  const [room_type, setRoom_type] = useState(state.estate.room_type);
  const [m2, setM2] = useState(state.estate.m2);
  const [bathroomCount, setBathroomCount] = useState(state.estate.bathroomCount);
  const [floors, setFloors] = useState(state.estate.floors);
  const [isFurnished, setIsFurnished] = useState(state.estate.isFurnished);
  const [buildingAge, setBuildingAge] = useState(state.estate.buildingAge);
  const [balconyCount, setBalconyCount] = useState(state.estate.balconyCount);
  const [buildingFees, setBuildingFees] = useState(state.estate.buildingFees);
  const [isError, setIsError] = useState(false);

  const [m2Edit, setM2Edit] = useState(false);
  const [balconyCountEdit, setBalconyCountEdit] = useState(false);
  const [buildingFeesEdit, setBuildingFeesEdit] = useState(false);
  const [buildingAgeEdit, setBuildingAgeEdit] = useState(false);
  const [isFurnishedEdit, setIsFurnishedEdit] = useState(false);
  const [floorsEdit, setFloorsEdit] = useState(false);
  const [bathroomCountEdit, setBathroomCountEdit] = useState(false);
  const [room_typeEdit, setRoom_typeEdit] = useState(false);
  const [priceEdit, setPriceEdit] = useState(false);
  const [titleEdit, setTitleEdit] = useState(false);
  // const [image, setImage] = useState(null);

  const { id } = useParams();// estate ID
  const { profile } = useAuth();
  const handleEdit = (buttonType) =>{
    if(buttonType === "m2"){
      setM2Edit(true);
    }
    else if(buttonType === "bathroomCount"){
      setBathroomCountEdit(true);
    }
    else if(buttonType === "title"){
      setTitleEdit(true);
    }
    else if(buttonType === "price"){
      setPriceEdit(true);
    }
    else if(buttonType === "room_type"){
      setRoom_typeEdit(true);
    }
    else if(buttonType === "floors"){
      setFloorsEdit(true);
    }
    else if(buttonType === "isFurnished"){
      setIsFurnishedEdit(true);
    }
    else if(buttonType === "buildingAge"){
      setBuildingAgeEdit(true);
    }
    else if(buttonType === "balconyCount"){
      setBalconyCountEdit(true);
    }
    else if(buttonType === "buildingFees"){
      setBuildingFeesEdit(true);
    }
  }
  const handleChange = (e, buttonType) =>{
    const val= e.target.value;
    if(buttonType === "m2"){
      setM2(val);
    }
    else if(buttonType === "bathroomCount"){
      setBathroomCount(val);
    }
    else if(buttonType === "title"){
      setTitle(val);
    }
    else if(buttonType === "price"){
      setPrice(val);
    }
    else if(buttonType === "room_type"){
      setRoom_type(val);
    }
    else if(buttonType === "floors"){
      setFloors(val);
    }
    else if(buttonType === "isFurnished"){
      setIsFurnished(val);
    }
    else if(buttonType === "buildingAge"){
      setBuildingAge(val);
    }
    else if(buttonType === "balconyCount"){
      setBalconyCount(val);
    }
    else if(buttonType === "buildingFees"){
      setBuildingFees(val);
    }
  }
  const handleSave = async (buttonType)=>{
    if(!title || !price || !m2|| !coordX || !coordY  || !buildingAge  || !buildingFees){
      setIsError(true);
    }
    else{
      // let val="";
      // let type="";
      // if(buttonType === "m2"){
      //   setM2Edit(false);
      //   val=m2;
      //   type="m2";
      // }
      // else if(buttonType === "bathroomCount"){
      //   setBathroomCountEdit(false);
      //   val=bathroomCount;
      //   type="bathroomCount";
      // }
      // else if(buttonType === "title"){
      //   setTitleEdit(false);
      //   val=title;
      //   type="title";
      // }
      // else if(buttonType === "price"){
      //   setPriceEdit(false);
      //   val=price;
      //   type="price";
      // }
      // else if(buttonType === "room_type"){
      //   setRoom_typeEdit(false);
      //   val=room_type;
      //   type="room_type";
      // }
      // else if(buttonType === "floors"){
      //   setFloorsEdit(false);
      //   val=floors;
      //   type="floors";
      // }
      // else if(buttonType === "isFurnished"){
      //   setIsFurnishedEdit(false);
      //   val=isFurnished;
      //   type=m2;
      // }
      // else if(buttonType === "buildingAge"){
      //   setBuildingAgeEdit(false);
      //   val=buildingAge;
      //   type="buildingAge";
      // }
      // else if(buttonType === "balconyCount"){
      //   setBalconyCountEdit(false);
      //   val=balconyCount;
      //   type="balconyCount";
      // }
      // else if(buttonType === "buildingFees"){
      //   setBuildingFeesEdit(false);
      //   val=buildingFees;
      //   type="buildingFees";
      // }
      const data={
        title,
        price,
        il: location_il,
        coordX,
        coordY,
        room_type,
        m2,
        vr_id,
        id,
        owner_id,
        buildingAge,
        floors,
        balconyCount,
        bathroomCount,
        isFurnished,
        buildingFees,

      }
      const response = await fetch('http://localhost:5002/estate/update?id='+id+'&ownerId='+owner_id, {
        method: "POST", // *GET, POST, PUT, DELETE, etc.
        cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
        credentials: "same-origin", // include, *same-origin, omit
        headers: {
          "Content-Type": "application/json",
        },
        referrerPolicy: "no-referrer", // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        body: JSON.stringify(data), // body data type must match "Content-Type" header
      });
      const data_response = await response.json();
      console.log(data_response);
      setIsError(false);
    }

  }
  console.log(state);
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
    
    {
            titleEdit ?  
            <div >
               <Input onChange={(e)=>{handleChange(e,"title")}} value={title} />            
           {isUserOwner && <IconButton onClick={()=>{handleSave("title")}} size="small"><DoneIcon style={{fill:"green"}} /></IconButton>}
            </div>: 
            <td className='tdEdit'><h1>{title}</h1>{isUserOwner && <IconButton onClick={()=>{handleEdit("title")}} size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>}</td>

          }    {
      isUserOwner && <IconButton style={{textAlign:"center"}} onClick={deleteEstate} variant="contained" color="error"><DeleteIcon sx={{fill:"#CA1929"}} /></IconButton>
    }
     
    {/* <div style={{fontSize:"20px", color:"#5a79c8"}}>${price} </div> */}
      
    </div>
    {
      isError && 
        <Alert style={{marginTop:"1rem", textAlign:"center" }} variant="danger">Please Fill All Areas and Select from Map!
        </Alert>
     }
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
          {
            m2Edit ?  
            <td className='tdEdit'>
              <Input onChange={(e)=>{handleChange(e,"m2")}} value={m2} />
              {isUserOwner && <IconButton onClick={()=>{handleSave("m2")}} size="small"><DoneIcon style={{fill:"green"}} /></IconButton>}
            </td>: 
            <td className='tdEdit'>{m2} {isUserOwner && <IconButton onClick={()=>{handleEdit("m2")}} size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>}</td>

          }
          </tr>
        <tr>
          <td>Number of Balconies</td>
          {
            balconyCountEdit ?  
            <td className='tdEdit'>
            <Form.Group className="mb-6" size="md">
            <Form.Select value={balconyCount} onChange={(e)=>handleChange(e,"balconyCount")} aria-label="Default select example">
              <option value="0">0</option>
              <option value="1">1</option>
              <option value="2">2</option>
              <option value="3">3</option>
              <option value="4">4</option>
              <option value="5">5</option>
              <option value="6">6</option>
            </Form.Select>
          </Form.Group>
            
              {isUserOwner && <IconButton onClick={()=>{handleSave("balconyCount")}} size="small"><DoneIcon style={{fill:"green"}} /></IconButton>}
            </td>: 
            <td className='tdEdit'>{balconyCount} {isUserOwner && <IconButton onClick={()=>{handleEdit("balconyCount")}} size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>}</td>

          }
          </tr>
        <tr>
          <td>Number of Bathrooms</td>
          {
            bathroomCountEdit ?  
            <td className='tdEdit'>
               <Form.Group className="mb-6" size="md">
            <Form.Select value={bathroomCount} onChange={(e)=>handleChange(e,"bathroomCount")} aria-label="Default select example">
              <option value="0">0</option>
              <option value="1">1</option>
              <option value="2">2</option>
              <option value="3">3</option>
              <option value="4">4</option>
              <option value="5">5</option>
              <option value="6">6</option>
            </Form.Select>
          </Form.Group>  {isUserOwner && <IconButton onClick={()=>{handleSave("bathroomCount")}} size="small"><DoneIcon style={{fill:"green"}} /></IconButton>}
            </td>: 
            <td className='tdEdit'>{bathroomCount} {isUserOwner && <IconButton onClick={()=>{handleEdit("bathroomCount")}} size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>}</td>

          }
          </tr>
        <tr>
          <td>Room Type</td>
          {
            room_typeEdit ?  
            <td className='tdEdit'>
                  <Form.Group className="mb-6" size="md">
            <Form.Select value={room_type} onChange={(e)=>handleChange(e,"room_type")} aria-label="Default select example">
            <option value="1+0">1+0</option>
              <option value="1+1">1+1</option>
              <option value="2+0">2+0</option>
              <option value="2+1">2+1</option>
              <option value="3+0">3+0</option>
              <option value="3+1">3+1</option>
              <option value="3+2">3+2</option>
              <option value="4+0">4+0</option>
              <option value="4+1">4+1</option>
              <option value="4+2">4+2</option>
              <option value="4+3">4+3</option>
            </Form.Select>
          </Form.Group>  {isUserOwner && <IconButton onClick={()=>{handleSave("room_type")}} size="small"><DoneIcon style={{fill:"green"}} /></IconButton>}
            </td>: 
            <td className='tdEdit'>{room_type} {isUserOwner && <IconButton onClick={()=>{handleEdit("room_type")}} size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>}</td>

          }        
        </tr>
        <tr>
          <td>Building Fees</td>
          {
            buildingFeesEdit ?  
            <td className='tdEdit'>
            <InputGroup className="mb-6" style={{width:"75%"}}>
            <InputGroup.Text>$</InputGroup.Text>
            <Form.Control value={buildingFees} onChange={(e)=>handleChange(e,"buildingFees")} aria-label="Amount (to the nearest dollar)" />
            <InputGroup.Text>Per Month</InputGroup.Text>
            </InputGroup>    
            {isUserOwner && <IconButton onClick={()=>{handleSave("buildingFees")}} size="small"><DoneIcon style={{fill:"green"}} /></IconButton>}
            </td>: 
            <td className='tdEdit'>{buildingFees} {isUserOwner && <IconButton onClick={()=>{handleEdit("buildingFees")}} size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>}</td>

          }
        </tr>
        <tr>
          <td>Furnished</td>
          {
            isFurnishedEdit ?  
            <td className='tdEdit'>
               <Form.Group className="mb-6" size="md">
            <Form.Select value={isFurnished} onChange={(e)=>handleChange(e,"isFurnished")} aria-label="Default select example">
            <option value="0">No</option>
            <option value="1">Yes</option>
            </Form.Select>
          </Form.Group>              
           {isUserOwner && <IconButton onClick={()=>{handleSave("isFurnished")}} size="small"><DoneIcon style={{fill:"green"}} /></IconButton>}
            </td>: 
            <td className='tdEdit'>{isFurnished?"Yes":"No"} {isUserOwner && <IconButton onClick={()=>{handleEdit("isFurnished")}} size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>}</td>

          }        
          </tr>
        <tr>
          <td>Floor</td>
          {
            floorsEdit ?  
            <td className='tdEdit'>
               <Form.Group className="mb-6" size="md">
            <Form.Select value={floors} onChange={(e)=>handleChange(e,"floors")} aria-label="Default select example">
            <option value="0">Ground Floor</option>
              <option value="-1">-1</option>
              <option value="1">1</option>
              <option value="2">2</option>
              <option value="3">3</option>
              <option value="4">4</option>
              <option value="5">5</option>
              <option value="6">6</option>
              <option value="7">7</option>
              <option value="8">8</option>
              <option value="9">9</option>
              <option value="10">10</option>
              <option value="11">11</option>
              <option value="12">12</option>
            </Form.Select>
          </Form.Group>             
           {isUserOwner && <IconButton onClick={()=>{handleSave("floors")}} size="small"><DoneIcon style={{fill:"green"}} /></IconButton>}
            </td>: 
            <td className='tdEdit'>{floors} {isUserOwner && <IconButton onClick={()=>{handleEdit("floors")}} size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>}</td>

          }        </tr>
        <tr>
          <td>Building Age</td>
          {
            buildingAgeEdit ?  
            <td className='tdEdit'>
              <InputGroup className="mb-6" style={{width:"75%"}}>
            <Form.Control value={buildingAge} onChange={(e)=>handleChange(e,"buildingAge")} aria-label="Amount (to the nearest dollar)" />
            <InputGroup.Text>Years</InputGroup.Text>
            </InputGroup>          
            {isUserOwner && <IconButton onClick={()=>{handleSave("buildingAge")}} size="small"><DoneIcon style={{fill:"green"}} /></IconButton>}
            </td>: 
            <td className='tdEdit'>{buildingAge} {isUserOwner && <IconButton onClick={()=>{handleEdit("buildingAge")}} size="small"><EditIcon style={{fill:"#1565C0"}} /></IconButton>}</td>

          }        
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