import { useEffect, useState, useCallback } from 'react';
import { useParams } from 'react-router-dom';
import { GoogleMap, useJsApiLoader } from '@react-google-maps/api';
import Header from '../components/Header';
import { Marker } from '@react-google-maps/api';
const containerStyle = {
  width: '600px',
  height: '600px',
  margin: "0 auto"
};

const center = {
  lat: 39.925533,
  lng: 	32.866287
};


function EstatePage() {
  const { id } = useParams();// estate ID
  const { isLoaded } = useJsApiLoader({
    id: 'google-map-script',
    googleMapsApiKey: "AIzaSyCcwb_SbKqbxXJWktAikadVeCNlKSt9iAQ"
  })
  const [map, setMap] = useState(null)
  // useEffect(()=>{
  //   map.panTo(center);
  // },[])
  const onLoad = useCallback(function callback(map) {
    // This is just an example of getting and using the map instance!!! don't just blindly copy!
    const bounds = new window.google.maps.LatLngBounds(center);
    map.fitBounds(bounds);

    setMap(map)
    map.panTo(center);
  }, [])

  const onUnmount = useCallback(function callback(map) {
    setMap(null)
  }, [])

  return(<>
    <Header />
    {
      isLoaded ? 
      <GoogleMap
        mapContainerStyle={containerStyle}
        center={center}
        zoom={8}
        onLoad={onLoad}
        onUnmount={onUnmount}
      >
        <Marker position={center}></Marker>
        { /* Child components, such as markers, info windows, etc. */ }
        <></>
      </GoogleMap> : <></>
    }
      
    </>
  );
    
}

export default EstatePage;