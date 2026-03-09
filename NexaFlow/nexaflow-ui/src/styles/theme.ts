import { createTheme } from "@mui/material/styles";

export const getTheme = (mode: "light" | "dark") =>
  createTheme({
    palette: {
      mode,
      primary: {
        main: "#2563eb", // enterprise blue
      },
      secondary: {
        main: "#9333ea",
      },
      background: {
        default: mode === "light" ? "#f4f6fa" : "#0f172a",
        paper: mode === "light" ? "#ffffff" : "#020617",
      },
    },
    typography: {
      fontFamily: `"Inter", "Roboto", "Arial", sans-serif`,
      h4: { fontWeight: 700 },
      h6: { fontWeight: 600 },
    },
    shape: {
      borderRadius: 12,
    },
  });
