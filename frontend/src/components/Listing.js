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


export default function Listing({myEstates}){
  const navigate = useNavigate();
  const [estates, setEstates] = useState([]);
  useEffect( ()=>{
    if(!myEstates){
      fetch("http://localhost:5002/estate/getEstates")
      .then(response => response.json())
      .then(data => {setEstates(data.results);console.log(data.results)});
    }
    else{

    }
    
   

  },[])

  useEffect(()=>{console.log(estates)},[estates])
    return(
    <Box sx={{ width: '100%', color: 'black', borderRadius:"10px"}}>
      <nav aria-label="main mailbox folders">
     
        <List  >
          {ESTATES.map((estate, index) => {
            return <ListItem alignItems="flex-start" sx={{ margin:"0 auto", maxWidth: "900px", borderRadius:"10px", '& .MuiListItemButton-root:hover': {
              bgcolor: '#eaf8fe',
              '&, & .MuiListItemIcon-root': {
                color: '#eaf8fe',
              },
            },}} key={estate.title} onClick={() => { navigate(`/estate/${estate.id}`, {state:{estate}}); }} disablePadding>
              <ListItemButton sx={{borderRadius:"10px"}}>
                <ListItemIcon>
                  <CorporateFareIcon />
                </ListItemIcon>
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