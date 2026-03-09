import type { Workflow, WorkflowStep } from "../models/workflow.model";
import { v4 as uuid } from "uuid";

class WorkflowStore {
  private workflows: Workflow[] = [];

  // CREATE WORKFLOW
  createWorkflow(
    title: string,
    type: "Purchase" | "Leave" | "Expense",
    createdBy: string
  ) {
    const steps: WorkflowStep[] = [
      {
        id: uuid(),
        stepOrder: 1,
        title: "Manager Approval",
        roleAllowed: "manager",
        status: "PENDING",
      },
      {
        id: uuid(),
        stepOrder: 2,
        title: "Admin Approval",
        roleAllowed: "admin",
        status: "PENDING",
      },
    ];

    const workflow: Workflow = {
      id: uuid(),
      title,
      type,
      status: "PENDING",
      createdBy,
      createdAt: new Date().toISOString(),
      steps,
    };

    this.workflows.push(workflow);
  }

  // GET WORKFLOWS
  getWorkflows() {
    return this.workflows;
  }

  // APPROVE STEP
  approveStep(workflowId: string, stepId: string, role: string) {
    const workflow = this.workflows.find(w => w.id === workflowId);
    if (!workflow) return;

    const step = workflow.steps.find(s => s.id === stepId);
    if (!step || step.roleAllowed !== role) return;

    step.status = "APPROVED";

    const nextStep = workflow.steps.find(
      s => s.stepOrder === step.stepOrder + 1
    );

    if (!nextStep) {
      workflow.status = "APPROVED";
    }
  }

  // REJECT STEP
  rejectStep(workflowId: string, stepId: string, role: string) {
    const workflow = this.workflows.find(w => w.id === workflowId);
    if (!workflow) return;

    const step = workflow.steps.find(s => s.id === stepId);
    if (!step || step.roleAllowed !== role) return;

    step.status = "REJECTED";
    workflow.status = "REJECTED";
  }
}

export const workflowStore = new WorkflowStore();
