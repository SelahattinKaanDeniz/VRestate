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

export default function Listing(){
  const navigate = useNavigate();
    return(
    <Box sx={{ bgcolor: 'background.paper'}}>
      <nav aria-label="main mailbox folders">
        <List >
          {ESTATES.map((estate, index) => {
            return <ListItem sx={{ marginTop:"10px"}} key={estate.estateName} onClick={() => { navigate(`/estate/${estate.id}`); }} disablePadding>
              <ListItemButton>
                <ListItemIcon>
                  <CorporateFareIcon />
                </ListItemIcon>
                <ListItemText primary={estate.estateName} />
              </ListItemButton>
            </ListItem>
          })}
        </List>
      </nav>
    </Box>
    );
}