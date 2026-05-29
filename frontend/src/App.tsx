import { Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import Layout from "./layout/Layout";
import { Home } from "./pages/Home";
import ProtectedLayout from "./layout/ProtectedLayout";

export default function App() {
    return (
        <Routes>
            <Route path="/login" element={<Login />} />
            <Route element={<ProtectedLayout/>}>
              <Route element={<Layout />}>            
                <Route path="/" element={<Home />} />
              </Route>
            </Route>
        </Routes>
    );
}