import { Avatar } from "@mui/material";
import { useAuth } from "../utils/Auth";

const UserAvatar = ({width, height, text}) =>{
    const {profile} = useAuth();
    const avatar= profile.name[0]+profile.surname[0];

    return(
        <Avatar sx={{width:width, height:height, bgcolor:"#758DFB", fontSize:text}} >{avatar}</Avatar>
    );
}

export default UserAvatar;