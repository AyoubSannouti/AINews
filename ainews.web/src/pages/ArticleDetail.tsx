import React from "react";
import { useParams } from "react-router-dom";
import { Container, Typography, Box } from "@mui/material";
import dayjs from "dayjs";
import * as ArticleApi from "../api/article";
import type { ArticleDetail as TArticleDetail } from "../api/article";

export default function ArticleDetail() {
  const { id } = useParams<{ id: string }>();
  const [data, setData] = React.useState<TArticleDetail | null>(null);
  const [loading, setLoading] = React.useState(true);

  React.useEffect(() => {
    if (!id) return;
    ArticleApi.getArticle(id).then(setData).finally(() => setLoading(false));
  }, [id]);

  if (loading) return <Container sx={{ py: 4 }}>Loading...</Container>;
  if (!data) return <Container sx={{ py: 4 }}>Article not found.</Container>;

  return (
    <Container sx={{ py: 4, maxWidth: "md" }}>
      <Typography variant="h3" gutterBottom>{data.title}</Typography>
      <Typography variant="body2" color="text.secondary" gutterBottom>
        by {data.authorName || data.authorId} • {dayjs(data.publishedDate).format("MMM D, YYYY")}
      </Typography>
      {data.imageUrl && (
        <Box sx={{ my: 2 }}>
          <img src={data.imageUrl} alt={data.title} style={{ width: "100%", borderRadius: 8 }} />
        </Box>
      )}
      <Typography variant="body1" sx={{ whiteSpace: "pre-wrap", mt: 2 }}>
        {data.content}
      </Typography>
    </Container>
  );
}
