interface TaskItemProps {
    title: string;
    category: string;
    completed: boolean;
    onToggle: () => void;
}

export default function TaskItem({ title, category, completed, onToggle }: TaskItemProps) {
    return (
        <div className="bg-[#20211f] border border-zinc-800 rounded-2xl p-4 flex items-center justify-between hover:border-cyan-500/40 transition-all">
            <div>
                <h3 className={`font-medium text-sm ${completed ? "line-through text-zinc-500" : ""}`}>
                    {title}
                </h3>
                <p className="text-zinc-400 text-xs">{category}</p>
            </div>
            <button
                onClick={onToggle}
                className={`w-5 h-5 rounded-full border-2 transition-all ${
                    completed ? "bg-cyan-500 border-cyan-500" : "border-cyan-500"
                }`}
            />
        </div>
    );
}