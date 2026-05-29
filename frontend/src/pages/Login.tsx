import { useLoginForm } from "../hooks/useLoginForm"

export default function Login() {
    const { form, handleFormChange, handleSubmit } = useLoginForm();

    return (
        <div className="h-screen bg-gray-100 flex items-center justify-center">
            <div className="bg-white p-8 rounded shadow-md w-full max-w-md">
                <h2 className="text-2xl font-bold mb-6 text-center">Login</h2>
                <form className="space-y-4 " onSubmit={handleSubmit}>
                    <div>
                        <label htmlFor="username" className="block text-sm font-medium text-gray-700">Username</label>
                        <input type="text" id="username" name="username" className="mt-1 block w-full px-3 py-2 border
                         border-gray-300 rounded-md shadow-sm focus:outline-none
                         focus:ring-blue-500 focus:border-blue-500" placeholder="Enter your username" value={form.username} onChange={handleFormChange}/>
                    </div>
                    <div>
                        <label htmlFor="password" className="block text-sm font-medium text-gray-700">Password</label>
                        <input type="password" id="password" name="password" className="mt-1 block w-full px-3 py-2 border
                        border-gray-300 rounded-md shadow-sm transition-color duration-300 ease-in-out focus:outline-none focus:ring-blue-500
                         focus:border-blue-500" placeholder="Enter your password" value={form.password} onChange={handleFormChange} />
                    </div>
                    <button type="submit" className="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2">Login</button>
                </form>
            </div>
        </div>
    )
}