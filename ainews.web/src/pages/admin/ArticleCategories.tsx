/* eslint-disable @typescript-eslint/no-unused-vars */
// src/pages/admin/ArticleCategories.tsx
import React, { useCallback, useEffect, useState } from "react";
import {
  Button, IconButton, List, ListItem, ListItemSecondaryAction,
  Stack, TextField
} from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import SaveIcon from "@mui/icons-material/Save";
import {
  listArticleCategories,
  createArticleCategory,
  updateArticleCategory,
  deleteArticleCategory,
} from "../../api/category"; 

import * as CatApi from "../../api/category";
type Cat = { id: string; name: string };

export default function ArticleCategories() {
  const [cats, setCats] = useState<Cat[]>([]);
  const [name, setName] = useState("");

  const load = useCallback(async () => {
    const data = await CatApi.listArticleCategories(); // or listCategories()
    setCats(data);
  }, []);

 useEffect(() => {
  (async () => {
    const data = await listArticleCategories();
    setCats(data);
  })();
}, []);

const create = async () => {
  if (!name.trim()) return;
  await createArticleCategory(name.trim());
  setName("");
  const data = await listArticleCategories();
  setCats(data);
};

const save = async (c: Cat) => {
  await updateArticleCategory(c.id, c.name);
  const data = await listArticleCategories();
  setCats(data);
};

const remove = async (id: string) => {
  await deleteArticleCategory(id);
  const data = await listArticleCategories();
  setCats(data);
};

console.log("CatApi keys:", Object.keys(CatApi));

  return (
    <Stack spacing={2}>
      <Stack direction="row" spacing={1}>
        <TextField
          size="small"
          label="New category"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <Button variant="contained" onClick={create}>Add</Button>
      </Stack>

      <List dense>
        {cats.map((c, i) => (
          <ListItem key={c.id} disableGutters
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
                setCats((arr) => arr.map((x, idx) => idx === i ? { ...x, name: e.target.value } : x))
              }
            />
          </ListItem>
        ))}
      </List>
    </Stack>
  );
}
