import React from "react";
import { TextField, Button, Stack, List, ListItem, ListItemSecondaryAction, IconButton } from "@mui/material";
import * as ArticleApi from "../../api/article";
import * as CatApi from "../../api/category";
import DeleteIcon from "@mui/icons-material/Delete";
import SaveIcon from "@mui/icons-material/Save";

export default function ArticleCategories(){
  const [cats,setCats]=React.useState<ArticleApi.ArticleCategory[]>([]);
  const [name,setName]=React.useState("");
  const load=()=>ArticleApi.listCategories().then(setCats);
  React.useEffect(load,[]);

  return (
    <Stack spacing={2}>
      <Stack direction="row" spacing={1}>
        <TextField size="small" label="New category" value={name} onChange={e=>setName(e.target.value)} />
        <Button variant="contained" onClick={()=>CatApi.createArticleCategory(name).then(()=>{setName("");load();})}>Add</Button>
      </Stack>
      <List>
        {cats.map(c=>(
          <ListItem key={c.id} disableGutters secondaryAction={
            <>
              <IconButton onClick={()=>CatApi.updateArticleCategory(c.id,c.name).then(load)}><SaveIcon/></IconButton>
              <IconButton onClick={()=>CatApi.deleteArticleCategory(c.id).then(load)}><DeleteIcon/></IconButton>
            </>
          }>
            <TextField size="small" value={c.name} onChange={e=>setCats(x=>x.map(y=>y.id===c.id?{...y,name:e.target.value}:y))}/>
          </ListItem>
        ))}
      </List>
    </Stack>
  );
}
