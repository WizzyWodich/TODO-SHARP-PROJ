interface TaskInputProps {
    value: string;
    onChange: (value: string) => void;
    onAdd: () => void;
}

export default function TaskInput({ value, onChange, onAdd }: TaskInputProps) {
    return (
        <div className="bg-[#20211f] border border-zinc-800 rounded-2xl p-3 mb-6 flex gap-2">
            <input
                type="text"
                placeholder="Нове завдання..."
                value={value}
                onChange={(e) => onChange(e.target.value)}
                className="flex-1 bg-zinc-900 border border-zinc-800 rounded-xl px-3 py-2 text-sm outline-none focus:border-cyan-500 transition-all"
            />
            <button
                onClick={onAdd}
                className="bg-cyan-500 hover:bg-cyan-400 text-black text-sm font-medium px-4 rounded-xl transition-all"
            >
                Додати
            </button>
        </div>
    );
}