import './App.css';
import { useEffect, useState, createContext } from 'react'
import { GoogleLogin, GoogleLogout } from 'react-google-login';
import ErrorPage from "./routes/ErrorPage";
import MainPage from "./routes/MainPage"
import Login from "./routes/Login"
import { AuthProvider } from "./utils/Auth";
import { ProtectedRoute } from "./utils/ProtectedRoute";
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
function App() {

  const router = createBrowserRouter([
    {
      path: "/",
      element: <ProtectedRoute>
          <MainPage />
        </ProtectedRoute>,
      errorElement: <ErrorPage />
    },
    {
      path: "/login",
      element: <Login />,
      errorElement: <ErrorPage />
    },
  ]);

  return (
    <AuthProvider>
      <RouterProvider router={router} />
    </AuthProvider>

  );
}

export default App;
