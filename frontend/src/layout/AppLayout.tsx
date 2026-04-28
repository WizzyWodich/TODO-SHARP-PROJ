import { NavLink, Outlet } from 'react-router-dom';
import { FaHome, FaUser, FaSignOutAlt } from 'react-icons/fa';

export const AppLayout = () => {
  const navItems = [
    { to: '/home', label: 'Main', icon: FaHome },
    { to: '/home/settings', label: 'Profile', icon: FaUser },
  ];

  const linkClass = ({ isActive }) => `
    flex items-center gap-2 rounded-xl transition

    px-3 py-2 text-sm

    md:px-4 md:py-3 md:text-base

    ${
      isActive
        ? 'bg-purple-100 text-purple-600 font-medium'
        : 'text-gray-600 hover:bg-purple-100'
    }
  `;

  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-100 via-purple-100 to-pink-100">
      <aside
        className="
          fixed left-0 right-0 h-16 bottom-0
          md:top-0 md:bottom-auto md:h-screen md:w-[220px]

          bg-white/60 backdrop-blur-xl border-t md:border-t-0 md:border-r border-white/50
          z-50

          flex
          justify-center items-center gap-6

          md:flex-col md:justify-start md:items-start md:gap-4 md:p-4
        "
      >
        <h1 className="hidden md:block text-3xl font-bold pb-5">TodoApp</h1>

        <nav className="flex md:flex-col gap-4 md:w-full">
          {navItems.map((item) => {
            const Icon = item.icon;

            return (
              <NavLink key={item.to} to={item.to} end className={linkClass}>
                <Icon className="text-xl" />
                <span className="md:inline hidden">{item.label}</span>
              </NavLink>
            );
          })}
        </nav>

        <button className="hidden md:flex mt-auto items-center gap-2 text-red-500">
          <FaSignOutAlt />
          Logout
        </button>
      </aside>

      {/* CONTENT */}
      <main
        className="
          p-4 min-h-screen
          md:ml-[220px]
          pb-20 md:pb-4
          overflow-x-hidden
        "
      >
        <Outlet />
      </main>
    </div>
  );
};
