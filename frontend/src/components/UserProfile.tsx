import { useState } from 'react';
import { FaUser, FaAt } from '../assets/icons';

export function UserProfile() {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [field, setField] = useState(null);

  return (
    <>
      <div className="bg-white/60 backdrop-blur-xl p-4 rounded-2xl border border-white/50 shadow flex flex-col">
        <h1 className="text-xl font-bold">Profile</h1>

        <div className="flex justify-center mt-4 relative">
          <div className="absolute w-28 h-28 bg-purple-400/30 rounded-full blur-2xl"></div>

          <div className="relative flex items-center justify-center w-24 h-24 rounded-full bg-white/40 backdrop-blur-xl border border-white/40 shadow">
            <FaUser className="w-10 h-10 text-purple-400" />
          </div>
        </div>

        <div className="flex flex-col gap-4 mt-6">
          <div className="flex justify-between items-center">
            <div className="flex items-center gap-3">
              <FaUser className="text-purple-400" />
              <div>
                <p className="text-sm text-gray-400">Username</p>
                <p className="font-medium">WizzyWodich</p>
              </div>
            </div>

            <button
              onClick={() => {
                setField('username');
                setIsModalOpen(true);
              }}
              className="bg-purple-400 text-white rounded-xl px-3 py-1 text-sm hover:bg-purple-500 transition"
            >
              Edit
            </button>
          </div>

          <div className="flex justify-between items-center">
            <div className="flex items-center gap-3">
              <FaAt className="text-purple-400" />
              <div>
                <p className="text-sm text-gray-500">Email</p>
                <p className="font-medium">example@mail.com</p>
              </div>
            </div>

            <button
              onClick={() => {
                setField('email');
                setIsModalOpen(true);
              }}
              className="bg-purple-400 text-white rounded-xl px-3 py-1 text-sm hover:bg-purple-500 transition"
            >
              Edit
            </button>
          </div>
        </div>
      </div>

      {isModalOpen && (
        <div className="fixed inset-0 bg-black/50 flex justify-center items-center">
          <div className="bg-white p-6 rounded-xl w-80 scale-100 animate-in fade-in zoom-in">
            <h2 className="text-lg font-bold mb-4">Edit {field}</h2>

            <input
              type="text"
              className="w-full border p-2 rounded mb-4"
              placeholder={`Enter new ${field}`}
            />

            <div className="flex justify-end gap-2">
              <button
                onClick={() => setIsModalOpen(false)}
                className="px-3 py-1 bg-gray-300 rounded"
              >
                Cancel
              </button>

              <button className="px-3 py-1 bg-purple-500 text-white rounded">
                Save
              </button>
            </div>
          </div>
        </div>
      )}
    </>
  );
}
