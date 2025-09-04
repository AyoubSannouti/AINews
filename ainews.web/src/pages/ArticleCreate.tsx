import React from "react";
import {
  Container, TextField, Button, Stack, Typography, FormControl, InputLabel, Select, MenuItem,
} from "@mui/material";
import { useNavigate } from "react-router-dom";
import * as ArticleApi from "../api/article";
import type { ArticleCategory } from "../api/article";

export default function ArticleCreate() {
  const nav = useNavigate();
  const [title, setTitle] = React.useState("");
  const [content, setContent] = React.useState("");
  const [imageUrl, setImageUrl] = React.useState("");
  const [categoryId, setCategoryId] = React.useState("");
  const [cats, setCats] = React.useState<ArticleCategory[]>([]);
  const [saving, setSaving] = React.useState(false);

  React.useEffect(() => {
    ArticleApi.listCategories().then(setCats);
  }, []);

  const submit: React.FormEventHandler<HTMLFormElement> = (e) => {
    e.preventDefault();
    setSaving(true);
    ArticleApi.createArticle({ title, content, imageUrl: imageUrl || undefined, categoryId })
      .then(() => nav("/"))
      .finally(() => setSaving(false));
  };

  return (
    <Container sx={{ py: 4, maxWidth: "sm" }}>
      <Typography variant="h4" gutterBottom>Create Article</Typography>
      <Stack component="form" spacing={2} onSubmit={submit}>
        <TextField label="Title" value={title} onChange={(e) => setTitle(e.target.value)} required />
        <FormControl fullWidth>
          <InputLabel>Category</InputLabel>
          <Select label="Category" value={categoryId} onChange={(e) => setCategoryId(String(e.target.value))} required>
            {cats.map((c) => <MenuItem key={c.id} value={c.id}>{c.name}</MenuItem>)}
          </Select>
        </FormControl>
        <TextField label="Image URL" value={imageUrl} onChange={(e) => setImageUrl(e.target.value)} />
        <TextField label="Content" value={content} onChange={(e) => setContent(e.target.value)} multiline rows={8} required />
        <Stack direction="row" gap={1}>
          <Button type="submit" variant="contained" disabled={saving}>Publish</Button>
          <Button variant="outlined" onClick={() => nav(-1 as any)}>Cancel</Button>
        </Stack>
      </Stack>
    </Container>
  );
}
