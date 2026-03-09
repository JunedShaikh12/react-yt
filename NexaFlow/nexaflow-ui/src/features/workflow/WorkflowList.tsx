import { Box, Typography, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Button } from "@mui/material";
import { motion } from "framer-motion";
import { useNavigate } from "react-router-dom";

// Dummy workflow data
const workflows = [
  { id: 1, name: "Purchase Approval", status: "Pending", owner: "Alice" },
  { id: 2, name: "Leave Request", status: "Approved", owner: "Bob" },
  { id: 3, name: "Expense Reimbursement", status: "Pending", owner: "Charlie" },
];

const WorkflowList = () => {
  const navigate = useNavigate();

  return (
    <Box sx={{ p: 4 }}>
      <Typography variant="h4" fontWeight="bold" mb={3}>
        Workflows
      </Typography>

      <TableContainer component={Paper} elevation={6}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Workflow</TableCell>
              <TableCell>Status</TableCell>
              <TableCell>Owner</TableCell>
              <TableCell>Action</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {workflows.map((wf) => (
              <motion.tr
                key={wf.id}
                initial={{ opacity: 0, y: 10 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.3 }}
              >
                <TableCell>{wf.name}</TableCell>
                <TableCell>{wf.status}</TableCell>
                <TableCell>{wf.owner}</TableCell>
                <TableCell>
                  <Button
                    variant="contained"
                    size="small"
                    onClick={() => navigate(`/workflow/${wf.id}`)}
                  >
                    View
                  </Button>
                </TableCell>
              </motion.tr>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
};

export default WorkflowList;
