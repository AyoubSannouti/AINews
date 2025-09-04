import axios from "axios";

export const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE ?? "https://localhost:7129",
});

api.interceptors.request.use((config) => {
  const token = localStorage.getItem("ainews.token");
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});