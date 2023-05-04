import { createContext, useContext, useState } from "react";
import { useLocalStorage } from "./useLocalStorage";
import { GoogleOAuthProvider } from '@react-oauth/google';
import jwt_decode from 'jwt-decode';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const CLIENT_ID = "274099276048-43j68lpe4k7penrqkttnmrj10bjd9r3q.apps.googleusercontent.com";
  const [profile, setProfile] = useLocalStorage("user", null);

  // success on login
  const onSuccess = async (res) => {
  
    const profile_information = jwt_decode(res.credential)
    console.log(jwt_decode(res.credential))
    let profile = {
      id:profile_information.sub,
      name: profile_information.given_name,
      surname: profile_information.family_name,
      mail: profile_information.email,
      other: profile_information,
    };
    setProfile(profile);
    console.log(profile);
    const response = await fetch("http://http://vrestate.tech:5002/login", { // LOOK CORS POLICY!
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(profile)
    }).then((a)=>{
      console.log("adadad");
      console.log(a);
    }).catch(e=>{console.log(e)});
  };


  const onFailure = (err) => {
    console.log('failed:', err);
  };


  const onLogOutSuccess = (res) => {
    setProfile(null);
  };

  const value = {
    profile,
    onSuccess: onSuccess,
    onFailure: onFailure,
    onLogOutSuccess: onLogOutSuccess,
  }


  return (
    <GoogleOAuthProvider clientId={CLIENT_ID}>
      <AuthContext.Provider value={value}>
        {children}
      </AuthContext.Provider>
    </GoogleOAuthProvider>
    
  )
};

export const useAuth = () => {
  return useContext(AuthContext);
};