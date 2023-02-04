import { createContext, useContext, useState } from "react";
import { useLocalStorage } from "./useLocalStorage";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const CLIENT_ID = "274099276048-43j68lpe4k7penrqkttnmrj10bjd9r3q.apps.googleusercontent.com";
  const [profile, setProfile] = useLocalStorage("user", null);


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