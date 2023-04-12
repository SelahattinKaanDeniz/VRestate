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
  useEffect( ()=>{
    async function fetchEstates(isMyEstates){
      fetch("http://localhost:5002/estate/getEstates?detail=true&user=true")
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
        setEstates((oldEstates)=>[...oldEstates,...myEstates]);
       }
       else{
         setEstates((oldEstates)=>[...oldEstates,...arrEstates]);
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
    async function fetchHepsiEmlak(){
      fetch("http://vrestate.tech:5002/estate/getEstatesH").then(
        (response)=> response.json()
      ).then(
        (emlakEstates)=>{
          setEstates([...estates,...emlakEstates.results]);
        }
      );
    }
    if(!myEstates){
      fetchEstates(false);
      fetchHepsiEmlak();
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
    {
      field:"Image",
      headerName:"",
      editable:"false",
      disableColumnMenu:true,
      sortable:false,
      flex:0.5,
      renderCell: (params)=>{
        const estate= params.row;
        if(estate.image){
          return <Image style={{ maxHeight:"120px", maxWidth:"120px"}} src={estate.image} rounded={true}/>
        }
        else if(estate.head_photo_url){
           return <Image style={{ maxHeight:"120px", maxWidth:"120px"}} src={estate.head_photo_url} rounded={true}/>
        }
        else{
          return <ListItemIcon style={{flexBasis:"20%", display:"flex", alignItems:"center",justifyContent:"center"}}>
          <CorporateFareIcon />
         </ListItemIcon>
        }
      },
    },
    {
      field:"title",
      headerName:"Title",
      editable:"false",
      renderCell: (params)=>{
        const estate= params.row;
        return(
         <ListItemText  primaryTypographyProps={ { style: { whiteSpace: "normal" } }}
          primary={<div style={{color:"#758DFB"}}>
            {estate.title}
            <div>{estate.type=="HepsiEmlak"?"₺":"$"}{estate.price}</div>
            <div>{estate.m2}m², {estate.room_type} </div>
            <div></div>
          </div>}
          secondary={
            estate.type=="HepsiEmlak" ? <></> :
            <React.Fragment>
            
              With {estate.bathroomCount} Bathrooms, {estate.balconyCount} Balconies
            </React.Fragment>
          }
        />
        )
      },
      flex:2
    },


    {
      field:"Price",
      editable:"false",
      flex:0.5,
      valueGetter: (a)=>`${a.row.type=="HepsiEmlak"?"₺":"$"}${a.row.price}`
    },
    {
      field:"M²",
      editable:"false",
      flex:0.5,
      valueGetter: (a)=>`${a.row.m2}m²`
    },
    {
      field:"City",
      editable:"false",
      flex:0.5,
      valueGetter: (a)=>a.row.location_il ? `${a.row.location_il}`: "-"
    },
    {
      field:"Estate Type",
      editable:"false",
      flex:0.5,
      valueGetter: (a)=>a.row.estate_type=="Satılık"?"Sale":"Rent"
    },
    {
      field:"Listed By",
      editable:"false",
      flex:1,
      valueGetter: (a)=> (a.row.name && a.row.surname) ?`${a.row.name} ${a.row.surname}`:"-"
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
        estate.type=="HepsiEmlak" ? <Button onClick={() => navigate(estate.url)} > Go Hepsi Emlak Page</Button>: <Button onClick={() => navigate(`/estate/${estate.id}`, {state:{estate}})} > Go Details</Button>
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
    );
}