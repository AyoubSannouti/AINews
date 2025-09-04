import React from "react";
import { Box, Container, Grid, Typography, FormControl, InputLabel, Select, MenuItem, Button, Stack } from "@mui/material";
import * as ArticleApi from "../api/article";
import * as EventApi from "../api/event";
import { useAuth } from "../auth/AuthContext";
import { useNavigate } from "react-router-dom";
import ArticleCard from "../components/ArticleCard";
import EventCard from "../components/EventCard";

export default function Home(){
  const [articleCats, setArticleCats] = React.useState<ArticleApi.ArticleCategory[]>([]);
  const [eventCats, setEventCats] = React.useState<EventApi.EventCategory[]>([]);
  const [aCat, setACat] = React.useState<string|undefined>();
  const [eCat, setECat] = React.useState<string|undefined>();
  const [articles, setArticles] = React.useState<ArticleApi.ArticleSummary[]>([]);
  const [events, setEvents] = React.useState<EventApi.EventSummary[]>([]);
  const { isLoggedIn } = useAuth();
  const nav = useNavigate();

  React.useEffect(()=>{ ArticleApi.listCategories().then(setArticleCats); },[]);
  React.useEffect(()=>{ EventApi.listCategories().then(setEventCats); },[]);
  React.useEffect(()=>{ ArticleApi.listArticles(aCat).then(setArticles); },[aCat]);
  React.useEffect(()=>{ EventApi.listEvents(eCat).then(setEvents); },[eCat]);

 return (
    <>
      {/* Hero */}
      <Box
        sx={{
          height: 320,
          backgroundImage: "url(../assets/hero.jpg)",
          backgroundSize: "cover",
          backgroundPosition: "center",
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
          color: "#fff",
        }}
      >
        <Stack alignItems="center" spacing={1}>
          <Typography variant="h3">Stay Ahead with AINewsHub</Typography>
          <Typography>Hand-picked articles and events from the AI world.</Typography>
        </Stack>
      </Box>

      <Container sx={{ py: 4 }}>
        {/* Articles */}
        <Box sx={{ display: "flex", justifyContent: "space-between", alignItems: "center", mb: 2 }}>
          <Typography variant="h5">Articles</Typography>
          <Stack direction="row" spacing={1} alignItems="center">
            <FormControl size="small">
              <InputLabel>Category</InputLabel>
              <Select
                label="Category"
                value={aCat ?? ""}
                onChange={(e) => setACat((e.target.value as string) || undefined)}
                sx={{ minWidth: 180 }}
              >
                <MenuItem value="">
                  <em>All</em>
                </MenuItem>
                {articleCats.map((c) => (
                  <MenuItem key={c.id} value={c.id}>
                    {c.name}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
            {isLoggedIn && (
              <Button variant="outlined" onClick={() => nav("/articles/new")}>
                Add Article
              </Button>
            )}
          </Stack>
        </Box>

        <Grid container spacing={2} columns={12}>
          {articles.map((a) => (
            <Grid key={a.id} size={{ xs: 12, sm: 6, md: 4 }}>
              <ArticleCard a={a} />
            </Grid>
          ))}
        </Grid>

        {/* Events */}
        <Box sx={{ display: "flex", justifyContent: "space-between", alignItems: "center", mt: 5, mb: 2 }}>
          <Typography variant="h5">Events</Typography>
          <Stack direction="row" spacing={1} alignItems="center">
            <FormControl size="small">
              <InputLabel>Category</InputLabel>
              <Select
                label="Category"
                value={eCat ?? ""}
                onChange={(e) => setECat((e.target.value as string) || undefined)}
                sx={{ minWidth: 180 }}
              >
                <MenuItem value="">
                  <em>All</em>
                </MenuItem>
                {eventCats.map((c) => (
                  <MenuItem key={c.id} value={c.id}>
                    {c.name}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
            {isLoggedIn && (
              <Button variant="outlined" onClick={() => nav("/events/new")}>
                Add Event
              </Button>
            )}
          </Stack>
        </Box>

        <Grid container spacing={2} columns={12}>
          {events.map((ev) => (
            <Grid key={ev.id} size={{ xs: 12, sm: 6, md: 4 }}>
              {/* NOTE: prop name is `event` */}
              <EventCard event={ev} />
            </Grid>
          ))}
        </Grid>
      </Container>
    </>
  );
}