import {
  Navigate,
} from 'react-router-dom';
import { useAuth } from "./Auth";

export const ProtectedRoute = ({ children }) => {
  const { profile } = useAuth();

  if (!profile) {
    return <Navigate to="/login" replace />;
  }

  return children;
};