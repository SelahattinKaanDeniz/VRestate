import './App.css';
import ErrorPage from "./routes/ErrorPage";
import MainPage from "./routes/MainPage";
import EstatePage from "./routes/EstatePage";
import CreateEstatePage from "./routes/CreateEstatePage";
import Login from "./routes/Login"
import { AuthProvider } from "./utils/Auth";
import { ProtectedRoute } from "./utils/ProtectedRoute";
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.css';import { ThemeProvider, createTheme } from '@mui/material/styles';
import SuccessPage from './routes/SuccessPage';
import Estate from './routes/MyEstatesPage';
import ProfilePage from './routes/ProfilePage';
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
      element: <ProtectedRoute>
        <EstatePage />
      </ProtectedRoute>,
      errorElement: <ErrorPage />
    },
    {
      path: "/create",
      element: <ProtectedRoute>
        <CreateEstatePage />
      </ProtectedRoute>,
      errorElement: <ErrorPage />
    },
    {
      path: "/success",
      element: <ProtectedRoute>
        <SuccessPage />
      </ProtectedRoute>,
      errorElement: <ErrorPage />
    },
    {
      path: "/estates",
      element: <ProtectedRoute>
        <Estate />
      </ProtectedRoute>,
      errorElement: <ErrorPage />
    },
    {
      path: "/profile",
      element: <ProtectedRoute>
        <ProfilePage />
      </ProtectedRoute>,
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
