import { api } from "./client";
export type EventCategory = { id: string; name: string };
export type EventSummary = { id:string; title:string; imageUrl?:string; description:string; createdByName?:string; createdById:string; eventDate:string; location?:string; categoryId:string };
export type EventDetail = EventSummary;

export const listCategories = () => api.get<EventCategory[]>("/api/event-categories").then(r=>r.data);
export const listEvents = (categoryId?:string) =>
  api.get<EventSummary[]>("/api/events", { params: { categoryId }}).then(r=>r.data);
export const getEvent   = (id:string) => api.get<EventDetail>(`/api/events/${id}`).then(r=>r.data);
export const createEvent = (body: {title:string;description:string;imageUrl?:string;location?:string;eventDate:string;categoryId:string}) =>
  api.post("/api/events", body).then(r=>r.data);
