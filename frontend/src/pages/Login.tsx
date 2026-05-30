import { CheckSquare } from "lucide-react";
import { useLoginForm } from "../hooks/useLoginForm"
import PageTransition from "../components/PageTransition";

export default function Login() {
    const { form, handleFormChange, handleSubmit } = useLoginForm();

    return (
        <PageTransition>
            <div className="min-h-screen bg-[#20211f] flex items-center justify-center">
                <div className="bg-[#171717] border border-zinc-800 rounded-3xl p-9 w-full max-w-md">

                    <div className="w-10 h-10 rounded-xl bg-cyan-500/15 border border-cyan-500 flex items-center justify-center mx-auto mb-6">
                        <CheckSquare size={18} className="text-cyan-500" />
                    </div>

                    <h2 className="text-[22px] font-semibold text-white text-center mb-1">
                        Вітаємо назад
                    </h2>
                    <p className="text-sm text-zinc-500 text-center mb-7">
                        Увійдіть у свій акаунт
                    </p>

                    <form onSubmit={handleSubmit} className="space-y-4">
                        <div>
                            <label className="block text-xs text-zinc-500 font-medium mb-1.5 tracking-wide">
                                Ім'я користувача
                            </label>
                            <input
                                type="text"
                                name="username"
                                placeholder="your_username"
                                value={form.username}
                                onChange={handleFormChange}
                                className="w-full bg-zinc-800 border border-zinc-700 rounded-xl px-3.5 py-2.5 text-sm text-white placeholder:text-zinc-600 outline-none focus:border-cyan-500 transition-colors"
                            />
                        </div>

                        <div>
                            <label className="block text-xs text-zinc-500 font-medium mb-1.5 tracking-wide">
                                Пароль
                            </label>
                            <input
                                type="password"
                                name="password"
                                placeholder="••••••••"
                                value={form.password}
                                onChange={handleFormChange}
                                className="w-full bg-zinc-800 border border-zinc-700 rounded-xl px-3.5 py-2.5 text-sm text-white placeholder:text-zinc-600 outline-none focus:border-cyan-500 transition-colors"
                            />
                        </div>

                        <button
                            type="submit"
                            className="w-full bg-cyan-500 hover:bg-cyan-400 text-black text-sm font-semibold rounded-xl py-2.5 transition-colors mt-2"
                        >
                            Увійти
                        </button>
                    </form>

                    <div className="flex items-center gap-3 my-5">
                        <div className="flex-1 h-px bg-zinc-800" />
                        <span className="text-xs text-zinc-600">або</span>
                        <div className="flex-1 h-px bg-zinc-800" />
                    </div>

                    <p className="text-center text-sm text-zinc-500">
                        Немає акаунту?{" "}
                        <a href="/register" className="text-cyan-500 hover:text-cyan-400 transition-colors">
                            Зареєструватись
                        </a>
                    </p>
                </div>
            </div>
        </PageTransition>

    );
}