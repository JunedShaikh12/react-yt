export type WorkflowStatus = "PENDING" | "APPROVED" | "REJECTED";

export interface WorkflowStep {
  id: string;
  stepOrder: number;
  title: string;
  roleAllowed: "admin" | "manager";
  status: WorkflowStatus;
}

export interface Workflow {
  id: string;
  title: string;
  type: "Purchase" | "Leave" | "Expense";
  status: WorkflowStatus;
  createdBy: string;
  createdAt: string;
  steps: WorkflowStep[];
}
