import { useState } from 'react';

function getNowLocal() {
  const now = new Date();

  const pad = (n) => String(n).padStart(2, '0');

  const year = now.getFullYear();
  const month = pad(now.getMonth() + 1);
  const day = pad(now.getDate());
  const hours = pad(now.getHours());
  const minutes = pad(now.getMinutes());

  return `${year}-${month}-${day}T${hours}:${minutes}`;
}

export function CreateTodoComponent() {
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');
  const [priority, setPriority] = useState('low');
  const [dateTime, setDateTime] = useState(() => getNowLocal());
  const [hasTime, setHasTime] = useState(false);

  const handleAdd = () => {
    const todo = {
      title,
      description,
      priority,
      dateTime: hasTime ? dateTime : null,
    };

    console.log('TODO:', todo);

    setTitle('');
    setDescription('');
    setPriority('low');
    setDateTime(getNowLocal());
    setHasTime(false);
  };

  return (
    <div
      className="flex flex-col gap-4 w-full p-5
                 bg-white/60 backdrop-blur-xl
                 rounded-2xl border border-white/50 shadow"
    >
      <h1 className="text-gray-600 font-semibold">Create todo:</h1>

      <div className="grid grid-cols-1 md:grid-cols-2 gap-3">
        <input
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          className="border-b border-gray-300 bg-transparent p-2 outline-none
                     focus:border-purple-400 transition"
          placeholder="Title"
        />

        <input
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          className="border-b border-gray-300 bg-transparent p-2 outline-none
                     focus:border-purple-400 transition"
          placeholder="Description"
        />
      </div>

      <div className="flex flex-wrap gap-2">
        {[
          { key: 'low', label: 'low', color: 'bg-emerald-200' },
          { key: 'medium', label: 'medium', color: 'bg-yellow-200' },
          { key: 'high', label: 'high', color: 'bg-red-200' },
        ].map((p) => (
          <button
            key={p.key}
            onClick={() => setPriority(p.key)}
            className={`px-3 py-1 text-sm rounded-2xl transition
              ${
                priority === p.key
                  ? `${p.color} text-gray-600 shadow`
                  : 'bg-white/40 text-gray-600 hover:bg-white/70'
              }`}
          >
            {p.label}
          </button>
        ))}
      </div>

      <div className="flex justify-between items-center gap-3">
        <div className="flex items-center gap-2">
          <span className="text-gray-600 text-sm">EndTime</span>

          <label className="flex items-center cursor-pointer">
            <input
              type="checkbox"
              checked={hasTime}
              onChange={() => setHasTime(!hasTime)}
              className="peer hidden"
            />

            <div
              className={`
                w-5 h-5 rounded-full
                border transition-all duration-200
                flex items-center justify-center
                peer-hover:border-purple-400
                ${
                  hasTime
                    ? 'bg-purple-200 border-purple-400'
                    : 'bg-white/60 border-gray-300 backdrop-blur-md'
                }
              `}
            >
              <div
                className={`
                  w-2 h-2 rounded-full
                  transition-all duration-200
                  ${
                    hasTime
                      ? 'bg-purple-400 scale-100'
                      : 'bg-transparent scale-0'
                  }
                `}
              />
            </div>
          </label>
        </div>

        <button
          onClick={handleAdd}
          className="bg-purple-400 text-white px-4 py-2 rounded-xl
                     hover:bg-purple-500 transition"
        >
          Add
        </button>
      </div>

      <div
        className={`
          grid transition-all duration-300 overflow-hidden
          ${hasTime ? 'grid-rows-[1fr] opacity-100 mt-2' : 'grid-rows-[0fr] opacity-0'}
        `}
      >
        <div className="overflow-hidden">
          <input
            type="datetime-local"
            value={dateTime}
            onChange={(e) => setDateTime(e.target.value)}
            className="w-full border-b border-gray-300 bg-transparent p-2 outline-none
                 focus:border-purple-400 transition"
          />
        </div>
      </div>
    </div>
  );
}
