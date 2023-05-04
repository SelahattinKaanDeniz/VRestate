import { useEffect } from 'react';
import { useNavigate } from "react-router-dom";
import {
  Navigate,
} from 'react-router-dom';
import img from '../images/VRestate_logo2.png'
import { useAuth } from "../utils/Auth";
import { GoogleLogin } from '@react-oauth/google';


const Login = () => {
  const { clientId, onSuccess, onFailure, profile } = useAuth();
  const navigate = useNavigate();
  useEffect(() => {
  
  })
  if (profile) {
    return <Navigate to="/" replace />;
  }

  return (
    <div className="LoginContainer">
      <div className="Container-1">
        <img src={img} alt="Person with a VR" className="image" />
      </div>
      {/* <GoogleLogout clientId={CLIENT_ID} buttonText="Log out" onLogoutSuccess={onLogOutSuccess} /> */}
      <div className="Container-1">
        <h1> Login</h1>
        <GoogleLogin
        onSuccess={onSuccess}
        onError={onFailure}
    
        />
        {/* <GoogleLogin
          clientId={clientId}
          buttonText="Sign in with Google"
          onSuccess={onSuccess}
          onFailure={onFailure}
          cookiePolicy={'single_host_origin'}
          
        /> */}
      </div>
    </div>
  );
}

export default Login;