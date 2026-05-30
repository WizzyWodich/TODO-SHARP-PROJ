import { useState } from "react";
import type { UserLogin } from "../interfaces/userLoginInterface";
import { login } from "../api/auth";
import { useNavigate } from "react-router-dom";
import { getMe } from "../api/user";
import useAuth from "./useAuth";

export function useLoginForm() {

    const navigate = useNavigate();

    const [form, setForm] = useState<UserLogin>({
        username: "",
        password: "",
    });

    const { setUser } = useAuth();

    function handleFormChange(event: React.ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;

        setForm((prev) => ({
            ...prev,
            [name]: value,
        }));
    }

    async function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();

        try {
            await login(form);
            const user = await getMe();
            setUser(user);
            navigate("/");
        } catch (err) {
            console.log("error", err);
        }
    }

    return {
        form,
        handleFormChange,
        handleSubmit,
    };
}