import { Box, Typography, IconButton } from "@mui/material";
import { Outlet, Link } from "react-router-dom";
import MenuIcon from "@mui/icons-material/Menu";
import { useState } from "react";
import { motion } from "framer-motion";
import { useAuth } from "../auth/AuthProvider";
import DarkModeIcon from "@mui/icons-material/DarkMode";
import LightModeIcon from "@mui/icons-material/LightMode";
import { useTheme } from "@mui/material";
import { useThemeMode } from "../styles/ThemeProvider";

const MainLayout = () => {
    const [open, setOpen] = useState(true);
    const { role } = useAuth();
    const theme = useTheme();
    const { toggleMode } = useThemeMode();


    return (
        <Box sx={{ display: "flex", minHeight: "100vh", backgroundColor: "#f4f6fa" }}>
            {/* Sidebar */}
            <motion.div
                animate={{ width: open ? 220 : 60 }}
                transition={{ duration: 0.3 }}
                style={{ backgroundColor: "#1e3a8a", color: "#fff", paddingTop: 20 }}
            >
                <IconButton onClick={() => setOpen(!open)} sx={{ color: "#fff" }}>
                    <MenuIcon />
                </IconButton>
                <IconButton onClick={toggleMode}>
                    {theme.palette.mode === "dark" ? <LightModeIcon /> : <DarkModeIcon />}
                </IconButton>


                <Box sx={{ mt: 4 }}>
                    <Link to="/dashboard" style={{ color: "#fff", textDecoration: "none" }}>
                        <Typography variant="h6">{open ? "Dashboard" : "DB"}</Typography>
                    </Link>

                    {role !== "employee" && (
                        <Link to="/workflow" style={{ color: "#fff", textDecoration: "none" }}>
                            <Typography variant="h6" sx={{ mt: 2 }}>
                                {open ? "Workflows" : "WF"}
                            </Typography>
                        </Link>
                    )}
                </Box>
            </motion.div>

            {/* Main Content */}
            <Box sx={{ flex: 1, p: 4 }}>
                <Outlet />
            </Box>
        </Box>
    );
};

export default MainLayout;
