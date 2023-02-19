import { Outlet, Link } from 'react-router-dom';
import ESTATES from '../mock/mockEstates'
// import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { useAuth } from "../utils/Auth";
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import CorporateFareIcon from '@mui/icons-material/CorporateFare';
import { useNavigate } from "react-router-dom";
function MainPage() {
  const { clientId, onSuccess, onFailure, profile, onLogOutSuccess } = useAuth();
  const navigate = useNavigate();
  return <>
    <Navbar className="dene" >
      <Container>
        <Navbar.Brand href="#">VRestate</Navbar.Brand>
        <Nav className="me-auto">
          <Nav.Link href="/">Home</Nav.Link>
          <Nav.Link href="/myestates">My Estates</Nav.Link>
          <Nav.Link href="/profile">My Profile</Nav.Link>
        </Nav>
        <button onClick={onLogOutSuccess}>logout</button>

      </Container>
    </Navbar>
    <Box sx={{ width: '100%', maxWidth: 1200, margin: '0 auto', bgcolor: 'background.paper' }}>
      <nav aria-label="main mailbox folders">
        <List>
          {ESTATES.map((estate, index) => {
            return <ListItem key={estate.estateName} onClick={() => { navigate(`/estate/${estate.id}`); }} disablePadding>
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
  </>
}

export default MainPage;