import './App.css';
import { useEffect, useState } from 'react'
import { GoogleLogin, GoogleLogout } from 'react-google-login';
import { gapi } from 'gapi-script';
import img from './images/vr_img.png';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
function App() {

  const [profile, setProfile] = useState(null);

  const CLIENT_ID = "274099276048-43j68lpe4k7penrqkttnmrj10bjd9r3q.apps.googleusercontent.com";

  useEffect(() => {
    const initClient = () => {
      gapi.client.init({
        clientId: CLIENT_ID,
        scope: ''
      });
    };
    gapi.load('client:auth2', initClient);
  })

  const onSuccess = (res) => {
    console.log(res);
    setProfile(res.profileObj)
  };
  const onFailure = (err) => {
    console.log('failed:', err);
  };


  const onLogOutSuccess = (res) => {
    setProfile(null);
  };

  return (
    <div>
      {
        profile ?
          <div>Logged IN</div> :
          <div className="App">
            <div className="Container-1">
              <img src={img} alt="Person with a VR" className="image" />
            </div>
              {/* <GoogleLogout clientId={CLIENT_ID} buttonText="Log out" onLogoutSuccess={onLogOutSuccess} /> */}
            <div className="Container-1">
              <h1> VRestate</h1>
              <GoogleLogin
                clientId={CLIENT_ID}
                buttonText="Sign in with Google"
                onSuccess={onSuccess}
                onFailure={onFailure}
                cookiePolicy={'single_host_origin'}
                isSignedIn={true}
              />
            </div>
            
          </div>
      }
    </div>
  );
}

export default App;
