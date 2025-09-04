import { api } from "./client";
export type ArticleCategory = { id: string; name: string };
export type ArticleSummary = { id:string; title:string; imageUrl?:string; summary:string; authorName?:string; authorId:string; publishedDate:string; categoryId:string };
export type ArticleDetail = ArticleSummary & { content: string };

export const listCategories = () => api.get<ArticleCategory[]>("/api/ArticleCategory/all").then(r=>r.data);
export const listArticles = (categoryId?:string) =>
  api.get<ArticleSummary[]>("/api/Article/all", { params: { categoryId }}).then(r=>r.data);
export const getArticle   = (id:string) => api.get<ArticleDetail>(`/api/Article/${id}`).then(r=>r.data);
export const createArticle = (body: {title:string;content:string;imageUrl?:string;categoryId:string}) =>
  api.post("/api/Article", body).then(r=>r.data);
