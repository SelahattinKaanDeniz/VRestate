import { useEffect } from 'react';
import { GoogleLogin } from 'react-google-login';
import { gapi } from 'gapi-script';
import { useNavigate } from "react-router-dom";
import {
  Navigate,
} from 'react-router-dom';
import img from '../images/vr_img.png';
import { useAuth } from "../utils/Auth";


const Login = () => {
  const { clientId, onSuccess, onFailure, profile } = useAuth();
  const navigate = useNavigate();
  useEffect(() => {
    const initClient = () => {
      gapi.client.init({
        clientId: clientId,
        scope: ''
      });
    };
    gapi.load('client:auth2', initClient);
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
        <h1> VRestate</h1>
        <GoogleLogin
          clientId={clientId}
          buttonText="Sign in with Google"
          onSuccess={onSuccess}
          onFailure={onFailure}
          cookiePolicy={'single_host_origin'}
          
        />
      </div>
    </div>
  );
}

export default Login;