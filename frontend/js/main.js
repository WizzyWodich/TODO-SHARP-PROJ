document.addEventListener("DOMContentLoaded", () => {
  requireAuth();
  loadTodos();
});

async function requireAuth() {
  try {
    await api("/auth/me");
  } catch {
    window.location.href = "./pages/auth.html";
  }
}

async function logout() {
  try {
    await api("/auth/logout", {
      method: "POST",
    });

    window.location.href = "./pages/auth.html";
  } catch (err) {
    console.error(err);

    alert("Ошибка logout");
  }
}

async function addTodo() {
  const title = document.getElementById("todoTitle").value.trim();
  const description = document.getElementById("todoDescription").value.trim();
  const priority = parseInt(document.getElementById("todoPriority").value);
  const dueAtValue = document.getElementById("todoDueAt").value;

  if (!title) {
    alert("Введіть назву задачі");
    return;
  }

  const body = {
    title,
    description,
    priority,
    ...(dueAtValue ? { dueAt: new Date(dueAtValue).toISOString() } : {}),
  };

  try {
    await api("/todos", {
      method: "POST",
      body: JSON.stringify(body),
    });
    document.getElementById("todoTitle").value = "";
    document.getElementById("todoDescription").value = "";
    document.getElementById("todoPriority").value = "0";
    document.getElementById("todoDueAt").value = "";

    await loadTodos();
  } catch {
    alert("Помилка при додаванні задачі");
  }
}

async function loadTodos() {
  const todos = await api("/todos");
  const list = document.getElementById("todoList");
  list.innerHTML = "";

  todos.forEach((todo) => {
    const li = document.createElement("li");
    li.className = "todo-item" + (todo.isCompleted ? " completed" : "");
    li.innerHTML = `
      <div class="todo-check">
        <input type="checkbox" ${todo.isCompleted ? "checked" : ""}
              ${todo.isCompleted ? "disabled" : ""}
       onchange="toggleTodo('${todo.id}')" />
      </div>
      <div class="todo-body">
        <span class="todo-title">${todo.title}</span>
        ${todo.description ? `<span class="todo-desc">${todo.description}</span>` : ""}
        <div class="todo-meta">
          <span class="todo-priority priority-${todo.priority}">${priorityLabel(todo.priority)}</span>
          ${todo.dueAt ? `<span class="todo-due">${formatDate(todo.dueAt)}</span>` : ""}
        </div>
      </div>
      <button class="todo-delete" onclick="deleteTodo('${todo.id}')">
        <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
          <polyline points="3 6 5 6 21 6"/><path d="M19 6l-1 14H6L5 6"/><path d="M10 11v6M14 11v6"/>
          <path d="M9 6V4h6v2"/>
        </svg>
      </button>
    `;
    list.appendChild(li);
  });
}

function priorityLabel(p) {
  return ["Низький", "Середній", "Високий"][p] ?? "—";
}

function formatDate(iso) {
  return new Date(iso).toLocaleString("uk-UA", {
    day: "2-digit",
    month: "2-digit",
    year: "numeric",
    hour: "2-digit",
    minute: "2-digit",
  });
}

async function toggleTodo(id) {
  await api(`/todos/${id}/complete`, {
    method: "PATCH",
  });
  await loadTodos();
}

async function deleteTodo(id) {
  await api(`/todos/${id}`, { method: "DELETE" });
  await loadTodos();
}
