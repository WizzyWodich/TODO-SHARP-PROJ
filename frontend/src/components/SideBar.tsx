import { CheckSquare, Home, Settings, LogOut } from "lucide-react";
import { useHomePage } from "../hooks/useHomePage";
import { useLocation, useNavigate } from "react-router-dom";
import { useState } from "react";

export default function SideBar() {
    const { handleSubmit } = useHomePage();
    const location = useLocation();
    const navigate = useNavigate();

    const [expanded, setExpanded] = useState(false);

    const isActive = (path: string) => location.pathname === path;

    return (
        <aside
            className={`bg-[#171717] border border-zinc-800 rounded-3sxl flex flex-col py-4 transition-all duration-500
                ${expanded ? "w-48" : "w-16"}`}
        >
            {/* Логотип */}
            <div className="mb-6 flex items-center px-2">
                <button
                    onClick={() => setExpanded(!expanded)}
                    className="w-10 h-10 rounded-xl hover:bg-cyan-500/20 flex items-center justify-center shrink-0 transition-all duration-300"
                >
                    <CheckSquare size={18} />
                </button>

                <span
                    className={`text-white text-sm font-semibold whitespace-nowrap overflow-hidden transition-all duration-500
                        ${expanded
                        ? "opacity-100 max-w-32 ml-3"
                        : "opacity-0 max-w-0 ml-0"
                    }`}
                >
                    TODO
                </span>
            </div>

            {/* Навигация */}
            <nav className="flex flex-col gap-3 px-2">
                <button
                    onClick={() => navigate("/")}
                    className={`h-10 w-full flex items-center transition-all duration-300
                        ${isActive("/")
                        ? "bg-cyan-500/20 border-l-2 border-l-cyan-500 rounded-r-xl"
                        : "hover:bg-zinc-800 hover:rounded-xl"
                    }`}
                >
                    <span className="w-10 h-10 flex items-center justify-center shrink-0">
                        <Home size={17} />
                    </span>

                    <span
                        className={`text-sm whitespace-nowrap overflow-hidden transition-all duration-500
                            ${expanded
                            ? "opacity-100 max-w-32 ml-2"
                            : "opacity-0 max-w-0 ml-0"
                        }`}
                    >
                        Головна
                    </span>
                </button>

                <button
                    onClick={() => navigate("/settings")}
                    className={`h-10 w-full flex items-center transition-all duration-300
                        ${isActive("/settings")
                        ? "bg-cyan-500/20 border-l-2 border-l-cyan-500 rounded-r-xl"
                        : "hover:bg-zinc-800 hover:rounded-xl"
                    }`}
                >
                    <span className="w-10 h-10 flex items-center justify-center shrink-0">
                        <Settings size={17} />
                    </span>

                    <span
                        className={`text-sm whitespace-nowrap overflow-hidden transition-all duration-500
                            ${expanded
                            ? "opacity-100 max-w-32 ml-2"
                            : "opacity-0 max-w-0 ml-0"
                        }`}
                    >
                        Налаштування
                    </span>
                </button>
            </nav>

            {/* Выход */}
            <button
                onClick={handleSubmit}
                className="mt-auto mx-2 h-10 flex items-center rounded-xl transition-all duration-300 hover:bg-zinc-800"
            >
                <span className="w-10 h-10 flex items-center justify-center shrink-0">
                    <LogOut size={17} />
                </span>

                <span
                    className={`text-sm whitespace-nowrap overflow-hidden transition-all duration-500
                        ${expanded
                        ? "opacity-100 max-w-32 ml-2"
                        : "opacity-0 max-w-0 ml-0"
                    }`}
                >
                    Вийти
                </span>
            </button>
        </aside>
    );
}