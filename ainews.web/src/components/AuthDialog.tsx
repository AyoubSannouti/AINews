import React from "react";
import { Dialog, DialogTitle, Tabs, Tab, Box, TextField, Button, Stack } from "@mui/material";
import { useAuth } from "../auth/AuthContext";

export default function AuthDialog({open,onClose}:{open:boolean;onClose:()=>void}){
  const [tab, setTab] = React.useState(0);
  const { login, register } = useAuth();

  const handle = async (kind:"login"|"register") => async (e:React.FormEvent<HTMLFormElement>)=>{
    e.preventDefault();
    const fd = new FormData(e.currentTarget);
    const email = String(fd.get("email"));
    const password = String(fd.get("password"));
    if (kind==="register") await register(email,password);
    else await login(email,password);
    onClose();
  };

  const AdminLoginForm = () => (
    <Box component="form" onSubmit={handle("login")} sx={{mt:2}}>
      <Stack spacing={2}>
        <TextField name="email" label="Admin Email" type="email" required />
        <TextField name="password" label="Password" type="password" required />
        <Button type="submit" variant="contained">Login as Admin</Button>
      </Stack>
    </Box>
  );

  return (
    <Dialog open={open} onClose={onClose} maxWidth="xs" fullWidth>
      <DialogTitle>Welcome</DialogTitle>
      <Tabs value={tab} onChange={(_,v)=>setTab(v)} centered>
        <Tab label="Register" /><Tab label="Login" /><Tab label="Admin" />
      </Tabs>
      <Box p={2}>
            {tab === 0 && (
              <Box component="form" onSubmit={onRegisterSubmit} sx={{ mt: 1 }}>
                <Stack spacing={2}>
                  <TextField name="firstName" label="First Name" required />
                  <TextField name="lastName" label="Last Name" required />
                  <TextField name="email" label="Email" type="email" required />
                  <TextField name="password" label="Password" type="password" required />
                  <Button type="submit" variant="contained">Create account</Button>
                </Stack>
              </Box>
            )}
        {tab===1 && (
          <Box component="form" onSubmit={handle("login")} sx={{mt:1}}>
            <Stack spacing={2}>
              <TextField name="email" label="Email" type="email" required />
              <TextField name="password" label="Password" type="password" required />
              <Button type="submit" variant="contained">Sign in</Button>
            </Stack>
          </Box>
        )}
        {tab===2 && <AdminLoginForm/>}
      </Box>
    </Dialog>
  );
}