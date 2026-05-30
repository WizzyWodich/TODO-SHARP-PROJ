import { Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import { HomePage } from "./pages/Home";
import ProtectedLayout from "./layout/ProtectedLayout";
import { AnimatePresence } from "framer-motion";

export default function App() {
    return (
        <AnimatePresence mode="wait">
            <Routes>
                <Route path="/login" element={<Login />} />
                <Route element={<ProtectedLayout/>}>
                    <Route path="/" element={<HomePage />} />
                </Route>
            </Routes>
        </AnimatePresence>
    );
}