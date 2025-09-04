import React from "react";
import { Navigate } from "react-router-dom";
import { useAuth } from "./AuthContext";

export const RequireAuth: React.FC<{children: JSX.Element}> = ({children}) => {
  const { isLoggedIn, loading } = useAuth();
  if (loading) return null;
  return isLoggedIn ? children : <Navigate to="/" replace />;
};

export const RequireAdmin: React.FC<{children: JSX.Element}> = ({children}) => {
  const { isAdmin, loading } = useAuth();
  if (loading) return null;
  return isAdmin ? children : <Navigate to="/" replace />;
};