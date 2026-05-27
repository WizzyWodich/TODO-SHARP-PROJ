const API_URL = "http://localhost:5150";

async function api(path, options = {}) {
  const response = await fetch(API_URL + path, {
    credentials: "include",

    headers: {
      "Content-Type": "application/json",
      ...(options.headers || {}),
    },

    ...options,
  });

  if (!response.ok) {
    throw new Error(`HTTP ${response.status}`);
  }

  const text = await response.text();

  return text ? JSON.parse(text) : null;
}
