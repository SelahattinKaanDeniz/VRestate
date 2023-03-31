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
import Geocode from "react-geocode";
import { useAuth } from "../utils/Auth";

const AnyReactComponent = ({ text }) => <div>{text}</div>;
const containerStyle = {
  width: '500px',
  height: '500px',
  margin: "0 auto",
  borderRadius: "20px"
};
Geocode.setApiKey("AIzaSyCcwb_SbKqbxXJWktAikadVeCNlKSt9iAQ");

// set response language. Defaults to english.
Geocode.setLanguage("en");


// set location_type filter . Its optional.
// google geocoder returns more that one address for given lat/lng.
// In some case we need one address as response for which google itself provides a location_type filter.
// So we can easily parse the result for fetching address components
// ROOFTOP, RANGE_INTERPOLATED, GEOMETRIC_CENTER, APPROXIMATE are the accepted values.
// And according to the below google docs in description, ROOFTOP param returns the most accurate result.
Geocode.setLocationType("ROOFTOP");


const center = {
  lat: 39.925533,
  lng: 	32.866287
};
function CreateEstatePage() {
  const { profile } = useAuth();
  const navigate = useNavigate();
  const { isLoaded } = useJsApiLoader({
    id: 'google-map-script',
    googleMapsApiKey: "AIzaSyCcwb_SbKqbxXJWktAikadVeCNlKSt9iAQ"
  })
  const [map, setMap] = useState(null)
  const [isError, setIsError] = useState(false);

  //States For Estate PROPERTIES
  const [coordinates, setCoordinates] = useState(null);
  const [title, setTitle] = useState("");
  const [price, setPrice] = useState("");
  const [room_type, setRoom_type] = useState("1+0");
  const [m2, setM2] = useState("");
  const [bathroomCount, setBathroomCount] = useState("0");
  const [floors, setFloors] = useState("0");
  const [isFurnished, setIsFurnished] = useState("0");
  const [buildingAge, setBuildingAge] = useState("0");
  const [balconyCount, setBalconyCount] = useState("0");
  const [buildingFees, setBuildingFees] = useState("");
  const [image, setImage] = useState(null);
  
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

  const  clickSubmit = async (e)=>{
    e.preventDefault();
    if(image){
      const data = new FormData();
      data.append("file", image);
      const imageResponse = await fetch('http://localhost:5002/upload', {
        method: "POST", // *GET, POST, PUT, DELETE, etc.
        body: data, // body data type must match "Content-Type" header
      });
      const data2 = await imageResponse.json();
      console.log(data2);
      return;
    }
    else{
      console.log("nooo")
    }
    if(!title || !price || !m2|| !coordinates  || !buildingAge  || !buildingFees){
  
      setIsError(true);
    }
    else{

      Geocode.fromLatLng(coordinates.lat, coordinates.lng).then(
        (response) => {
          const address = response.results[0].formatted_address;
          let city, state, country;
          for (let i = 0; i < response.results[0].address_components.length; i++) {
            for (let j = 0; j < response.results[0].address_components[i].types.length; j++) {
              switch (response.results[0].address_components[i].types[j]) {
                case "locality":
                  city = response.results[0].address_components[i].long_name;
                  break;
                case "administrative_area_level_1":
                  state = response.results[0].address_components[i].long_name;
                  break;
                case "country":
                  country = response.results[0].address_components[i].long_name;
                  break;
              }
            }
          }
          return state;
        },
        (error) => {
          return ""
        }
      ).then(async (il)=>{
        const data={
          il,
          title,
          price,
          room_type,
          m2,
          coordX:coordinates.lat,
          coordY:coordinates.lng,
          bathroomCount,
          floors,
          isFurnished,
          buildingAge , 
          balconyCount,
          buildingFees,
          estate_type:"satilik",
          category:"daire",
          ilce:"",
          owner_id:profile.id,
          buildingFloors:4,
        }
        const response = await fetch('http://localhost:5002/estate/create', {
          method: "POST", // *GET, POST, PUT, DELETE, etc.
          cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
          credentials: "same-origin", // include, *same-origin, omit
          headers: {
            "Content-Type": "application/json",
          },
          referrerPolicy: "no-referrer", // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
          body: JSON.stringify(data), // body data type must match "Content-Type" header
        });
        navigate("/success");
      });
    }
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


          <Form.Group controlId="file"  className="mb-3">
          <Form.Label>Upload Image</Form.Label>
          <Form.Control type="file" name="image" accept="image/*"onChange={(e)=>setImage(e.target.files[0])} />
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
            <Form.Select onChange={(e)=>setRoom_type(e.target.value)} aria-label="Default select example">
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
            <Form.Select onChange={(e)=>setFloors(e.target.value)} aria-label="Default select example">
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
            <Form.Select onChange={(e)=>setIsFurnished(e.target.value)} aria-label="Default select example">
              <option value="0">No</option>
              <option value="1">Yes</option>
            </Form.Select>
          </Form.Group>

           
          <Form.Group className="mb-4" size="sm">
            <Form.Label>Number of Bathrooms</Form.Label>
            <Form.Select onChange={(e)=>setBathroomCount(e.target.value)} aria-label="Default select example">
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
            <Form.Select onChange={(e)=>setBalconyCount(e.target.value)} aria-label="Default select example">
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
            <Form.Control onChange={(e)=>setM2(e.target.value)} />
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