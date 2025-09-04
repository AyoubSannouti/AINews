// src/pages/admin/EventCategories.tsx
import React, { useCallback, useEffect, useState } from "react";
import { Button, IconButton, List, ListItem, Stack, TextField } from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import SaveIcon from "@mui/icons-material/Save";
import {
  listEventCategories,
  createEventCategory,
  updateEventCategory,
  deleteEventCategory,
} from "../../api/category";

type Cat = { id: string; name: string };

export default function EventCategories() {
  const [cats, setCats] = useState<Cat[]>([]);
  const [name, setName] = useState("");

  const load = useCallback(async () => {
    const data = await listEventCategories();
    setCats(data);
  }, []);

  useEffect(() => {
    void load();     // don't return a Promise from an effect
  }, [load]);

  const create = async () => {
    if (!name.trim()) return;
    await createEventCategory(name.trim());
    setName("");
    await load();
  };

  const save = async (c: Cat) => {
    await updateEventCategory(c.id, c.name);
    await load();
  };

  const remove = async (id: string) => {
    await deleteEventCategory(id);
    await load();
  };

  return (
    <Stack spacing={2}>
      <Stack direction="row" spacing={1}>
        <TextField
          size="small"
          label="New event category"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <Button variant="contained" onClick={create}>Add</Button>
      </Stack>

      <List dense>
        {cats.map((c, i) => (
          <ListItem
            key={c.id}
            disableGutters
            secondaryAction={
              <Stack direction="row" spacing={1}>
                <IconButton onClick={() => save(c)}><SaveIcon /></IconButton>
                <IconButton onClick={() => remove(c.id)}><DeleteIcon /></IconButton>
              </Stack>
            }
          >
            <TextField
              size="small"
              value={c.name}
              onChange={(e) =>
                setCats((arr) => arr.map((x, idx) => (idx === i ? { ...x, name: e.target.value } : x)))
              }
            />
          </ListItem>
        ))}
      </List>
    </Stack>
  );
}
