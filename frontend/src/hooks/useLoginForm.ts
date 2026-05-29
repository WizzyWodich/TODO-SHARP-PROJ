import { useState } from "react";
import type { UserLogin } from "../models/userLogin";
import { login } from "../api/auth";
import { Navigate, useNavigate } from "react-router-dom";

export function useLoginForm() {

    const navigate = useNavigate();

    const [form, setForm] = useState<UserLogin>({
        username: "",
        password: "",
    });

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