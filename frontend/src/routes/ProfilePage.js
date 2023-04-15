import { useEffect, useState } from "react";
import Header from "../components/Header";
import { useAuth } from "../utils/Auth";
import UserAvatar from "../components/UserAvatar";
import { Divider, IconButton, TextField } from "@mui/material";
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
import LaunchIcon from '@mui/icons-material/Launch';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Alert from 'react-bootstrap/Alert';
function ProfilePage(){
    const { profile } = useAuth();
    const navigate = useNavigate();
    const [estates, setEstates] = useState([]);
    const [user, setUser] = useState({});
    const [success, setSuccess] = useState(false);
    const [fail, setFail] = useState(false);
    useEffect( ()=>{
      const fetchUser= async ()=>{
        const f1=await fetch(`http://localhost:5002/profile/getProfile?id=${profile.id}`);
        const info = await f1.json();
        setUser(info[0]);
      }
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
        });
        fetchUser();
        fetch("http://vrestate.tech:5002/profile/updateLocation?id="+profile.id)
        .then(response=>response.json())
        .then(data=>{
          console.log(data);
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
             <div style={{display:"flex"}}>
             <TableContainer component={Paper} sx={{marginTop:"2rem"}}>
            <h4>Settings</h4>
            <Form  style={{width:"30%", margin:"20px auto"}} className="mb-3">
          
     
          <Form.Group className="mb-4" size="sm">
          <Form.Label>Full Name</Form.Label>
          <Form.Control value={profile?.name+" "+profile.surname} disabled as="input" />
          </Form.Group>

          <Form.Group className="mb-4" size="sm">
          <Form.Label>Email</Form.Label>
          <Form.Control value={profile?.mail} disabled as="input" />
          </Form.Group>

          <Form.Group className="mb-4" size="sm">
          <Form.Label>Phone</Form.Label>
          <Form.Control value={user?.phone ? user.phone : ''} onChange={(e)=>setUser({...user,phone:e.target.value})} type="number" as="input" />
          </Form.Group>

          <Form.Group className="mb-4" size="sm">
          <Form.Label>TC</Form.Label>
          <Form.Control value={user?.TC_no ? user.TC_no : ''} onChange={(e)=>setUser({...user,TC_no:e.target.value})} type="number" as="input" />
          </Form.Group>

          <Form.Group className="mb-4" size="sm">
          <Form.Label>Payment Info(IBAN)</Form.Label>
          <Form.Control value={user?.paymentInfo} as="input"  onChange={(e)=>setUser({...user,paymentInfo:e.target.value})} />
          </Form.Group>
          
          {
            success && <Alert  variant="success">
              Updated Successfuly!
          </Alert>
          }

          
{
            fail && <Alert  variant="danger">
              Something went wrong!
          </Alert>
          }
        
          <Button style={{ marginTop:"1rem"}} onClick={ async (e)=>{
            e.preventDefault();
            console.log(user);
            const response = await fetch("http://localhost:5002/profile/update?id="+user.id, {
              method: "POST", // *GET, POST, PUT, DELETE, etc.
              cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
              credentials: "same-origin", // include, *same-origin, omit
              headers: {
                "Content-Type": "application/json",
              },
              referrerPolicy: "no-referrer", // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
              body: JSON.stringify(user), // body data type must match "Content-Type" header
            });
            const status= await response.status;
            if(status==200){
              setSuccess(true);
              setFail(false);
            }
            else{
              setFail(true);
              setSuccess(false);
            }
          }} type="submit">Update</Button>
         
          </Form>


            </TableContainer>
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
                        {estate.title} <IconButton onClick={()=>{navigate(`/estate/${estate.id}`, {state:{estate}})}} ><LaunchIcon/></IconButton>
                      </TableCell>
                      <TableCell align="right">{estate.price}</TableCell>
                      <TableCell align="right">{estate.create_date.slice(0,10)}</TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
             </div>
         
        </div>
        
        </>
    )
}
export default ProfilePage;