import './App.css';
import ErrorPage from "./routes/ErrorPage";
import MainPage from "./routes/MainPage";
import EstatePage from "./routes/EstatePage";
import Login from "./routes/Login"
import { AuthProvider } from "./utils/Auth";
import { ProtectedRoute } from "./utils/ProtectedRoute";
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.css';import { ThemeProvider, createTheme } from '@mui/material/styles';
function App() {

  const router = createBrowserRouter([
    {
      exact: true,
      path: "/",
      element: <ProtectedRoute>
          <MainPage />
        </ProtectedRoute>,
      errorElement: <ErrorPage />
    },
    {
      exact: true,
      path: "/login",
      element: <Login />,
      errorElement: <ErrorPage />
    },
    {
      path: "/estate/:id",
      element: <EstatePage />,
      errorElement: <ErrorPage />
    },
  ]);
  const theme = createTheme({
    typography: {
      allVariants: {
        fontFamily: 'Inter, sans-serif',
        textTransform: 'none',
        // color: '#0A1551'
      },
    },
  });
  
  return (
    <ThemeProvider  theme={theme}>
    <AuthProvider>
      <RouterProvider router={router} />
    </AuthProvider>
  </ThemeProvider>
    

  );
}

export default App;
