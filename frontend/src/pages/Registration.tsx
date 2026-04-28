import { FaEnvelope, FaLock, FaPlus, FaUser } from '../assets/icons';
import { InputField } from '../components/InputField';
import { PageWrapper } from '../components/PageWrapper';

export function RegistrationPage() {
  return (
    <PageWrapper>
      <div className="min-h-screen flex items-center justify-center px-4">
        <div
          className="bg-white/70 backdrop-blur-xl p-4 md:p-8 rounded-2xl w-full max-w-sm
                     shadow-xl border border-white/50"
        >
          <form className="flex flex-col gap-5">
            <h3 className="text-xl md:text-2xl font-semibold text-center text-gray-700">
              Register
            </h3>

            <InputField icon={FaUser} type="text" placeholder="Username" />
            <InputField icon={FaEnvelope} type="email" placeholder="Email" />
            <InputField icon={FaLock} type="password" placeholder="Password" />
            <InputField
              icon={FaLock}
              type="password"
              placeholder="Confirm password"
            />

            <button
              className="group bg-purple-400 text-white rounded-2xl py-3 md:py-2
                         hover:bg-purple-500 transition
                         flex items-center justify-center gap-2"
              type="submit"
            >
              Register
              <FaPlus className="transition-transform group-hover:scale-110 group-hover:translate-x-1" />
            </button>

            <a
              href="/login"
              className="text-center text-sm text-purple-500 hover:text-purple-600 transition"
            >
              Already have an account? Login
            </a>
          </form>
        </div>
      </div>
    </PageWrapper>
  );
}
