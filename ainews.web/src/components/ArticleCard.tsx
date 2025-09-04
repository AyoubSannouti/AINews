import { Card, CardActionArea, CardContent, CardMedia, Typography } from "@mui/material";
import dayjs from "dayjs";
import type { ArticleSummary } from "../api/article";
import { useNavigate } from "react-router-dom";

export default function ArticleCard({a}:{a:ArticleSummary}){
  const nav = useNavigate();
  return (
    <Card>
      <CardActionArea onClick={()=>nav(`/articles/${a.id}`)}>
        {a.imageUrl && <CardMedia component="img" height="140" image={a.imageUrl} />}
        <CardContent>
          <Typography variant="h6">{a.title}</Typography>
          <Typography variant="body2" color="text.secondary">{a.summary}</Typography>
          <Typography variant="caption" display="block">
            by {a.authorName || a.authorId} • {dayjs(a.publishedDate).format("MMM D, YYYY")}
          </Typography>
        </CardContent>
      </CardActionArea>
    </Card>
  );
}
