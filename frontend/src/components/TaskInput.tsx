import { useState } from 'react';
import PageTransition from "../components/PageTransition";

interface TaskInputProps {
    onAdd: (task: CreateTaskDto) => void;
}

export interface CreateTaskDto {
    title: string;
    description: string;
    priority: number;
    dueAt: string | null;
}

export default function TaskInput({ onAdd }: TaskInputProps) {
    const [isOpen, setIsOpen] = useState(false);
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [priority, setPriority] = useState(0);
    const [dueAt, setDueAt] = useState('');

    const handleSubmit = () => {
        if (!title.trim()) return;
        onAdd({
            title,
            description,
            priority,
            dueAt: dueAt ? new Date(dueAt).toISOString() : null,
        });
        setIsOpen(false);
        setTitle('');
        setDescription('');
        setPriority(0);
        setDueAt('');
    };

    return (
        <>
            <div className="bg-[#20211f] border border-zinc-800 rounded-2xl p-3 mb-6">
                <input
                    type="text"
                    placeholder="Нове завдання..."
                    readOnly
                    onClick={() => setIsOpen(true)}
                    className="w-full bg-zinc-900 border border-zinc-800 rounded-xl px-3 py-2 text-sm outline-none cursor-pointer hover:border-cyan-500 transition-all"
                />
            </div>
            <PageTransition>
                {isOpen && (
                    <div
                        className="fixed inset-0 bg-black/60 flex items-center justify-center z-50"
                        onClick={() => setIsOpen(false)}
                    >
                        <div
                            className="bg-[#20211f] border border-zinc-800 rounded-2xl p-6 w-full max-w-md flex flex-col gap-4"
                            onClick={(e) => e.stopPropagation()}
                        >
                            <h2 className="text-white font-medium text-base">Нове завдання</h2>
    
                            <input
                                type="text"
                                placeholder="Назва *"
                                value={title}
                                onChange={(e) => setTitle(e.target.value)}
                                autoFocus
                                className="bg-zinc-900 border border-zinc-800 rounded-xl px-3 py-2 text-sm outline-none focus:border-cyan-500 transition-all"
                            />
    
                            <textarea
                                placeholder="Опис"
                                value={description}
                                onChange={(e) => setDescription(e.target.value)}
                                rows={3}
                                className="bg-zinc-900 border border-zinc-800 rounded-xl px-3 py-2 text-sm outline-none focus:border-cyan-500 transition-all resize-none"
                            />
    
                            <select
                                value={priority}
                                onChange={(e) => setPriority(Number(e.target.value))}
                                className="bg-zinc-900 border border-zinc-800 rounded-xl px-3 py-2 text-sm outline-none focus:border-cyan-500 transition-all"
                            >
                                <option value={0}>Низький пріоритет</option>
                                <option value={1}>Середній пріоритет</option>
                                <option value={2}>Високий пріоритет</option>
                            </select>
    
                            <input
                                type="datetime-local"
                                value={dueAt}
                                onChange={(e) => setDueAt(e.target.value)}
                                className="bg-zinc-900 border border-zinc-800 rounded-xl px-3 py-2 text-sm outline-none focus:border-cyan-500 transition-all"
                            />
    
                            <div className="flex gap-2 mt-2">
                                <button
                                    onClick={() => setIsOpen(false)}
                                    className="flex-1 border border-zinc-700 text-zinc-400 hover:text-white text-sm font-medium py-2 rounded-xl transition-all"
                                >
                                    Скасувати
                                </button>
                                <button
                                    onClick={handleSubmit}
                                    disabled={!title.trim()}
                                    className="flex-1 bg-cyan-500 hover:bg-cyan-400 disabled:opacity-40 disabled:cursor-not-allowed text-black text-sm font-medium py-2 rounded-xl transition-all"
                                >
                                    Додати
                                </button>
                            </div>
                        </div>
                    </div>
                )}
            </PageTransition>
        </>
    );
}