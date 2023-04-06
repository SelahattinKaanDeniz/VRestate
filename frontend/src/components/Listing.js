import { Outlet, Link } from 'react-router-dom';
import ESTATES from '../mock/mockEstates'
// import Button from 'react-bootstrap/Button';
import { useAuth } from "../utils/Auth";
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import CorporateFareIcon from '@mui/icons-material/CorporateFare';
import { useNavigate } from "react-router-dom";
import Header from './Header';
import { useEffect, useState } from 'react';
import * as React from 'react';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Autocomplete from '@mui/material/Autocomplete';
import SearchIcon from '@mui/icons-material/Search';
import Image from 'react-bootstrap/Image'
import { Table } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';


export default function Listing({myEstates}){
  const { profile } = useAuth();
  const navigate = useNavigate();
  const [estates, setEstates] = useState([]);
  const [filteredEstates, setFilteredEstates] = useState([]);
  useEffect( ()=>{
    async function fetchEstates(isMyEstates){
      fetch("http://localhost:5002/estate/getEstates?detail=true")
      .then(response => response.json())
      .then(async (data) => {
        const currentEstates= data.results;
        console.log(currentEstates);
        const arrEstates= [];
        
        await Promise.all(currentEstates.map(async (e) => {
          const obj = await fetchData(e);
          arrEstates.push(obj);
        }));
       if(isMyEstates){
        const myEstates=[];
        arrEstates.forEach((e)=>{
          if(e.owner_id == profile.id){
            myEstates.push(e);
          }
        })
        setEstates(myEstates);
        setFilteredEstates(myEstates);
       }
       else{

         setEstates(arrEstates);
         setFilteredEstates(arrEstates);
       }
      })
    }
    async function fetchData(e){
      if(e.head_photo_id){
        const response = await fetch("http://vrestate.tech:5002/getImage?id="+e.head_photo_id);
        const data= await response.blob();
        const imageObjectURL = URL.createObjectURL(data);
        e.image=imageObjectURL;
        return e;
      }
      else{
        return e;
      }
    }
    if(!myEstates){
      fetchEstates(false);
    }
    else{
      fetchEstates(true);
    }
    
   

  },[])
  
  const options ={
    customHeadRender: ()=>null
  }
  const handleSearch = (e)=>{
    console.log(e.target.value);
  }
  const columns=[
    // {
    //   field:"icon",
    //   editable:"false",
    //   headerClassName: 'hideRightSeparator',
    //   width:"400",
    //   renderCell:(params)=>{
    //     const estate=params.row;
    //     return(
    //       estate.image ?<Image style={{ maxHeight:"120px", maxWidth:"120px"}} src={estate.image} rounded={true}/>:<ListItemIcon style={{flexBasis:"20%", display:"flex", alignItems:"center",justifyContent:"center"}}>
    //                <CorporateFareIcon />
    //                </ListItemIcon>
    //     )
    //   }
    // },
    {
      field:"Image",
      headerName:"",
      editable:"false",
      disableColumnMenu:true,
      sortable:false,
      flex:0.5,
      renderCell: (params)=>{
        const estate= params.row;
        return(
    
estate.image ?<Image style={{ maxHeight:"120px", maxWidth:"120px"}} src={estate.image} rounded={true}/>:<ListItemIcon style={{flexBasis:"20%", display:"flex", alignItems:"center",justifyContent:"center"}}>
                   <CorporateFareIcon />
                   </ListItemIcon>
        )
      },
    },
    {
      field:"title",
      headerName:"Title",
      editable:"false",
      renderCell: (params)=>{
        const estate= params.row;
        return(
         
                   <ListItemText
          primary={<div style={{color:"#758DFB"}}>
            {estate.title}
            <div>${estate.price}</div>
            <div>{estate.m2}m², {estate.room_type} </div>
            <div></div>
          </div>}
          secondary={
            <React.Fragment>
            
              With {estate.bathroomCount} Bathrooms, {estate.balconyCount} Balconies
            </React.Fragment>
          }
        />
        )
      },
      flex:1
    },


    {
      field:"Price",
      editable:"false",
      flex:1,
      valueGetter: (a)=>`$${a.row.price}`
    },
    {
      field:"M²",
      editable:"false",
      flex:0.5,
      valueGetter: (a)=>`${a.row.m2}m²`
    },
    {
      field:"Balcony Count",
      editable:"false",
      flex:0.5,
      valueGetter: (a)=>`${a.row.balconyCount}`
    },
    {
      field:"Bathroom Count",
      editable:"false",
      flex:0.5,
      valueGetter: (a)=>`${a.row.balconyCount}`
    },
    {
      field:"Listed By",
      editable:"false",
      flex:0.5,
      valueGetter: (a)=>`${a.row.balconyCount}`
    },
    {
      field:"Owner",
      editable:"false",
      flex:1,
      valueGetter: (a)=>`${a.row.m2}m²`
    },
    { 
      field:"Go",
      headerName:"",
      editable:"false",
      disableColumnMenu:true,
      sortable:false,
      flex:1,
      renderCell:(a)=>{
        const estate = a.row;
        return(
        <Button onClick={() => navigate(`/estate/${estate.id}`, {state:{estate}})} > Go Details</Button>
        )
      }
    },
  ]

  
  useEffect(()=>{console.log(estates)},[estates])
    return(
      <Box sx={{ height: 900, width: '100%' }}>
       <DataGrid
        sx={{
          '& .hideRightSeparator > .MuiDataGrid-columnSeparator': {
            display: 'none',
          },
        }}
        rows={estates}
        columns={columns}
        rowHeight={150}
        initialState={{
          pagination: {
            paginationModel: {
              pageSize: 5,
            },
          },
        }}
        pageSizeOptions={[5]}
        disableRowSelectionOnClick
        hideColumnsHeader
        options={options}
      />
    </Box>
    // <Box sx={{ width: '100%', color: 'black', borderRadius:"10px"}}>
      
    //      <div className='filterContainer'>
    //   <Autocomplete
    //     id="free-solo-demo"
    //     sx={{margin:"0 auto",maxWidth:"200px"}}
    //     freeSolo
    //     onInput={handleSearch}
    //     options={["as"]}
    //     renderInput={(params) => <TextField {...params} label="Search" size='small'  InputProps={{
    //       endAdornment: (
    //         <SearchIcon />
    //       ),
    //     }}/>}
    //   />
      
    //   </div>
    //   <nav aria-label="main mailbox folders">
    //   {/* <DataGrid
    //     rows={estates}
    //     columns= {{}}
    //     pageSize={5}
    //     rowsPerPageOptions={[5]}
    //     checkboxSelection
    //   /> */}
    //     <Table  >
          
    //       {estates.map((estate, index) => {
    //         return <ListItem alignItems="flex-start" sx={{ margin:"0 auto", maxWidth: "1000px", borderRadius:"10px", '& .MuiListItemButton-root:hover': {
    //           bgcolor: '#eaf8fe',
    //           '&, & .MuiListItemIcon-root': {
    //             color: '#eaf8fe',
    //           },
    //         },}} key={estate.title} onClick={() => { navigate(`/estate/${estate.id}`, {state:{estate}}); }} disablePadding>
              
    //           <ListItemButton sx={{borderRadius:"10px" ,display:"flex", gap:"10px", height:"120px"}}>
    //             <div style={{flexBasis:"20%",display:"flex", alignItems:"center",justifyContent:"center"}}>
    //             {estate.image ?<Image style={{ maxHeight:"120px", maxWidth:"120px"}} src={estate.image} rounded={true}/>:<ListItemIcon style={{flexBasis:"20%", display:"flex", alignItems:"center",justifyContent:"center"}}>
    //               <CorporateFareIcon />
    //             </ListItemIcon>}
    //             </div>

    //             <ListItemText
    //       primary={<div style={{color:"#758DFB"}}>
    //         {estate.title}
    //         <div>${estate.price}</div>
    //         <div>{estate.m2}m², {estate.room_type} </div>
    //         <div></div>
    //       </div>}
    //       secondary={
    //         <React.Fragment>
            
    //           With {estate.bathroomCount} Bathrooms, {estate.balconyCount} Balconies
    //         </React.Fragment>
    //       }
    //     />
    //             <ListItemText sx={{maxWidth: "300px"}} primary={<div>
                
    //             </div> } />
    //             {/* <ListItemText primary={estate.title + " | "+ estate.locati on_il} /> */}
                
    //           </ListItemButton>
    //         </ListItem>
    //       })}
    //     </Table>
    //   </nav>
    // </Box>
    );
}