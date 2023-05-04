import ErrorOutlineIcon from '@mui/icons-material/ErrorOutline';
import Container from 'react-bootstrap/esm/Container';
import Row from 'react-bootstrap/esm/Row';
import Header from '../components/Header';
import { Button } from '@mui/material';
import { useNavigate } from 'react-router-dom';
function FailPage(props){
    const navigate=useNavigate();
    return(
        <>
        <Header />
        <Container style={{marginTop:"15%", display:"flex",width:"100%",flexDirection:"column", alignItems:"center"}}>
        <h1>Error Occured!</h1>
        <ErrorOutlineIcon style={{width:"200px", height:"200px",fill:"red"}} />
        <Button onClick={()=>navigate("/create")}>Go Creating Estate Page</Button>
        </Container>
        </>
    )
}

export default FailPage;