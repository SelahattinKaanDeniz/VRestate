import { Outlet, Link } from 'react-router-dom';
// import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { useAuth } from "../utils/Auth";
import Button from '@mui/material/Button';

function MainPage() {
  const { clientId, onSuccess, onFailure, profile, onLogOutSuccess } = useAuth();
 
  return <Navbar>
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
}

export default MainPage;