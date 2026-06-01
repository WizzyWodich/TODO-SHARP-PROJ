import { Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import { HomePage } from "./pages/Home";
import ProtectedLayout from "./layout/ProtectedLayout";
import { AnimatePresence } from "framer-motion";
import {Settings} from "./pages/Settings.tsx";
import Registration from "./pages/Registration.tsx";

export default function App() {
    return (
        <AnimatePresence mode="wait">
            <Routes>
                <Route path="/login" element={<Login />} />
                <Route path="/register" element={<Registration />} />
                <Route element={<ProtectedLayout/>}>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/settings" element={<Settings/>}/>
                </Route>
            </Routes>
        </AnimatePresence>
    );
}