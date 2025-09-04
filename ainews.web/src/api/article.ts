import { api } from "./client";
export type ArticleCategory = { id: string; name: string };
export type ArticleSummary = { id:string; title:string; imageUrl?:string; summary:string; authorName?:string; authorId:string; publishedDate:string; categoryId:string };
export type ArticleDetail = ArticleSummary & { content: string };

export const listCategories = () => api.get<ArticleCategory[]>("/api/article-categories").then(r=>r.data);
export const listArticles = (categoryId?:string) =>
  api.get<ArticleSummary[]>("/api/articles", { params: { categoryId }}).then(r=>r.data);
export const getArticle   = (id:string) => api.get<ArticleDetail>(`/api/articles/${id}`).then(r=>r.data);
export const createArticle = (body: {title:string;content:string;imageUrl?:string;categoryId:string}) =>
  api.post("/api/articles", body).then(r=>r.data);
