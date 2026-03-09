import { Box, Typography, Paper } from "@mui/material";
import { motion } from "framer-motion";
import { useAuth } from "../../auth/AuthProvider";
import Grid from "@mui/material/Grid";

import {
  LineChart,
  Line,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  ResponsiveContainer,
} from "recharts";
import PageWrapper from "../../components/common/PageWrapper";

const statsAdmin = [
  { title: "Pending Requests", value: 12 },
  { title: "Completed Requests", value: 48 },
  { title: "Avg Approval Time (hrs)", value: 3.2 },
  { title: "Rejected Requests", value: 5 },
];

const statsManager = [
  { title: "Pending Approvals", value: 8 },
  { title: "Team Completed", value: 30 },
  { title: "Avg Approval Time (hrs)", value: 2.5 },
];

const chartData = [
  { day: "Mon", completed: 5, pending: 2 },
  { day: "Tue", completed: 8, pending: 3 },
  { day: "Wed", completed: 6, pending: 4 },
  { day: "Thu", completed: 10, pending: 1 },
  { day: "Fri", completed: 9, pending: 5 },
];

const Dashboard = () => {
  const { role } = useAuth() as any; // temporary role from Auth Context

  // Select stats based on role
  const stats = role === "admin" ? statsAdmin : statsManager;

  return (
    <Box sx={{ minHeight: "100vh", backgroundColor: "#f4f6fa", p: 4 }}>
            <PageWrapper>
      <Typography variant="h4" fontWeight="bold" mb={4}>
        Welcome, {role || "User"}!
      </Typography>

      <Grid container spacing={3} mb={4}>
        {stats.map((stat, index) => (
          <Grid item xs={12} sm={6} md={3} key={index}>
            <motion.div
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              whileHover={{ scale: 1.05, rotate: 1 }}
              transition={{ delay: index * 0.2, duration: 0.4 }}
            >
              <Paper
                elevation={6}
                sx={{
                  p: 3,
                  borderRadius: 3,
                  textAlign: "center",
                  cursor: "pointer",
                }}
              >
                <Typography variant="h6">{stat.title}</Typography>
                <Typography variant="h3" fontWeight="bold">
                  {stat.value}
                </Typography>
              </Paper>
            </motion.div>
          </Grid>
        ))}
      </Grid>

      {/* Chart */}
      <Grid container spacing={3}>
        <Grid item xs={12} md={6}>
          <motion.div
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.6 }}
          >
            <Paper sx={{ p: 3, borderRadius: 3 }} elevation={6}>
              <Typography variant="h6" mb={2}>
                Completed vs Pending Requests
              </Typography>
              <ResponsiveContainer width="100%" height={250}>
                <LineChart data={chartData}>
                  <CartesianGrid strokeDasharray="3 3" />
                  <XAxis dataKey="day" />
                  <YAxis />
                  <Tooltip />
                  <Line type="monotone" dataKey="completed" stroke="#1e3a8a" strokeWidth={2} />
                  <Line type="monotone" dataKey="pending" stroke="#0f766e" strokeWidth={2} />
                </LineChart>
              </ResponsiveContainer>
            </Paper>
          </motion.div>
        </Grid>
      </Grid>
    </PageWrapper>
    </Box>
  );
};

export default Dashboard;
