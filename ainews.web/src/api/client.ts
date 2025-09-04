import axios from "axios";

export const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE ?? "https://localhost:7129",


});

api.interceptors.request.use((config) => {
  const token = localStorage.getItem("ainews.token");
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});
//error logger
api.interceptors.response.use(r => r, err => {
  console.error("[API ERROR]", {
    method: err?.config?.method,
    url: (err?.config?.baseURL ?? "") + (err?.config?.url ?? ""),
    status: err?.response?.status,
    data: err?.response?.data
  });
  return Promise.reject(err);
});