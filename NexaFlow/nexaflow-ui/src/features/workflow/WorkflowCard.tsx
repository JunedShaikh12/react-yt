import { Card, CardContent, Typography, Button, Chip, Stack } from "@mui/material";
import type { Workflow } from "../../models/workflow.model";
import { useAuth } from "../../auth/AuthProvider";
import { workflowStore } from "../../store/workflow.store";

interface Props {
  workflow: Workflow;
  refresh: () => void;
}

const WorkflowCard = ({ workflow, refresh }: Props) => {
  const { role } = useAuth() as any;

  const activeStep = workflow.steps.find(s => s.status === "PENDING");

  return (
    <Card sx={{ borderRadius: 3, boxShadow: 6 }}>
      <CardContent>
        <Typography variant="h6">{workflow.title}</Typography>
        <Typography color="text.secondary">
          Type: {workflow.type}
        </Typography>

        <Stack direction="row" spacing={1} my={2}>
          <Chip label={workflow.status} color={
            workflow.status === "APPROVED" ? "success" :
            workflow.status === "REJECTED" ? "error" : "warning"
          }/>
        </Stack>

        {activeStep && activeStep.roleAllowed === role && (
          <Stack direction="row" spacing={2}>
            <Button
              variant="contained"
              color="success"
              onClick={() => {
                workflowStore.approveStep(workflow.id, activeStep.id, role);
                refresh();
              }}
            >
              Approve
            </Button>

            <Button
              variant="outlined"
              color="error"
              onClick={() => {
                workflowStore.rejectStep(workflow.id, activeStep.id, role);
                refresh();
              }}
            >
              Reject
            </Button>
          </Stack>
        )}
      </CardContent>
    </Card>
  );
};

export default WorkflowCard;
