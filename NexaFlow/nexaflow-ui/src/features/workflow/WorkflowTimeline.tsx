import { Box, Typography, Paper, Divider } from "@mui/material";
import { motion } from "framer-motion";
import { AuditLog } from "../../models/audit-log.model";

interface Props {
  logs: AuditLog[];
}

const WorkflowTimeline = ({ logs }: Props) => {
  return (
    <Box>
      <Typography variant="h6" fontWeight="bold" mb={2}>
        Workflow Timeline
      </Typography>

      {logs.map((log, index) => (
        <motion.div
          key={log.id}
          initial={{ opacity: 0, x: -30 }}
          animate={{ opacity: 1, x: 0 }}
          transition={{ delay: index * 0.2 }}
        >
          <Paper sx={{ p: 2, mb: 2, borderLeft: "4px solid #1e3a8a" }}>
            <Typography fontWeight="bold">
              {log.action}
            </Typography>

            <Typography variant="body2" color="text.secondary">
              {log.performedBy} ({log.role})
            </Typography>

            <Typography variant="caption" color="text.secondary">
              {new Date(log.timestamp).toLocaleString()}
            </Typography>

            {log.remarks && (
              <>
                <Divider sx={{ my: 1 }} />
                <Typography variant="body2">
                  {log.remarks}
                </Typography>
              </>
            )}
          </Paper>
        </motion.div>
      ))}
    </Box>
  );
};

export default WorkflowTimeline;
