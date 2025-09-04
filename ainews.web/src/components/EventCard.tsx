import { Card, CardActionArea, CardContent, CardMedia, Typography } from "@mui/material";
import dayjs from "dayjs";
import type { EventSummary } from "../api/event";
import { useNavigate } from "react-router-dom";

type Props = { event: EventSummary };

export default function EventCard({ event }: Props) {
  const nav = useNavigate();
  if (!event) return null; // safety

  return (
    <Card>
      <CardActionArea onClick={() => nav(`/events/${event.id}`)}>
        {event.imageUrl && (
          <CardMedia component="img" height="140" image={event.imageUrl} alt={event.title} />
        )}
        <CardContent>
          <Typography variant="h6">{event.title}</Typography>
          <Typography variant="body2" color="text.secondary">
            {event.description}
          </Typography>
          <Typography variant="caption" display="block">
            by {event.createdByName || event.createdById} • {dayjs(event.eventDate).format("MMM D, YYYY")}
          </Typography>
        </CardContent>
      </CardActionArea>
    </Card>
  );
}
