import Header from "../components/Header";
import { useEffect, useState, useCallback } from 'react';
import { GoogleMap, useJsApiLoader } from '@react-google-maps/api';
import { MarkerF } from '@react-google-maps/api';
const containerStyle = {
    width: '100%',
    height: '100vh',
  };
export default function MapsPage(){
    const [estates, setEstates]= useState([]);
    useEffect(()=>{
        async function fetchEstates(){
            fetch("http://vrestate.tech:5002/estate/getEstates?detail=true&user=true")
            .then(response => response.json())
            .then(async (data) => {
              const currentEstates= data.results;
              setEstates(currentEstates);
            })
          }
         
          fetchEstates();
        
    },[])

    useEffect(()=>console.log(estates),[estates]);
    const [map, setMap] = useState(null)
    const { isLoaded } = useJsApiLoader({
        id: 'google-map-script',
        googleMapsApiKey: "AIzaSyCcwb_SbKqbxXJWktAikadVeCNlKSt9iAQ"
      });
      const onLoad = useCallback(function callback(map) {
        // const bounds = new window.google.maps.LatLngBounds({lat:parseFloat(coordinatesX) , lng:parseFloat(coordinatesY)});
        // map.fitBounds(bounds);
    
        map.panTo({lat:parseFloat(39.9255) , lng:parseFloat(32.8663)});
    
      }, [])
    
      const onUnmount = useCallback(function callback(map) {
        setMap(null)
      }, []);
    return (
       <>
        <Header />
        {
            isLoaded ? 
            <GoogleMap
              mapContainerStyle={containerStyle}
              center={{lat:parseFloat(100) , lng:parseFloat(100)}}
              zoom={11.9}
              onLoad={onLoad}
              onUnmount={onUnmount}
            >
                {estates.map((estate)=>
               {
                if(estate.coordX){
                    console.log(estate.coordX);
                   return  <MarkerF onClick={()=>{console.log("kjdskj")}} position={{lat:parseFloat(estate.coordX) , lng:parseFloat(estate.coordY)}}></MarkerF>;
                }
               }
                )}
              
            </GoogleMap> : <></>
          }
        </>
    );
}