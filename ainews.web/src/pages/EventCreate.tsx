import React from "react";
import {
  Container, TextField, Button, Stack, Typography, FormControl, InputLabel, Select, MenuItem,
} from "@mui/material";
import { useNavigate } from "react-router-dom";
import * as EventApi from "../api/event";
import type { EventCategory } from "../api/event";

export default function EventCreate() {
  const nav = useNavigate();
  const [title, setTitle] = React.useState("");
  const [description, setDescription] = React.useState("");
  const [imageUrl, setImageUrl] = React.useState("");
  const [location, setLocation] = React.useState("");
  const [eventDate, setEventDate] = React.useState("");         // HTML datetime-local value
  const [categoryId, setCategoryId] = React.useState("");
  const [cats, setCats] = React.useState<EventCategory[]>([]);
  const [saving, setSaving] = React.useState(false);

  React.useEffect(() => {
    EventApi.listCategories().then(setCats);
  }, []);

  const submit: React.FormEventHandler<HTMLFormElement> = (e) => {
    e.preventDefault();
    setSaving(true);
    const isoDate = new Date(eventDate).toISOString();          // convert to ISO for API
    EventApi.createEvent({
      title, description, imageUrl: imageUrl || undefined, location: location || undefined,
      eventDate: isoDate, categoryId
    })
      .then(() => nav("/"))
      .finally(() => setSaving(false));
  };

  return (
    <Container sx={{ py: 4, maxWidth: "sm" }}>
      <Typography variant="h4" gutterBottom>Create Event</Typography>
      <Stack component="form" spacing={2} onSubmit={submit}>
        <TextField label="Title" value={title} onChange={(e) => setTitle(e.target.value)} required />
        <FormControl fullWidth>
          <InputLabel>Category</InputLabel>
          <Select label="Category" value={categoryId} onChange={(e) => setCategoryId(String(e.target.value))} required>
            {cats.map((c) => <MenuItem key={c.id} value={c.id}>{c.name}</MenuItem>)}
          </Select>
        </FormControl>
        <TextField label="Event Date" type="datetime-local" value={eventDate} onChange={(e) => setEventDate(e.target.value)} required />
        <TextField label="Location" value={location} onChange={(e) => setLocation(e.target.value)} />
        <TextField label="Image URL" value={imageUrl} onChange={(e) => setImageUrl(e.target.value)} />
        <TextField label="Description" value={description} onChange={(e) => setDescription(e.target.value)} multiline rows={6} required />
        <Stack direction="row" gap={1}>
          <Button type="submit" variant="contained" disabled={saving}>Publish</Button>
          <Button variant="outlined" onClick={() => nav(-1)}>Cancel</Button>
        </Stack>
      </Stack>
    </Container>
  );
}
