import { Button, TextField, Stack, MenuItem } from "@mui/material";
import { motion } from "framer-motion";
import AuthLayout from "../layouts/AuthLayout";
import { useAuth } from "./AuthProvider";
import { useNavigate } from "react-router-dom";
import { useState } from "react";

const roles = ["admin", "manager", "employee"];

const Login = () => {
  const { login } = useAuth();
  const navigate = useNavigate();
  const [selectedRole, setSelectedRole] = useState<"admin" | "manager" | "employee">("admin");

  const handleLogin = () => {
    login(selectedRole);
    navigate("/dashboard");
  };

  return (
    <AuthLayout>
      <motion.div initial={{ opacity: 0 }} animate={{ opacity: 1 }} transition={{ delay: 0.2 }}>
        <Stack spacing={3}>
          <TextField label="Email" type="email" fullWidth />
          <TextField label="Password" type="password" fullWidth />
          <TextField
            select
            label="Role"
            value={selectedRole}
            onChange={(e) => setSelectedRole(e.target.value as any)}
            fullWidth
          >
            {roles.map((role) => (
              <MenuItem key={role} value={role}>
                {role.toUpperCase()}
              </MenuItem>
            ))}
          </TextField>
          <Button variant="contained" size="large" sx={{ height: 45 }} onClick={handleLogin}>
            Sign In
          </Button>
        </Stack>
      </motion.div>
    </AuthLayout>
  );
};

export default Login;
