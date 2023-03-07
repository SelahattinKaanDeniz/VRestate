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

export default function Listing(){
  const navigate = useNavigate();
  const [estates, setEstates] = useState([]);
  useEffect( ()=>{

    fetch("http://localhost:5002/estate/getEstates")
    .then(response => response.json())
    .then(data => setEstates(data.results));
   

  },[])

  useEffect(()=>{console.log(estates)},[estates])
    return(
    <Box sx={{ bgcolor: '#EBF6F5', color: 'black'}}>
      <nav aria-label="main mailbox folders">
        <List >
          {ESTATES.map((estate, index) => {
            return <ListItem sx={{ marginTop:"10px"}} key={estate.title} onClick={() => { navigate(`/estate/${estate.id}`); }} disablePadding>
              <ListItemButton>
                <ListItemIcon>
                  <CorporateFareIcon />
                </ListItemIcon>
                <ListItemText primary={estate.title + " | "+ estate.location_il} />
              </ListItemButton>
            </ListItem>
          })}
        </List>
      </nav>
    </Box>
    );
}