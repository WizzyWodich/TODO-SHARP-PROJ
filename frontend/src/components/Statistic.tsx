
export default function Statistic() {
    return (
        <>
            <div className="bg-[#20211f] border border-zinc-800 rounded-2xl p-4">
                <p className="text-xs text-zinc-400 mb-1">
                    Всього завдань
                </p>

                <h2 className="text-2xl font-bold">
                    12
                </h2>
            </div>
            <div className="bg-[#20211f] border border-zinc-800 rounded-2xl p-4">
                <p className="text-xs text-zinc-400 mb-1">
                    Виконано
                </p>

                <h2 className="text-2xl font-bold text-emerald-400">
                    8
                </h2>
            </div>
        </>
    );
}