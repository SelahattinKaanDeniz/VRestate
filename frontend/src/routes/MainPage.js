import { Outlet, Link } from 'react-router-dom';
import ESTATES from '../mock/mockEstates'
import { useAuth } from "../utils/Auth";
import { useNavigate } from "react-router-dom";
import Header from '../components/Header';
import Listing from '../components/Listing';
import Button from '@mui/material/Button';
function MainPage() {
  const navigate = useNavigate();
  const { clientId, onSuccess, onFailure, profile, onLogOutSuccess } = useAuth();
  return(
    <>
     <Header/>
     <div style={{marginTop:"12rem",width: '100%', maxWidth: 900, margin: '0 auto',display:"flex",flexDirection:"column",gap:"2rem"}} >
     {/* <Button sx={{width:"150px",marginLeft:"auto"}} variant="contained" onClick={() => { navigate(`/create`); }} >CREATE NEW</Button> */}
      <Listing />
     </div>
    </>
   
  )
    
}

export default MainPage;