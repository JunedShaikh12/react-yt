import { Box, Paper, Typography } from "@mui/material";
import { motion } from "framer-motion";

const AuthLayout = ({ children }: { children: React.ReactNode }) => {
  return (
    <Box
      sx={{
        minHeight: "100vh",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        background: "linear-gradient(135deg, #1e3a8a, #0f766e)"
      }}
    >
      <motion.div
        initial={{ opacity: 0, y: 30 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.6 }}
      >
        <Paper
          elevation={10}
          sx={{
            width: 380,
            padding: 4,
            borderRadius: 3
          }}
        >
          <Typography
            variant="h5"
            fontWeight="bold"
            textAlign="center"
            mb={2}
          >
            EnterpriseFlow
          </Typography>

          {children}
        </Paper>
      </motion.div>
    </Box>
  );
};

export default AuthLayout;
