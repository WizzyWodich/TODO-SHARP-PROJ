import { CheckSquare, Home, Settings, LogOut } from "lucide-react";
import { useHomePage } from "../hooks/useHomePage";

export default function SideBar() {
    const { handleSubmit } = useHomePage();

    return (
         <aside className="w-16 bg-[#171717] border border-zinc-800 rounded-3xl flex flex-col items-center py-4">

                <div className="mb-6">
                <div className="w-10 h-10 rounded-xl bg-cyan-500/20 border border-cyan-500 flex items-center justify-center">
                    <CheckSquare size={18} />
                </div>
                </div>

                <nav className="flex flex-col gap-3">
                <button className="w-10 h-10 rounded-xl bg-cyan-500/20 border border-cyan-500 flex items-center justify-center hover:scale-105 transition-all">
                    <Home size={17} />
                </button>

                <button className="w-10 h-10 rounded-xl hover:bg-zinc-800 flex items-center justify-center transition-all">
                    <Settings size={17} />
                </button>
                </nav>

                <button onClick={handleSubmit} className="mt-auto w-10 h-10 rounded-xl hover:bg-zinc-800 flex items-center justify-center transition-all">
                    <LogOut size={17} />
                </button>
            </aside>
    );
}