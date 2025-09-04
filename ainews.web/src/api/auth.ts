import { api } from "./client";

export type AuthResultDto = { accessToken: string; refreshToken: string; expiresAt: string; };
export type MeDto = { id: string; email: string; roles: string[]; };

export const register = (email: string, password: string, firstName: string, lastName: string) =>
  api.post("/api/Auth/register", { email, password, firstName, lastName })
     .then(r => r.data);

export const login = (email: string, password: string) =>
  api.post<AuthResultDto>("/api/Auth/login", { email, password }).then(r => r.data);

export const me = () => api.get<MeDto>("/api/Auth/me").then(r => r.data);