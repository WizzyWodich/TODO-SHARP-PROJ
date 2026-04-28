import { useState } from 'react';
import { todos as initialTodos } from '../data/todos';
import { TodoItem } from './TodoItem';
import type { Todo } from '../types/todo';

export function TodoList() {
  const [todos, setTodos] = useState<Todo[]>(initialTodos);

  const toggleComplete = (id: number) => {
    setTodos((prev) =>
      prev.map((todo) =>
        todo.id === id ? { ...todo, completed: !todo.completed } : todo
      )
    );
  };

  const deleteTodo = (id: number) => {
    setTodos((prev) => prev.filter((todo) => todo.id !== id));
  };

  // сортировка по дедлайну (важно для UX)
  const sortedTodos = [...todos].sort(
    (a, b) => new Date(a.dueDate).getTime() - new Date(b.dueDate).getTime()
  );

  return (
    <div className="flex flex-col gap-3 overflow-auto">
      {sortedTodos.map((todo) => (
        <TodoItem
          key={todo.id}
          todo={todo}
          toggleComplete={toggleComplete}
          deleteTodo={deleteTodo}
        />
      ))}
    </div>
  );
}
