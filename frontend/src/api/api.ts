const BASE_URL = "http://localhost:5150";

export async function apiRequest<T>(
    url: string,
    options: RequestInit = {}
): Promise<T> {
    const response = await fetch(BASE_URL + url, {
        headers: {
            "Content-Type": "application/json",
            ...options.headers,
        },
        ...options,
        credentials: "include",
    });

    if (!response.ok) {
        throw new Error("API error");
    }

    const contentLength = response.headers.get("Content-Length");
    const contentType = response.headers.get("Content-Type");

    if (
        response.status === 204 ||
        contentLength === "0" ||
        !contentType?.includes("application/json")
    ) {
        return undefined as T;
    }

    return response.json();
}