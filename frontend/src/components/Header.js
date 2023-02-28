import { Outlet, Link } from 'react-router-dom';
// import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useAuth } from "../utils/Auth";
import Avatar from '@mui/material/Avatar';

export default function Header(){
    return(
    <Navbar expand="lg">
      <Container>
        <Navbar.Brand href="/">VRestate</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="/estates">My Estates</Nav.Link>
          </Nav>
        </Navbar.Collapse>
        <Avatar>KU</Avatar>
      </Container>
    </Navbar>
    )
}