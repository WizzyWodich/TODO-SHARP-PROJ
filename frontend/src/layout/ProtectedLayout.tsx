import { Navigate, Outlet } from "react-router-dom";
import { checkAuth } from "../api/auth";
import { useEffect, useState } from "react";

export default function ProtectedLayout() {
    const [auth, setAuth] = useState<boolean | null>(null);
    
    useEffect(() => {
        checkAuth().then(setAuth);
    }, []);

    if (auth === null) return <div>Loading...</div>;
    if (!auth) return <Navigate to="/login" />;

    return <Outlet />;
}