import { useEffect, useState, useCallback } from 'react';
import { useLocation, useParams } from 'react-router-dom';
import { GoogleMap, useJsApiLoader } from '@react-google-maps/api';
import Header from '../components/Header';
import { MarkerF } from '@react-google-maps/api';
const containerStyle = {
  width: '60%',
  height: '700px',
  margin: "0 auto"
};



function EstatePage() {
  const { id } = useParams();// estate ID
  const {state} = useLocation();
  const {coordinatesX, coordinatesY, title, price} =state;
  const { isLoaded } = useJsApiLoader({
    id: 'google-map-script',
    googleMapsApiKey: "AIzaSyCcwb_SbKqbxXJWktAikadVeCNlKSt9iAQ"
  })
  const [map, setMap] = useState(null)

  const onLoad = useCallback(function callback(map) {
    // const bounds = new window.google.maps.LatLngBounds({lat:parseFloat(coordinatesX) , lng:parseFloat(coordinatesY)});
    // map.fitBounds(bounds);

    map.panTo({lat:parseFloat(coordinatesX) , lng:parseFloat(coordinatesY)});

  }, [])

  const onUnmount = useCallback(function callback(map) {
    setMap(null)
  }, []);


  return(<>
    <Header />
    <div style={{display:"flex", flexDirection:"column",justifyContent:"center",alignItems:"center",}}>
    <h1>{title}</h1>
    <div>Price: ${price}</div>
    {
      isLoaded ? 
      <GoogleMap
        mapContainerStyle={containerStyle}
        center={{lat:coordinatesX , lng:coordinatesY}}
        zoom={11.9}
        onLoad={onLoad}
        onUnmount={onUnmount}
      >
        <MarkerF position={{lat:parseFloat(coordinatesX) , lng:parseFloat(coordinatesY)}}></MarkerF>
      </GoogleMap> : <></>
    }
      
    </div>
   
    </>
  );
    
}

export default EstatePage;