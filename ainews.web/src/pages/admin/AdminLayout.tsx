import React from "react";
import { Outlet, Link } from "react-router-dom";
import { Box, Container, Stack, Button, Typography } from "@mui/material";

export default function AdminLayout(){
  return (
    <Container sx={{py:3}}>
      <Typography variant="h4" gutterBottom>Admin Dashboard</Typography>
      <Stack direction="row" spacing={1} sx={{mb:2}}>
        <Button component={Link} to="/admin/article-categories">Article Categories</Button>
        <Button component={Link} to="/admin/event-categories">Event Categories</Button>
      </Stack>
      <Box><Outlet/></Box>
    </Container>
  );
}