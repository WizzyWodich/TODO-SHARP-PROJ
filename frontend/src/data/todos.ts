import type { Todo } from '../types/todo';

export const todos: Todo[] = [
  {
    id: 2,
    title: 'Todo-Title',
    description: `Панамский канал...`,
    priority: 'medium',
    completed: true,
    createdAt: '2026-04-18T10:00:00',
    dueDate: '2026-04-20T18:00:00',
  },
  {
    id: 3,
    title: 'Todo-Title',
    description: 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWX',
    priority: 'low',
    completed: false,
    createdAt: '2026-04-19T12:00:00',
    dueDate: '2026-04-25T12:00:00',
  },
  {
    id: 4,
    title: 'Todo-Title',
    description: 'Some text',
    priority: 'low',
    completed: false,
    createdAt: '2026-04-20T09:00:00',
    dueDate: '2026-04-21T09:00:00',
  },
  {
    id: 5,
    title: 'Todo-Title',
    description: 'Some text',
    priority: 'high',
    completed: false,
    createdAt: '2026-04-15T08:00:00',
    dueDate: '2026-04-16T08:00:00',
  },
];
