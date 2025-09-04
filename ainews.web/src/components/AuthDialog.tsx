import React from "react";
import { Dialog, DialogTitle, Tabs, Tab, Box, TextField, Button, Stack } from "@mui/material";
import { useAuth } from "../auth/AuthContext";

export default function AuthDialog({
  open,
  onClose,
}: {
  open: boolean;
  onClose: () => void;
}) {
  const [tab, setTab] = React.useState(0);
  const { login, register } = useAuth();

  // ---- submit handlers (return void, not Promise) ----
  const onLoginSubmit: React.FormEventHandler<HTMLFormElement> = (e) => {
    e.preventDefault();
    const fd = new FormData(e.currentTarget);
    const email = String(fd.get("email") ?? "");
    const password = String(fd.get("password") ?? "");
    login(email, password).then(onClose).catch(() => {});
  };

  const onRegisterSubmit: React.FormEventHandler<HTMLFormElement> = (e) => {
    e.preventDefault();
    const fd = new FormData(e.currentTarget);
    const firstName = String(fd.get("firstName") ?? "");
    const lastName  = String(fd.get("lastName") ?? "");
    const email     = String(fd.get("email") ?? "");
    const password  = String(fd.get("password") ?? "");
    // NOTE: make sure AuthContext.register(email, password, firstName, lastName) is implemented
    register(email, password, firstName, lastName).then(onClose).catch(() => {});
  };

  const onAdminSubmit: React.FormEventHandler<HTMLFormElement> = (e) => {
    e.preventDefault();
    const fd = new FormData(e.currentTarget);
    const email = String(fd.get("email") ?? "");
    const password = String(fd.get("password") ?? "");
    login(email, password).then(onClose).catch(() => {});
  };

  const AdminLoginForm = () => (
    <Box component="form" onSubmit={onAdminSubmit} sx={{ mt: 2 }}>
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
      <Tabs value={tab} onChange={(_, v) => setTab(v)} centered>
        <Tab label="Register" />
        <Tab label="Login" />
        <Tab label="Admin" />
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

        {tab === 1 && (
          <Box component="form" onSubmit={onLoginSubmit} sx={{ mt: 1 }}>
            <Stack spacing={2}>
              <TextField name="email" label="Email" type="email" required />
              <TextField name="password" label="Password" type="password" required />
              <Button type="submit" variant="contained">Sign in</Button>
            </Stack>
          </Box>
        )}

        {tab === 2 && <AdminLoginForm />}
      </Box>
    </Dialog>
  );
}
