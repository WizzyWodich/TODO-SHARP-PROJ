import { useState } from "react";
import PageTransition from "../components/PageTransition";
import SideBar from "../components/SideBar";
import Statistic from "../components/Statistic";
import Header from "../components/HeaderProps";
import TaskInput from "../components/TaskInput";
import TaskList from "../components/TaskList";
import useAuth from "../hooks/useAuth";

const MOCK_TASKS = [
    { id: 1, title: "Learn Zustand", category: "State", completed: false },
];

export function HomePage() {
    const { user } = useAuth();
    const [tasks, setTasks] = useState(MOCK_TASKS);
    const [input, setInput] = useState("");

    const handleAdd = () => {
        if (!input.trim()) return;
        setTasks([...tasks, { id: Date.now(), title: input, category: "General", completed: false }]);
        setInput("");
    };

    const handleToggle = (id: number) => {
        setTasks(tasks.map(t => t.id === id ? { ...t, completed: !t.completed } : t));
    };

    return (
        <PageTransition>
            <div className="min-h-screen bg-[#20211f] text-white flex p-2 gap-2">
                <SideBar />
                <main className="flex-1 bg-[#171717] border border-zinc-800 rounded-3xl p-5">
                    <Header username={user?.username} onAddTask={handleAdd} />
                    <div className="grid grid-cols-3 gap-3 mb-6">
                        <Statistic />
                    </div>
                    <TaskInput value={input} onChange={setInput} onAdd={handleAdd} />
                    <TaskList tasks={tasks} onToggle={handleToggle} />
                </main>
            </div>
        </PageTransition>
    );
}