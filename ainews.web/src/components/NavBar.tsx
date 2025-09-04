import React from "react";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import AuthDialog from "./AuthDialog";
import { useAuth } from "../auth/AuthContext";
import { Link } from "react-router-dom";

export default function Navbar(){
  const [open, setOpen] = React.useState(false);
  const { isLoggedIn, isAdmin, logout } = useAuth();

  return (
    <>
      <AppBar position="fixed">
        <Toolbar>
          <Typography variant="h6" component={Link} to="/" color="inherit" sx={{textDecoration:"none"}}>
            AINewsHub
          </Typography>
          <Box sx={{flexGrow:1}} />
          {isAdmin && <Button color="inherit" component={Link} to="/admin">Admin</Button>}
          {isLoggedIn ? (
            <Button color="inherit" onClick={logout}>Logout</Button>
          ) : (
            <Button color="inherit" onClick={()=>setOpen(true)}>Join us</Button>
          )}
        </Toolbar>
      </AppBar>
      <Toolbar /> {/* offset */}
      <AuthDialog open={open} onClose={()=>setOpen(false)} />
    </>
  );
}