import { logout } from "../api/auth";
import { useNavigate } from "react-router-dom";

export function useHomePage() {
    const navigate = useNavigate();

    async function handleSubmit(event: React.FormEvent) {
        event.preventDefault();

        await logout();
        navigate("/login");
    }

    return {
        handleSubmit,
    };
}