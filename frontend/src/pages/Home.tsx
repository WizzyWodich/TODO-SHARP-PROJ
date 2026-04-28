import { CreateTodoComponent } from '../components/CreateTodo';
import { PageWrapper } from '../components/PageWrapper';
import { TodoList } from '../components/TodoList';

export function Home() {
  return (
    <PageWrapper>
      <div className="flex flex-col gap-4">
        <CreateTodoComponent />
        <TodoList />
      </div>
    </PageWrapper>
  );
}
