import { Plus } from "lucide-react";

interface HeaderProps {
    username?: string;
    onAddTask: () => void;
}

export default function Header({ username, onAddTask }: HeaderProps) {
    return (
        <div className="flex items-center justify-between mb-6">
            <div>
                <h1 className="text-2xl font-semibold mb-1">
                    Вітаємо, {username}!
                </h1>
                <p className="text-sm text-zinc-400">
                    Ваша статістика та завдання
                </p>
            </div>
            <button
                onClick={onAddTask}
                className="flex items-center gap-2 bg-cyan-500 hover:bg-cyan-400 text-black text-sm font-medium px-4 py-2 rounded-xl transition-all"
            >
                <Plus size={16} />
                Додати завдання
            </button>
        </div>
    );
}