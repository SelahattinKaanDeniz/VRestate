import { useEffect, useState } from "react";
import Header from "../components/Header";
import { useAuth } from "../utils/Auth";
import UserAvatar from "../components/UserAvatar";
import { Divider } from "@mui/material";
import Listing from "../components/Listing";
import { useNavigate } from "react-router-dom";
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import CorporateFareIcon from '@mui/icons-material/CorporateFare';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
function ProfilePage(){
    const { profile } = useAuth();
    const navigate = useNavigate();
    const [estates, setEstates] = useState([]);
    useEffect( ()=>{
        fetch("http://localhost:5002/estate/getEstates?detail=true")
        .then(response => response.json())
        .then(async (data) => {
          const currentEstates= data.results;
          console.log(currentEstates);
          const myEstates=[];
          currentEstates.forEach((e)=>{
            if(e.owner_id == profile.id){
              myEstates.push(e);
            }
          })
          setEstates(myEstates);
          console.log(currentEstates);
        })
    },[])
  
    useEffect(()=>{
        console.log(profile)
    },[])
    return(
        <>
        <Header/>
        <div style={{display:"flex",margin:"0 auto", width:"90%",marginTop:"20px", justifyContent:"center",flexDirection:"column",textAlign:"center"}} >
            <div style={{display:"flex",flexDirection:"column", alignItems:"center",justifyContent:"center", backgroundColor:"#ededed", borderRadius:"10px",padding:"20px"}}>
            <UserAvatar width="100px" height="100px" text="50px" />
            {/* <div style={{borderTop:"1px solid grey", width:"100%"}} ></div> */}
            <h3 style={{ marginTop:"10px",}}>{profile.name} {profile.surname}</h3>
            <h6 style={{ marginTop:"10px",}}>{profile.mail}</h6>
            {/* <h1>{profile.surname}</h1> */}
             </div>
            <TableContainer component={Paper} sx={{marginTop:"2rem"}}>
            <h4>Your Listed Estates</h4>
      <Table sx={{  width:"60%", margin:"0 auto",minWidth: 650}} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Estate Title</TableCell>
            <TableCell align="right">Price $</TableCell>
            <TableCell align="right">Listed At</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {estates.map((estate) => (
            <TableRow
              key={estate.title}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {estate.title}
              </TableCell>
              <TableCell align="right">{estate.price}</TableCell>
              <TableCell align="right">{estate.create_date.slice(0,10)}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
        </div>
        
        </>
    )
}
export default ProfilePage;