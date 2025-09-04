import { Card, CardActionArea, CardContent, CardMedia, Typography } from "@mui/material";
import dayjs from "dayjs";
import type { EventSummary } from "../api/event";
import { useNavigate } from "react-router-dom";

export default function EventCard({a}:{a:EventSummary}){
  const nav = useNavigate();
  return (
    <Card>
      <CardActionArea onClick={()=>nav(`/events/${a.id}`)}>
        {a.imageUrl && <CardMedia component="img" height="140" image={a.imageUrl} />}
        <CardContent>
          <Typography variant="h6">{a.title}</Typography>
          <Typography variant="body2" color="text.secondary">{a.summary}</Typography>
          <Typography variant="caption" display="block">
            by {a.createdByName || a.createdById} • {dayjs(a.eventDate).format("MMM D, YYYY")}
          </Typography>
        </CardContent>
      </CardActionArea>
    </Card>
  );
}
