import Header from "../components/Header";
import { useEffect, useState, useCallback } from 'react';
import { GoogleMap, useJsApiLoader } from '@react-google-maps/api';
import { MarkerF } from '@react-google-maps/api';
import EstateModal from "../components/EstateModal";
import { useNavigate } from "react-router-dom";
const containerStyle = {
    width: '100%',
    height: '90vh',
  };



export default function MapsPage(){
  const [open, setOpen] = useState(false);
  const handleClose = () => setOpen(null);
  const navigate = useNavigate();
  const { isLoaded } = useJsApiLoader({
    id: 'google-map-script',
    googleMapsApiKey: "AIzaSyCcwb_SbKqbxXJWktAikadVeCNlKSt9iAQ"
    });
    const [estates, setEstates]= useState([]);
    const [center, setCenter] = useState({
      lat: 39.925533,
      lng: 	32.866287
    })


    useEffect(()=>{
        async function fetchEstates(){
            fetch("http://vrestate.tech:5002/estate/getEstates?detail=true&user=true")
            .then(response => response.json())
            .then(async (data) => {
              const currentEstates= data.results;
              const arrEstates= [];

            await Promise.all(currentEstates.map(async (e) => {
              const obj = await fetchData(e);
              arrEstates.push(obj);
            }));
            setEstates(arrEstates);
            })
        }
        async function fetchUserLocation(){
          fetch("http://vrestate.tech:5002/checkLocation")
          .then((response)=>response.json())
          .then(async (data)=>{
            console.log(data);
            if(data && data.lat && data.lon){
              setCenter({
                lat: data.lat,
                lng: data.lon
              })
            }
          })
        }
        async function fetchData(e){
          if(e.head_photo_id){
            const response = await fetch("http://vrestate.tech:5002/getImage?id="+e.head_photo_id);
            const data= await response.blob();
            const imageObjectURL = URL.createObjectURL(data);
            e.image=imageObjectURL;
            return e;
          }
          else{
            return e;
          }
        }
          fetchEstates();
          fetchUserLocation();
    },[])

    useEffect(()=>console.log(estates),[estates]);
    const [map, setMap] = useState(null)

    const onLoad = useCallback(function callback(map) {
      const bounds = new window.google.maps.LatLngBounds(center);
      map.fitBounds(bounds);
  
      setMap(map)
      map.panTo(center);
    }, [])
    
      const onUnmount = useCallback(function callback(map) {
        setMap(null)
      }, []);

    const onGoEstate = (estate)=>{
      navigate(`/estate/${estate.id}`, {state:{estate}})
    }
    return (
       <>
        <Header />
        {
          
            isLoaded ? 
            <GoogleMap
              mapContainerStyle={containerStyle}
              center={center}
              zoom={11.9}
              onLoad={onLoad}
              onUnmount={onUnmount}
            >
                {estates.map((estate)=>
               {
                if(estate.coordX){
                    console.log(estate.coordX);
                   return <> <MarkerF key={estate.id} onClick={()=>{setOpen(estate.id)}} position={{lat:parseFloat(estate.coordX) , lng:parseFloat(estate.coordY)}}></MarkerF>
                              <EstateModal handleClose={handleClose} open={open} estate={estate} onGoEstate={()=>{onGoEstate(estate)}}  /></>;
                }
               }
                )}
              
            </GoogleMap> : <div>Not Loaded!</div>
          }
        </>
    );
}