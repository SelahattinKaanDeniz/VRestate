import { useEffect, useState, useCallback } from 'react';
import { useLocation, useParams } from 'react-router-dom';
import { GoogleMap, useJsApiLoader } from '@react-google-maps/api';
import Header from '../components/Header';
import { MarkerF } from '@react-google-maps/api';
import Table from 'react-bootstrap/Table';
const containerStyle = {
  width: '100%',
  height: '200px',
  margin: "0 auto"
};


function EstatePage() {
  const { id } = useParams();// estate ID
  const {state} = useLocation();
  console.log(state);
  const {coordX, coordY, title, price, owner_id, m2,
    balconyCount, bathroomCount} =state.estate;
  console.log(title);
  const { isLoaded } = useJsApiLoader({
    id: 'google-map-script',
    googleMapsApiKey: "AIzaSyCcwb_SbKqbxXJWktAikadVeCNlKSt9iAQ"
  })
  const [map, setMap] = useState(null)

  const onLoad = useCallback(function callback(map) {
    // const bounds = new window.google.maps.LatLngBounds({lat:parseFloat(coordinatesX) , lng:parseFloat(coordinatesY)});
    // map.fitBounds(bounds);

    map.panTo({lat:parseFloat(coordX) , lng:parseFloat(coordY)});

  }, [])

  const onUnmount = useCallback(function callback(map) {
    setMap(null)
  }, []);


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
    <h1>{title}</h1>
    <div>${price}</div>
      
    </div>
    <Table striped bordered hover>
     
      <tbody>
        <tr>
          <td>Size (m²)</td>
          <td>{m2}</td>
        </tr>
        <tr>
          <td>Number of Balconies</td>
          <td>{balconyCount}</td>
        </tr>
        <tr>
          <td>Number of Bathrooms</td>
          <td>{bathroomCount}</td>
        </tr>
        <tr>
          <td>Number of Bathrooms</td>
          <td>{bathroomCount}</td>
        </tr>
      </tbody>
    </Table>
   
    </div>
    
    </>
  );
    
}

export default EstatePage;