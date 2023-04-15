import { Outlet, Link } from 'react-router-dom';
import ESTATES from '../mock/mockEstates'
import { useAuth } from "../utils/Auth";
import { useNavigate } from "react-router-dom";
import Header from '../components/Header';
import Listing from '../components/Listing';
import { useEffect, useState } from 'react';

function MainPage() {
  const [searchSpeech, setSearchSpeech] = useState('');
  useEffect(()=>{
    console.log(searchSpeech);
  },[searchSpeech]);
  return(
    <>
     <Header isMainPage={true} setSearchSpeech={setSearchSpeech} />
     <div style={{marginTop:"12rem",width: '100%', height: '89vh', margin: '0 auto',display:"flex",flexDirection:"column"}} >
    
     {/* <Button sx={{width:"150px",marginLeft:"auto"}} variant="contained" onClick={() => { navigate(`/create`); }} >CREATE NEW</Button> */}
      <Listing searchSpeech={searchSpeech} />
     </div>
    </>
   
  )
    
}

export default MainPage;