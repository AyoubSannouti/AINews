// src/api/category.ts
import { api } from "./client";

// ---- types
export type ArticleCategory = { id: string; name: string };
export type EventCategory   = { id: string; name: string };

// ---- Article Category endpoints
export const listArticleCategories = () =>
  api.get<ArticleCategory[]>("/api/ArticleCategory/all").then(r => r.data);

export const createArticleCategory = (name: string) =>
  api.post("/api/ArticleCategory", { name }).then(r => r.data);

export const updateArticleCategory = (id: string, name: string) =>
  api.put(`/api/ArticleCategory/${id}`, { name }).then(r => r.data);

export const deleteArticleCategory = (id: string) =>
  api.delete(`/api/ArticleCategory/${id}`).then(r => r.data);

// ---- Event Category endpoints (for the other admin tab/page if needed)
export const listEventCategories = () =>
  api.get<EventCategory[]>("/api/EventCategory/all").then(r => r.data);

export const createEventCategory = (name: string) =>
  api.post("/api/EventCategory", { name }).then(r => r.data);

export const updateEventCategory = (id: string, name: string) =>
  api.put(`/api/EventCategory/${id}`, { name }).then(r => r.data);

export const deleteEventCategory = (id: string) =>
  api.delete(`/api/EventCategory/${id}`).then(r => r.data);
