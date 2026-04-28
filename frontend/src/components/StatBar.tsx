import { motion } from 'framer-motion';

type StatBarProps = {
  label: string;
  value: number;
  total: number;
  color?: string;
};

export function StatBar({
  label,
  value,
  total,
  color = 'bg-transpare',
}: StatBarProps) {
  const percent = total === 0 ? 0 : (value / total) * 100;

  return (
    <div>
      <div className="flex justify-between mb-1">
        <span>{label}</span>
        <span>{value}</span>
      </div>

      <div className="w-full h-2 bg-white/40 rounded-full overflow-hidden">
        <motion.div
          className={`h-full ${color}`}
          initial={{ width: 0 }}
          animate={{ width: `${percent}%` }}
          transition={{
            duration: 0.8,
            ease: [0.25, 0.1, 0.25, 1],
          }}
        />
      </div>
    </div>
  );
}
