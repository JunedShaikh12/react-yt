import { Box, Typography, Paper, Stack, Button } from "@mui/material";
import { motion } from "framer-motion";
import { useParams } from "react-router-dom";
import { useState } from "react";
import WorkflowForm from "./WorkflowForm";
import { useAuth } from "../../auth/AuthProvider";
const { role } = useAuth();

// Dummy workflow steps
const workflowSteps = [
  { step: 1, name: "Submit Request", status: "Completed" },
  { step: 2, name: "Manager Approval", status: "Pending" },
  { step: 3, name: "Finance Approval", status: "Pending" },
];

// Dummy workflow types (for dynamic forms)
const workflowTypes: any = {
  1: "Purchase Approval",
  2: "Leave Request",
  3: "Expense Reimbursement",
};

const WorkflowDetails = () => {
  const { id } = useParams();
  const [steps, setSteps] = useState(workflowSteps);

  const handleApprove = (stepIndex: number) => {
    const updated = [...steps];
    updated[stepIndex].status = "Approved";
    setSteps(updated);
  };

  const handleReject = (stepIndex: number) => {
    const updated = [...steps];
    updated[stepIndex].status = "Rejected";
    setSteps(updated);
  };

  const workflowType = workflowTypes[id as keyof typeof workflowTypes];
  return (
    <Box sx={{ p: 4 }}>
      <Typography variant="h4" fontWeight="bold" mb={3}>
        Workflow Details (ID: {id})
      </Typography>

      <Stack spacing={3}>
        {steps.map((step, index) => (
          <motion.div
            key={index}
            initial={{ opacity: 0, y: 10 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ delay: index * 0.2 }}
          >
            <Paper sx={{ p: 3, borderRadius: 3 }} elevation={6}>
              <Typography variant="h6">{step.name}</Typography>
              <Typography>Status: {step.status}</Typography>

              {step.status === "Pending" && role !== "employee" && (
                <Stack direction="row" spacing={2} mt={2}>
                  <Button variant="contained" color="success" onClick={() => handleApprove(index)}>
                    Approve
                  </Button>
                  <Button variant="contained" color="error" onClick={() => handleReject(index)}>
                    Reject
                  </Button>
                </Stack>
              )}

            </Paper>
          </motion.div>
        ))}

        {/* Dynamic Workflow Form */}
        {workflowType && (
          <Paper sx={{ p: 3, borderRadius: 3, mt: 4 }} elevation={6}>
            <Typography variant="h6" mb={2}>
              {workflowType} Form
            </Typography>
            <WorkflowForm workflowType={workflowType} />
          </Paper>
        )}
      </Stack>
    </Box>
  );
};

export default WorkflowDetails;
