import { Outlet, Link } from 'react-router-dom';
// import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useAuth } from "../utils/Auth";
import img from '../images/VRestate_logo3.png'
import UserAvatar from './UserAvatar';
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';
import CustomToggle from './CustomToggle';
export default function Header(){
  const { onLogOutSuccess,profile } = useAuth();
    const avatar= profile.name[0]+profile.surname[0];
    return(
    <Navbar expand="md">
      <Container>
        <Navbar.Brand href="/"><img src={img} class='HeaderLogo'></img></Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="/estates">My Estates</Nav.Link>
            <Nav.Link href="/create">Create New</Nav.Link>
            <Nav.Link href="/maps">Map</Nav.Link>
          </Nav>
        </Navbar.Collapse>

      
        <Dropdown>
        <Dropdown.Toggle as={ CustomToggle}>
        <UserAvatar/>
      </Dropdown.Toggle>
          <Dropdown.Menu  > 
        <Dropdown.Item href="/profile">Profile</Dropdown.Item>
        <Dropdown.Item onClick={()=>{onLogOutSuccess()}} >Logout</Dropdown.Item>
      </Dropdown.Menu></Dropdown>
       
      </Container>
    </Navbar>
    )
}