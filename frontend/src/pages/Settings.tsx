import PageTransition from "../components/PageTransition.tsx";
import SideBar from "../components/SideBar.tsx";
import {User} from "lucide-react";
import useAuth from "../hooks/useAuth.ts";

export function Settings() {
    const { user } = useAuth();

    return (
        <PageTransition>
            <div className="min-h-screen bg-[#20211f] text-white flex p-2 gap-2">
                <SideBar />

                <main className="flex-1 flex items-center justify-center bg-[#171717] border border-zinc-800 rounded-3xl p-6">

                    <div className="w-full max-w-5xl bg-[#1f1f1f] border border-zinc-800 rounded-3xl p-10 flex gap-10">

                        <div className="w-1/3 flex flex-col items-center gap-5">

                            <div className="w-36 h-36 rounded-full bg-zinc-800 border border-zinc-700 flex items-center justify-center">
                                <User className="w-16 h-16 text-zinc-400" />
                            </div>

                            <div className="text-center">
                                <p className="text-lg font-semibold">{user?.username}</p>
                            </div>

                            <div className="w-full mt-4 space-y-3">

                                <div className="flex justify-between text-sm bg-[#2a2a2a] p-3 rounded-xl">
                                    <span className="text-zinc-400">Active tasks</span>
                                    <span className="text-white">12</span>
                                </div>

                                <div className="flex justify-between text-sm bg-[#2a2a2a] p-3 rounded-xl">
                                    <span className="text-zinc-400">Completed</span>
                                    <span className="text-green-400">48</span>
                                </div>

                            </div>

                        </div>

                        <div className="flex-1 flex flex-col justify-center gap-8">

                            <div>
                                <p className="text-xs text-zinc-500">EMAIL</p>
                                <p className="text-xl">{user?.email ?? "Не встановлено"}</p>
                            </div>

                            <div>
                                <p className="text-xs text-zinc-500">USERNAME</p>
                                <p className="text-2xl font-semibold">{user?.username}</p>
                            </div>

                            <div>
                                <p className="text-xs text-zinc-500">APP STATUS</p>
                                <p className="text-green-400">All systems operational</p>
                            </div>
                        </div>
                    </div>
                </main>
            </div>
        </PageTransition>
    )
}