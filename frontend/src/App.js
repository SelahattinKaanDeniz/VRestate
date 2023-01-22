import './App.css';
import { useEffect } from 'react'
import { GoogleLogin } from 'react-google-login';
import { gapi } from 'gapi-script';

function App() {

  const CLIENT_ID = "274099276048-43j68lpe4k7penrqkttnmrj10bjd9r3q.apps.googleusercontent.com";

  useEffect(()=>{
    const initClient = () => {
      gapi.client.init({
      clientId: CLIENT_ID,
      scope: ''
      });
    };
  gapi.load('client:auth2', initClient);
  })

  const onSuccess = (res) => {
    console.log('success:', res);
};
const onFailure = (err) => {
    console.log('failed:', err);
};

  return (
    <div className="App">
      Hello World from APP!
      <GoogleLogin
          clientId={CLIENT_ID}
          buttonText="Sign in with Google"
          onSuccess={onSuccess}
          onFailure={onFailure}
          cookiePolicy={'single_host_origin'}
          isSignedIn={true}
      />
    </div>
  );
}

export default App;
