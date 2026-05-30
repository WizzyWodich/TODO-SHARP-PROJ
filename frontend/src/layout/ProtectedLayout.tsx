import { Navigate, Outlet } from "react-router-dom";
import { checkAuth } from "../api/auth";
import { useEffect, useState } from "react";
import { motion } from "framer-motion";

export default function ProtectedLayout() {
    const [auth, setAuth] = useState<boolean | null>(null);
    
    useEffect(() => {
        checkAuth().then(setAuth);
    }, []);

    if (auth === null) return (
        <motion.div
            className="min-h-screen bg-[#20211f] flex items-center justify-center"
            initial={{ opacity: 0 }}
            animate={{ opacity: 1 }}
            >
            <motion.div
                className="w-8 h-8 rounded-full border-2 border-cyan-500 border-t-transparent"
                animate={{ rotate: 360 }}
                transition={{ duration: 0.8, repeat: Infinity, ease: "linear" }}
            />
        </motion.div>
    );
    if (!auth) return <Navigate to="/login" />;

    return <Outlet />;
}