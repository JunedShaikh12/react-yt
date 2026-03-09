import React from "react";
import ReactDOM from "react-dom/client";
import { ThemeProvider } from "@mui/material";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { BrowserRouter } from "react-router-dom";
import { getTheme } from "./styles/theme";
import App from "./App";
import { AuthProvider } from "./auth/AuthProvider";
import { AppThemeProvider } from "./styles/ThemeProvider";


const queryClient = new QueryClient();

ReactDOM.createRoot(document.getElementById("root")!).render(
  <ThemeProvider theme={getTheme("light")}>
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
      <AuthProvider>
              <AppThemeProvider>
        <App />
              </AppThemeProvider>
       </AuthProvider>
      </BrowserRouter>
    </QueryClientProvider>
  </ThemeProvider>
);
