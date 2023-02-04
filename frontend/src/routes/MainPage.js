import { Outlet, Link } from 'react-router-dom';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { useAuth } from "../utils/Auth";

function MainPage() {
  const { clientId, onSuccess, onFailure, profile } = useAuth();
 
  return <Navbar expand="lg">
    <Container>
      <Navbar.Brand href="#">VRestate</Navbar.Brand>
      <Nav className="me-auto">
        <Link to="/service">
          <Nav.Link>Service</Nav.Link>
        </Link>
        <Nav.Link href="#home">Home</Nav.Link>
        <Nav.Link href="#features">Features</Nav.Link>
        <Nav.Link href="#pricing">Pricing</Nav.Link>
      </Nav>
    </Container>
  </Navbar>
}

export default MainPage;