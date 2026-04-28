import { PageWrapper } from '../components/PageWrapper';
import { UserProfile } from '../components/UserProfile';
import { StatBar } from '../components/StatBar';

export function Settings() {
  const total = 10;
  const completed = 6;
  const pending = total - completed;

  return (
    <PageWrapper>
      <div className="grid grid-cols-1 md:grid-cols-2 gap-4 items-start text-gray-600">
        {/* Profile */}
        <div className="transition-all duration-300">
          <UserProfile />
        </div>

        <div className="bg-white/60 backdrop-blur-xl p-4 rounded-2xl border border-white/50 shadow">
          <h1 className="text-xl font-bold">Statistic</h1>

          <div className="mt-4 flex flex-col gap-3 text-sm">
            <div className="space-y-3">
              <StatBar label="Total" value={total} total={total} />
              <StatBar
                label="Done"
                value={completed}
                total={total}
                color="bg-green-300"
              />
              <StatBar
                label="Left"
                value={pending}
                total={total}
                color="bg-red-300"
              />
            </div>
          </div>
        </div>
      </div>
    </PageWrapper>
  );
}
