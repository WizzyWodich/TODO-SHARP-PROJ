import TaskItem from "./TaskItem";

interface Task {
    id: number;
    title: string;
    category: string;
    completed: boolean;
}

interface TaskListProps {
    tasks: Task[];
    onToggle: (id: number) => void;
}

export default function TaskList({ tasks, onToggle }: TaskListProps) {
    return (
        <div className="flex flex-col gap-2">
            {tasks.map((task) => (
                <TaskItem
                    key={task.id}
                    title={task.title}
                    category={task.category}
                    completed={task.completed}
                    onToggle={() => onToggle(task.id)}
                />
            ))}
        </div>
    );
}