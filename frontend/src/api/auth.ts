import { apiRequest } from "./api";
import type { UserLogin } from "../models/userLogin";

export async function login(form: UserLogin): Promise<void> {
    await apiRequest("/auth/login", {
        method: "POST",
        body: JSON.stringify(form),
    });
}

export async function logout(): Promise<void> {
    await apiRequest("/auth/logout", {
        method: "POST",
    });
}

export async function checkAuth(): Promise<boolean> {
    try {
        await apiRequest("/auth/me");
        return true;
    } catch (err) {
        return false;
    }
}