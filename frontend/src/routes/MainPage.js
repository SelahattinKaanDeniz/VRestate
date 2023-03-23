import { Outlet, Link } from 'react-router-dom';
import ESTATES from '../mock/mockEstates'
import { useAuth } from "../utils/Auth";
import { useNavigate } from "react-router-dom";
import Header from '../components/Header';
import Listing from '../components/Listing';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Autocomplete from '@mui/material/Autocomplete';
import SearchIcon from '@mui/icons-material/Search';
function MainPage() {
  const navigate = useNavigate();
  const { clientId, onSuccess, onFailure, profile, onLogOutSuccess } = useAuth();
  return(
    <>
     <Header/>
     <div style={{marginTop:"12rem",width: '100%', margin: '0 auto',display:"flex",flexDirection:"column"}} >
      <div className='filterContainer'>
      <Autocomplete
        id="free-solo-demo"
        sx={{margin:"0 auto",width:"200px"}}
        freeSolo
        options={["as"]}
        renderInput={(params) => <TextField {...params} label="Search" size='small'  InputProps={{
          endAdornment: (
            <SearchIcon />
          ),
        }}/>}
      />
      
      </div>
     {/* <Button sx={{width:"150px",marginLeft:"auto"}} variant="contained" onClick={() => { navigate(`/create`); }} >CREATE NEW</Button> */}
      <Listing />
     </div>
    </>
   
  )
    
}

export default MainPage;