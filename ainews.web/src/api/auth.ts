import { api } from "./client";

export type AuthResultDto = { accessToken: string; refreshToken: string; expiresAt: string; };
export type MeDto = { id: string; email: string; roles: string[]; };

export const register = (email: string, password: string, firstName: string, lastName: string) =>
  api.post("/api/Auth/register", { email, password, firstName, lastName })
     .then(r => r.data);

export const login = (email: string, password: string) =>
  api.post<AuthResultDto>("/api/auth/login", { email, password }).then(r => r.data);

export const me = () => api.get<MeDto>("/api/auth/me").then(r => r.data);