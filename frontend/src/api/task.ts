import { apiRequest } from "./api";

export function getTaskList(query: any) {
    return apiRequest("/api/task/list", query);
}