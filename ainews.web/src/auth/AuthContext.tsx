import React, {
  createContext,
  useContext,
  useEffect,
  useMemo,
  useState,
  PropsWithChildren,
} from "react";
import * as AuthApi from "../api/auth";

// ---- Types ----
type AuthState = {
  me: AuthApi.MeDto | null;
  loading: boolean;
  isLoggedIn: boolean;
  isAdmin: boolean;
  login(email: string, password: string): Promise<void>;
  register(email: string, password: string, firstName: string, lastName: string): Promise<void>;
  logout(): void;
};


const AuthContext = createContext<AuthState | null>(null);


export function useAuth(): AuthState {
  const ctx = useContext(AuthContext);
  if (ctx === null) {
    throw new Error("useAuth must be used within <AuthProvider>");
  }
  return ctx;
}

// ---- Provider ----
export function AuthProvider({ children }: PropsWithChildren) {
  const [me, setMe] = useState<AuthApi.MeDto | null>(null);
  const [loading, setLoading] = useState(true);

  const fetchMe = async () => {
    try {
      const m = await AuthApi.me();
      setMe(m);
    } finally {
      // If /me fails, we consider the user logged out
      setLoading(false);
    }
  };

  useEffect(() => {
    const token = localStorage.getItem("ainews.token");
    if (token) void fetchMe();
    else setLoading(false);
  }, []);

  const login = async (email: string, password: string) => {
    const res = await AuthApi.login(email, password);
    localStorage.setItem("ainews.token", res.accessToken);
    await fetchMe();
  };

const register = async (email: string, password: string, firstName: string, lastName: string) => {
  const res = await AuthApi.register(email, password, firstName, lastName);
  localStorage.setItem("ainews.token", res.accessToken);
  await fetchMe();
  };

  const logout = () => {
    localStorage.removeItem("ainews.token");
    setMe(null);
  };

  const value: AuthState = useMemo(
    () => ({
      me,
      loading,
      isLoggedIn: me !== null,
      isAdmin: !!me?.roles?.includes("Admin"),
      login,
      register,
      logout,
    }),
    [me, loading]
  );

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}
