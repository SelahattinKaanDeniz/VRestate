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

export default function Listing({myEstates}){
  const navigate = useNavigate();
  const [estates, setEstates] = useState([]);
  useEffect( ()=>{
    if(!myEstates){
      fetch("http://localhost:5002/estate/getEstates")
      .then(response => response.json())
      .then(data => setEstates(data.results));
    }
    else{

    }
    
   

  },[])

  useEffect(()=>{console.log(estates)},[estates])
    return(
    <Box sx={{ width: '100%', color: 'black', borderRadius:"10px"}}>
      <nav aria-label="main mailbox folders">
        <List >
          {ESTATES.map((estate, index) => {
            return <ListItem sx={{ margin:"0 auto", maxWidth: "900px"}} key={estate.title} onClick={() => { navigate(`/estate/${estate.id}`, {state:{title:estate.title,price:estate.price,coordinatesX:estate.coordX,coordinatesY:estate.coordY,owner_id:estate.owner_id}}); }} disablePadding>
              <ListItemButton>
                <ListItemIcon>
                  <CorporateFareIcon />
                </ListItemIcon>
                <ListItemText sx={{maxWidth: "300px"}} primary={estate.title } />
                {/* <ListItemText primary={estate.title + " | "+ estate.locati on_il} /> */}
              </ListItemButton>
            </ListItem>
          })}
        </List>
      </nav>
    </Box>
    );
}