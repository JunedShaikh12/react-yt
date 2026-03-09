import { createContext, useContext, useState } from "react";

type AuthContextType = {
  isAuthenticated: boolean;
  role: "admin" | "manager" | "employee" | null;
  login: (role: "admin" | "manager" | "employee") => void;
  logout: () => void;
};

const AuthContext = createContext<AuthContextType | null>(null);

export const AuthProvider = ({ children }: { children: React.ReactNode }) => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [role, setRole] = useState<"admin" | "manager" | "employee" | null>(null);

  const login = (userRole: "admin" | "manager" | "employee") => {
    setIsAuthenticated(true);
    setRole(userRole);
  };

  const logout = () => {
    setIsAuthenticated(false);
    setRole(null);
  };

  return (
    <AuthContext.Provider value={{ isAuthenticated, role, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) throw new Error("useAuth must be used within AuthProvider");
  return context;
};
