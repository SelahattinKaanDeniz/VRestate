import { createContext, useContext, useState } from "react";
import { useLocalStorage } from "./useLocalStorage";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const CLIENT_ID = "274099276048-43j68lpe4k7penrqkttnmrj10bjd9r3q.apps.googleusercontent.com";
  const [profile, setProfile] = useLocalStorage("user", null);


  const onSuccess = async (res) => {
    console.log(res);
    setProfile(res.profileObj);
    let profile = {
      id:res.googleId,
      name: res.profileObj.givenName,
      surname: res.profileObj.familyName,
      mail: res.profileObj.email
    };
    const response = await fetch("http://localhost:5002/login", { // LOOK CORS POLICY!
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
    clientId: CLIENT_ID,
  }


  return (
    <AuthContext.Provider value={value}>
      {children}
    </AuthContext.Provider>
  )
};

export const useAuth = () => {
  return useContext(AuthContext);
};