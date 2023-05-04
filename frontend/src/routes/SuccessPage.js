import CheckCircleOutlineIcon from '@mui/icons-material/CheckCircleOutline';
import Container from 'react-bootstrap/esm/Container';
import Row from 'react-bootstrap/esm/Row';
import Header from '../components/Header';
function SuccessPage(props){
    return(
        <>
        <Header />
        <Container style={{marginTop:"15%", display:"flex",width:"100%",flexDirection:"column", alignItems:"center"}}>
        <h1>Created!</h1>
        <CheckCircleOutlineIcon style={{width:"200px", height:"200px",fill:"green"}} />
        </Container>
        </>
    )
}

export default SuccessPage;