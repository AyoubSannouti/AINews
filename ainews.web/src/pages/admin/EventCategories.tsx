import React from "react";
import { TextField, Button, Stack, List, ListItem, ListItemSecondaryAction, IconButton } from "@mui/material";
import * as EventApi from "../../api/event";
import * as CatApi from "../../api/category";
import DeleteIcon from "@mui/icons-material/Delete";
import SaveIcon from "@mui/icons-material/Save";

export default function EventCategories(){
  const [cats,setCats]=React.useState<EventApi.EventCategory[]>([]);
  const [name,setName]=React.useState("");
  const load=()=>EventApi.listCategories().then(setCats);
  React.useEffect(load,[]);

  return (
    <Stack spacing={2}>
      <Stack direction="row" spacing={1}>
        <TextField size="small" label="New category" value={name} onChange={e=>setName(e.target.value)} />
        <Button variant="contained" onClick={()=>CatApi.createEventCategory(name).then(()=>{setName("");load();})}>Add</Button>
      </Stack>
      <List>
        {cats.map(c=>(
          <ListItem key={c.id} disableGutters secondaryAction={
            <>
              <IconButton onClick={()=>CatApi.updateEventCategory(c.id,c.name).then(load)}><SaveIcon/></IconButton>
              <IconButton onClick={()=>CatApi.deleteEventCategory(c.id).then(load)}><DeleteIcon/></IconButton>
            </>
          }>
            <TextField size="small" value={c.name} onChange={e=>setCats(x=>x.map(y=>y.id===c.id?{...y,name:e.target.value}:y))}/>
          </ListItem>
        ))}
      </List>
    </Stack>
  );
}
