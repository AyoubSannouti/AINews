import { api } from "./client";
export const createArticleCategory = (name:string)=>api.post("/api/article-categories",{name});
export const updateArticleCategory = (id:string,name:string)=>api.put(`/api/article-categories/${id}`,{name});
export const deleteArticleCategory = (id:string)=>api.delete(`/api/article-categories/${id}`);
export const createEventCategory   = (name:string)=>api.post("/api/event-categories",{name});
export const updateEventCategory   = (id:string,name:string)=>api.put(`/api/event-categories/${id}`,{name});
export const deleteEventCategory   = (id:string)=>api.delete(`/api/event-categories/${id}`);
