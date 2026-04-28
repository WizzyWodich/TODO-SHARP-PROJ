import { FaEnvelope, FaLock, FaSignInAlt } from '../assets/icons';
import { InputField } from '../components/InputField';
import { PageWrapper } from '../components/PageWrapper';

export function LoginPage() {
  return (
    <PageWrapper>
      <div className="min-h-screen flex items-center justify-center px-4">
        <div
          className="bg-white/70 backdrop-blur-xl p-4 md:p-8 rounded-2xl w-full max-w-sm
                     shadow-xl border border-white/50"
        >
          <form className="flex flex-col gap-5">
            <h3 className="text-xl md:text-2xl font-semibold text-center text-gray-700">
              Login
            </h3>

            <InputField icon={FaEnvelope} type="email" placeholder="Email" />
            <InputField icon={FaLock} type="password" placeholder="Password" />

            <button
              className="group bg-purple-400 text-white rounded-2xl py-3 md:py-2
                         hover:bg-purple-500 transition
                         flex items-center justify-center gap-2"
              type="submit"
            >
              Login
              <FaSignInAlt className="transition-transform group-hover:translate-x-1" />
            </button>

            <a
              href="/registration"
              className="text-center text-sm text-purple-500 hover:text-purple-600 transition"
            >
              Don't have an account? Register
            </a>
          </form>
        </div>
      </div>
    </PageWrapper>
  );
}
