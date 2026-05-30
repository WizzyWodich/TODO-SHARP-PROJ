import { apiRequest } from "./api";
import type { User } from "../types/userType";

export async function getMe() : Promise<User> {
    return await apiRequest("/user/me");
}

