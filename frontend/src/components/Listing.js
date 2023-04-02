import { Outlet, Link } from 'react-router-dom';
import ESTATES from '../mock/mockEstates'
// import Button from 'react-bootstrap/Button';
import { useAuth } from "../utils/Auth";
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import CorporateFareIcon from '@mui/icons-material/CorporateFare';
import { useNavigate } from "react-router-dom";
import Header from './Header';
import { useEffect, useState } from 'react';
import * as React from 'react';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import Image from 'react-bootstrap/Image'


export default function Listing({myEstates}){
  const { profile } = useAuth();
  const navigate = useNavigate();
  const [estates, setEstates] = useState([]);
  useEffect( ()=>{
    async function fetchEstates(isMyEstates){
      fetch("http://localhost:5002/estate/getEstates?detail=true")
      .then(response => response.json())
      .then(async (data) => {
        const currentEstates= data.results;
        console.log(currentEstates);
        const arrEstates= [];
        
        await Promise.all(currentEstates.map(async (e) => {
          const obj = await fetchData(e);
          arrEstates.push(obj);
        }));
       if(isMyEstates){
        const myEstates=[];
        arrEstates.forEach((e)=>{
          if(e.owner_id == profile.id){
            myEstates.push(e);
          }
        })
        setEstates(myEstates);
       }
       else{

         setEstates(arrEstates);
       }
      })
    }
    async function fetchData(e){
      if(e.head_photo_id){
        const response = await fetch("http://localhost:5002/getImage?id="+e.head_photo_id);
        const data= await response.blob();
        const imageObjectURL = URL.createObjectURL(data);
        e.image=imageObjectURL;
        return e;
      }
      else{
        return e;
      }
    }
    if(!myEstates){
      fetchEstates(false);
    }
    else{
      fetchEstates(true);
    }
    
   

  },[])

  useEffect(()=>{console.log(estates)},[estates])
    return(
    <Box sx={{ width: '100%', color: 'black', borderRadius:"10px"}}>
      <nav aria-label="main mailbox folders">
     
        <List  >
          {estates.map((estate, index) => {
            return <ListItem alignItems="flex-start" sx={{ margin:"0 auto", maxWidth: "1000px", borderRadius:"10px", '& .MuiListItemButton-root:hover': {
              bgcolor: '#eaf8fe',
              '&, & .MuiListItemIcon-root': {
                color: '#eaf8fe',
              },
            },}} key={estate.title} onClick={() => { navigate(`/estate/${estate.id}`, {state:{estate}}); }} disablePadding>
              
              <ListItemButton sx={{borderRadius:"10px" ,display:"flex", gap:"10px", height:"120px"}}>
                <div style={{flexBasis:"20%",display:"flex", alignItems:"center",justifyContent:"center"}}>
                {estate.image ?<Image style={{ maxHeight:"120px", maxWidth:"120px"}} src={estate.image} rounded={true}/>:<ListItemIcon style={{flexBasis:"20%", display:"flex", alignItems:"center",justifyContent:"center"}}>
                  <CorporateFareIcon />
                </ListItemIcon>}
                </div>
             
                
                
                <ListItemText
          primary={<div style={{color:"#758DFB"}}>
            {estate.title}
            <div>${estate.price}</div>
            <div>{estate.m2}m², {estate.room_type} </div>
            <div></div>
          </div>}
          secondary={
            <React.Fragment>
            
              With {estate.bathroomCount} Bathrooms, {estate.balconyCount} Balconies
            </React.Fragment>
          }
        />
                <ListItemText sx={{maxWidth: "300px"}} primary={<div>
                
                </div> } />
                {/* <ListItemText primary={estate.title + " | "+ estate.locati on_il} /> */}
                
              </ListItemButton>
            </ListItem>
          })}
        </List>
      </nav>
    </Box>
    );
}