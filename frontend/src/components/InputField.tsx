import type { ComponentType, InputHTMLAttributes } from 'react';

type InputFieldProps = {
  icon: ComponentType<{ className?: string }>;
} & InputHTMLAttributes<HTMLInputElement>;

export function InputField({ icon: Icon, ...props }: InputFieldProps) {
  return (
    <div className="border-b border-gray-300 focus-within:border-purple-400 transition">
      <div className="flex items-center gap-2 text-gray-500">
        <Icon />
        <input
          {...props}
          className="w-full bg-transparent py-2 outline-none text-gray-700"
        />
      </div>
    </div>
  );
}
