import { Box, TextField, Button, Stack, MenuItem } from "@mui/material";
import { motion } from "framer-motion";
import { useState } from "react";

// Example dynamic form configs
const workflowFormConfigs: any = {
  "Purchase Approval": [
    { label: "Item Name", type: "text", name: "itemName" },
    { label: "Amount", type: "number", name: "amount" },
    { label: "Justification", type: "text", name: "justification" },
  ],
  "Leave Request": [
    { label: "Start Date", type: "date", name: "startDate" },
    { label: "End Date", type: "date", name: "endDate" },
    { label: "Reason", type: "text", name: "reason" },
  ],
};

const WorkflowForm = ({ workflowType }: { workflowType: string }) => {
  const [formValues, setFormValues] = useState<any>({});

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormValues({ ...formValues, [e.target.name]: e.target.value });
  };

  const handleSubmit = () => {
    console.log("Form Submitted:", formValues);
    alert("Form submitted! (mock)");
  };

  const fields = workflowFormConfigs[workflowType] || [];

  return (
    <motion.div
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.6 }}
    >
      <Box component="form" sx={{ mt: 3 }}>
        <Stack spacing={3}>
          {fields.map((field: any) => (
            <TextField
              key={field.name}
              label={field.label}
              type={field.type}
              name={field.name}
              value={formValues[field.name] || ""}
              onChange={handleChange}
              fullWidth
            />
          ))}

          <Button variant="contained" color="primary" onClick={handleSubmit}>
            Submit
          </Button>
        </Stack>
      </Box>
    </motion.div>
  );
};

export default WorkflowForm;
