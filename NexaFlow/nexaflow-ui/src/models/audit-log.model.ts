export type AuditAction =
  | "CREATED"
  | "APPROVED"
  | "REJECTED";

export interface AuditLog {
  id: string;
  workflowId: number;
  action: AuditAction;
  performedBy: string;
  role: "admin" | "manager";
  timestamp: string;
  remarks?: string;
}
