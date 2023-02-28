import './App.css';
import ErrorPage from "./routes/ErrorPage";
import MainPage from "./routes/MainPage"
import Login from "./routes/Login"
import { AuthProvider } from "./utils/Auth";
import { ProtectedRoute } from "./utils/ProtectedRoute";
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
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
  ]);

  return (
    <AuthProvider>
      <RouterProvider router={router} />
    </AuthProvider>

  );
}

export default App;
