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
import { TextField } from '@mui/material';
import InputAdornment from '@mui/material/InputAdornment';
import SearchIcon from '@mui/icons-material/Search';
import RadioButtonCheckedIcon from '@mui/icons-material/RadioButtonChecked';
import Button from '@mui/material/Button';
import SpeechRecognition, { useSpeechRecognition } from 'react-speech-recognition';
import MicIcon from '@mui/icons-material/Mic';
import { useEffect } from 'react';
export default function Header({isMainPage,setSearchSpeech}){
  const { onLogOutSuccess,profile } = useAuth();
  const {
    transcript,
    listening,
    resetTranscript,
    browserSupportsSpeechRecognition
  } = useSpeechRecognition();
  useEffect(()=>{
    if(setSearchSpeech){
      setSearchSpeech(transcript);
    }
  },[transcript])

  if (!browserSupportsSpeechRecognition) {
    return <span>Browser doesn't support speech recognition.</span>;
  }
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
     {
      isMainPage &&    
      <>
        <div style={{ marginRight:"12px"}}>
        {/* <p>Speech to text <MicIcon /> </p> */}
        <span style={{fontSize:"12px"}}> <MicIcon />Search in Title with Speech2Text </span>
        </div>
        <TextField label=""   InputProps={{
          startAdornment: (
            <InputAdornment position="start">
              {listening ? <RadioButtonCheckedIcon style={{fill:"green"}} /> : <RadioButtonCheckedIcon style={{fill:"red"}} />}
              <Button onClick={()=>{if(!listening) SpeechRecognition.startListening({ language: 'tr' }); else SpeechRecognition.stopListening();}}> {listening ? <span>Stop</span> : <span>Start</span>}</Button>

            </InputAdornment>
          ),
          endAdornment:(
            <InputAdornment position="start">
            <Button onClick={resetTranscript}>Clear</Button>

          </InputAdornment>
          )
        }} id="standard-basic" variant="standard" size="small" width="200px" value={transcript} style={{marginRight:"20px",  width:"300px"}} />
      </>
     }
        
      
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