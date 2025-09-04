import React from "react";
import { useParams } from "react-router-dom";
import { Container, Typography, Box, Stack } from "@mui/material";
import dayjs from "dayjs";
import * as EventApi from "../api/event";
import type { EventDetail as TEventDetail } from "../api/event";

export default function EventDetail() {
  const { id } = useParams<{ id: string }>();
  const [data, setData] = React.useState<TEventDetail | null>(null);
  const [loading, setLoading] = React.useState(true);

  React.useEffect(() => {
    if (!id) return;
    EventApi.getEvent(id).then(setData).finally(() => setLoading(false));
  }, [id]);

  if (loading) return <Container sx={{ py: 4 }}>Loading...</Container>;
  if (!data) return <Container sx={{ py: 4 }}>Event not found.</Container>;

  return (
    <Container sx={{ py: 4, maxWidth: "md" }}>
      <Typography variant="h3" gutterBottom>{data.title}</Typography>

      <Stack spacing={1} direction="row" flexWrap="wrap" sx={{ color: "text.secondary" }}>
        <Typography variant="body2">by {data.createdByName || data.createdById}</Typography>
        <Typography variant="body2">• {dayjs(data.eventDate).format("MMM D, YYYY h:mm A")}</Typography>
        {data.location && <Typography variant="body2">• {data.location}</Typography>}
      </Stack>

      {data.imageUrl && (
        <Box sx={{ my: 2 }}>
          <img src={data.imageUrl} alt={data.title} style={{ width: "100%", borderRadius: 8 }} />
        </Box>
      )}

      <Typography variant="body1" sx={{ whiteSpace: "pre-wrap", mt: 2 }}>
        {data.description}
      </Typography>
    </Container>
  );
}
