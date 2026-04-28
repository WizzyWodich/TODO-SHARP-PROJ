import { FaTrash, FaClock, FaCalendarAlt } from '../assets/icons';
import type { Todo } from '../types/todo';

const priorityStyles = {
  high: 'bg-red-200 text-red-500',
  medium: 'bg-yellow-200 text-yellow-500',
  low: 'bg-emerald-200 text-green-500',
};

type Props = {
  todo: Todo;
  toggleComplete: (id: number) => void;
  deleteTodo: (id: number) => void;
};

export function TodoItem({ todo, toggleComplete, deleteTodo }: Props) {
  const isOverdue = new Date(todo.dueDate) < new Date() && !todo.completed;

  const formatDate = (date: string) =>
    new Date(date).toLocaleDateString('ru-RU');

  return (
    <div
      className={`
        bg-white/60 backdrop-blur-xl
        p-5 rounded-2xl border border-white/50 shadow
        flex flex-col gap-3 transition
        hover:shadow-lg
        ${todo.completed ? 'opacity-50' : ''}
      `}
    >
      <div className="flex items-center gap-3 w-full pb-2 border-b border-white/40">
        <div className="flex items-center gap-3 flex-1">
          <div className="w-1.5 self-stretch bg-purple-500 rounded-full"></div>

          <h1
            className={`
              text-gray-700 font-semibold text-lg transition
              ${todo.completed ? 'line-through opacity-60' : ''}
            `}
          >
            {todo.title}
          </h1>
        </div>

        <label className="flex items-center cursor-pointer">
          <input
            type="checkbox"
            checked={todo.completed}
            onChange={() => toggleComplete(todo.id)}
            className="peer hidden"
          />

          <div
            className={`
              w-7 h-7 rounded-full
              border transition-all duration-200
              flex items-center justify-center
              peer-hover:border-purple-400
              ${
                todo.completed
                  ? 'bg-purple-200 border-purple-400'
                  : 'bg-white/60 border-gray-300 backdrop-blur-md'
              }
            `}
          >
            <div
              className={`
                w-4 h-4 rounded-full
                transition-all duration-200
                ${
                  todo.completed
                    ? 'bg-purple-400 scale-100'
                    : 'bg-transparent scale-0'
                }
              `}
            />
          </div>
        </label>
      </div>
      <p
        className={`
          text-sm text-gray-600 transition
          ${todo.completed ? 'line-through opacity-50' : ''}
        `}
      >
        {todo.description}
      </p>

      {/* FOOTER */}
      <div className="flex flex-col gap-3 pt-3 border-t border-white/40 md:flex-row md:justify-between md:items-center">
        <div className="flex flex-wrap gap-3 items-center">
          <span
            className={`
              px-3 py-1 text-xs rounded-full font-medium
              ${priorityStyles[todo.priority]}
            `}
          >
            {todo.priority}
          </span>

          <div className="flex items-center gap-4">
            {/* CREATED */}
            <div className="flex flex-col text-xs">
              <span className="text-[10px] uppercase text-gray-400">
                Created
              </span>
              <div className="flex items-center gap-1 text-gray-400">
                <FaCalendarAlt />
                <span>{formatDate(todo.createdAt)}</span>
              </div>
            </div>

            {/* DUE */}
            <div className="flex flex-col text-xs">
              <span className="text-[10px] uppercase text-gray-400">Due</span>
              <div
                className={`
                  flex items-center gap-1 font-medium
                  ${isOverdue ? 'text-red-500' : 'text-purple-500'}
                `}
              >
                <FaClock />
                <span>{formatDate(todo.dueDate)}</span>
              </div>
            </div>
          </div>
        </div>

        <button
          onClick={() => deleteTodo(todo.id)}
          className="p-2 rounded-xl text-gray-400 hover:bg-red-100 hover:text-red-500 transition"
        >
          <FaTrash />
        </button>
      </div>
    </div>
  );
}
