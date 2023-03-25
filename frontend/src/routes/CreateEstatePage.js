import Header from "../components/Header";
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';
import cities from "../data/cities";
import Button from 'react-bootstrap/Button';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { useEffect, useState, useCallback } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { GoogleMap, useJsApiLoader } from '@react-google-maps/api';
import { MarkerF } from '@react-google-maps/api';
import Alert from 'react-bootstrap/Alert';
const AnyReactComponent = ({ text }) => <div>{text}</div>;
const containerStyle = {
  width: '500px',
  height: '500px',
  margin: "0 auto",
  borderRadius: "20px"
};

const center = {
  lat: 39.925533,
  lng: 	32.866287
};
function CreateEstatePage() {
  const navigate = useNavigate();
  const { isLoaded } = useJsApiLoader({
    id: 'google-map-script',
    googleMapsApiKey: "AIzaSyCcwb_SbKqbxXJWktAikadVeCNlKSt9iAQ"
  })
  const [map, setMap] = useState(null)
  const [coordinates, setCoordinates] = useState(null);
  const [title, setTitle] = useState("");
  const [price, setPrice] = useState("");
  const [roomType, setRoomType] = useState("1+0");
  const [size, setSize] = useState("");
  const [bathroomNumber, setBathroomNumber] = useState("0");
  const [floor, setFloor] = useState("0");
  const [furnished, setFurnished] = useState("0");
  const [buildingAge, setBuildingAge] = useState("0");
  const [balconyNumber, setBalconyNumber] = useState("0");
  const [buildingFees, setBuildingFees] = useState("");
  const [isError, setIsError] = useState(false);
  
  const onLoad = useCallback(function callback(map) {
    const bounds = new window.google.maps.LatLngBounds(center);
    map.fitBounds(bounds);

    setMap(map)
    map.panTo(center);
  }, [])

  const onUnmount = useCallback(function callback(map) {
    setMap(null)
  }, []);

  const onMapClick = (e) => {
    setCoordinates(
        {
          lat: e.latLng.lat(),
          lng: e.latLng.lng()
        }
    );
  };

  const clickSubmit = (e)=>{
    /// HERE WE SUBMITTT!!!
    e.preventDefault();
    if(!title || !price || !roomType|| !size|| !coordinates ||!bathroomNumber || !floor || !furnished || !buildingAge || !balconyNumber || !buildingFees){
  
      setIsError(true);
    }
    else{
      navigate("/success")
    }
    console.log(e);
    console.log(1)
    console.log(title,price,roomType,size,coordinates);
  }

  const clickSubmit2 = (e)=>{
    e.preventDefault();
    console.log("sub");
    console.log(e);
    console.log(1)
  }
  return(
    <>
      <Header/>
        <Form onSubmit={clickSubmit2} style={{width:"30%", margin:"0 auto"}} className="mb-3">
        <h1 style={{margin:"0 auto", textAlign:"center"}} >Create New Estate</h1>
     
          <Form.Group className="mb-4" size="sm">
          <Form.Label>Title</Form.Label>
          <Form.Control onChange={(e)=>setTitle(e.target.value)} as="input" />
          </Form.Group>

          <Form.Group className="mb-4" size="sm">
          <Form.Label>Price</Form.Label>
          <InputGroup className="mb-3">
            <InputGroup.Text>$</InputGroup.Text>
            <Form.Control onChange={(e)=>setPrice(e.target.value)} aria-label="Amount (to the nearest dollar)" />
            </InputGroup>
          </Form.Group>
          <Form.Group className="mb-4" size="sm">
          <Form.Label>Building Fees</Form.Label>
          <InputGroup className="mb-3">
            <InputGroup.Text>$</InputGroup.Text>
            <Form.Control onChange={(e)=>setBuildingFees(e.target.value)} aria-label="Amount (to the nearest dollar)" />
            <InputGroup.Text>Per Month</InputGroup.Text>
            </InputGroup>
          </Form.Group>

          
            <Form.Group className="mb-4" size="sm">
            <Form.Label>Room Type</Form.Label>
            <Form.Select onChange={(e)=>setRoomType(e.target.value)} aria-label="Default select example">
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
          </Form.Group>

          
          <Form.Group className="mb-4" size="sm">
            <Form.Label>Floor</Form.Label>
            <Form.Select onChange={(e)=>setFloor(e.target.value)} aria-label="Default select example">
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
          <Form.Group className="mb-4" size="sm">
            <Form.Label>Furnished</Form.Label>
            <Form.Select onChange={(e)=>setFurnished(e.target.value)} aria-label="Default select example">
              <option value="0">No</option>
              <option value="1">Yes</option>
            </Form.Select>
          </Form.Group>

           
          <Form.Group className="mb-4" size="sm">
            <Form.Label>Number of Bathrooms</Form.Label>
            <Form.Select onChange={(e)=>setBathroomNumber(e.target.value)} aria-label="Default select example">
              <option value="0">0</option>
              <option value="1">1</option>
              <option value="2">2</option>
              <option value="3">3</option>
              <option value="4">4</option>
              <option value="5">5</option>
              <option value="6">6</option>
            </Form.Select>
          </Form.Group>
          <Form.Group className="mb-4" size="sm">
            <Form.Label>Number of Balconies</Form.Label>
            <Form.Select onChange={(e)=>setBalconyNumber(e.target.value)} aria-label="Default select example">
              <option value="0">0</option>
              <option value="1">1</option>
              <option value="2">2</option>
              <option value="3">3</option>
              <option value="4">4</option>
              <option value="5">5</option>
              <option value="6">6</option>
            </Form.Select>
          </Form.Group>

          <Form.Group  className="mb-3" size="sm">
          <Form.Label>Building Age</Form.Label>
          <InputGroup className="mb-3">
            <Form.Control onChange={(e)=>setBuildingAge(e.target.value)} />
            <InputGroup.Text>Years</InputGroup.Text>
            </InputGroup>
          </Form.Group>

          <Form.Group  className="mb-3" size="sm">
          <Form.Label>Size</Form.Label>
          <InputGroup className="mb-3">
            <Form.Control onChange={(e)=>setSize(e.target.value)} />
            <InputGroup.Text>m² </InputGroup.Text>
            </InputGroup>
          </Form.Group>

         
            <div style={{marginBottom:"1rem", textAlign:"center"}}>Find and click location of your estate:</div>
            {
              isLoaded ? 
              <GoogleMap
                mapContainerStyle={containerStyle}
                center={center}
                zoom={8}
                onLoad={onLoad}
                onUnmount={onUnmount}
                onClick={onMapClick}
              >
                <MarkerF position={coordinates}></MarkerF>
              </GoogleMap> : <></>
            }
          
          {
      isError && 
        <Alert style={{marginTop:"1rem", textAlign:"center" }} variant="danger">Please Fill All Areas and Select from Map!
        </Alert>
     }
          <Button style={{marginLeft:"38%", marginTop:"1rem"}} type="submit" onClick={clickSubmit}>Create</Button>
         
          </Form>
         
        </>
  )
    
}

export default CreateEstatePage;