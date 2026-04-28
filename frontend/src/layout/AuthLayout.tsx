import React from "react";

export const AuthLayout = ({ children }: { children: React.ReactNode }) => {
  return (
    <div
      className="min-h-screen flex items-center justify-center
                 bg-gradient-to-br from-blue-100 via-purple-100 to-pink-100
                 px-4"
    >
      <div className="w-full flex justify-center">
        {children}
      </div>
    </div>
  );
};