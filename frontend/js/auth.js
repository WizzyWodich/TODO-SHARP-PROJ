document.addEventListener("DOMContentLoaded", () => {
  const loginBtn = document.getElementById("loginBtn");
  const registerBtn = document.getElementById("registerBtn");

  loginBtn.addEventListener("click", login);
  registerBtn.addEventListener("click", register);

  document.getElementById("loginBtn").addEventListener("click", login);
  document.getElementById("registerBtn").addEventListener("click", register);

  document.getElementById("showRegister").addEventListener("click", (e) => {
    e.preventDefault();
    document.getElementById("loginForm").classList.add("hidden");
    document.getElementById("registerForm").classList.remove("hidden");
  });

  document.getElementById("showLogin").addEventListener("click", (e) => {
    e.preventDefault();
    document.getElementById("registerForm").classList.add("hidden");
    document.getElementById("loginForm").classList.remove("hidden");
  });
});

async function login(e) {
  e.preventDefault();

  const userName = document.getElementById("loginName").value;
  const password = document.getElementById("loginPassword").value;

  try {
    const response = await api("/auth/login", {
      method: "POST",
      body: JSON.stringify({
        userName,
        password,
      }),
    });

    console.log("Login response:", response);
    window.location.href = "../index.html";
  } catch (error) {
    console.error("Login error:", error);
    alert("Неверный логин или пароль");
  }
}

async function register(e) {
  e.preventDefault();

  const userName = document.getElementById("registerName").value;
  const password = document.getElementById("registerPassword").value;

  try {
    await api("/auth/register", {
      method: "POST",
      body: JSON.stringify({
        userName,
        password,
      }),
    });

    alert("Аккаунт создан");

    registerForm.classList.add("hidden");

    loginForm.classList.remove("hidden");
  } catch {
    alert("Ошибка регистрации");
  }
}
