import { Routes, Route, Navigate } from "react-router-dom";
import Login from "../auth/Login";
import Dashboard from "../features/dashboard/Dashboard";
import ProtectedRoute from "../auth/ProtectedRoute";

const AppRoutes = () => {
  return (
    <Routes>
      {/* Public Route */}
      <Route path="/login" element={<Login />} />

      {/* Protected Route */}
      <Route
        path="/dashboard"
        element={
          <ProtectedRoute>
            <Dashboard />
          </ProtectedRoute>
        }
      />

      {/* Default Redirect */}
      <Route path="*" element={<Navigate to="/login" replace />} />
    </Routes>
  );
};

export default AppRoutes;
