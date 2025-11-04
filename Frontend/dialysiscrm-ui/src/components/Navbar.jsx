import React from "react";

function Navbar() {
  return (
    <nav className="bg-white/90 backdrop-blur-md shadow-sm sticky top-0 z-40">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-around items-center h-16">
          {/* Left: Logo + Nav Links */}
          <div className="flex items-center">
            <div className="flex-shrink-0">
              <h1 className="text-2xl font-bold bg-clip-text text-transparent bg-gradient-to-r from-teal-400 to-blue-500">
                DialysisCenter Pro
              </h1>
            </div>
            <div className="hidden md:block ml-10">
              <div className="flex items-baseline space-x-8">
                <a
                  href="/"
                  className="px-3 py-2 text-sm font-medium text-gray-700 hover:text-teal-500"
                >
                  Dashboard
                </a>
                <a
                  href="/patients"
                  className="px-3 py-2 text-sm font-medium text-gray-700 hover:text-teal-500"
                >
                  Patients
                </a>
                <a
                  href="/scheduling"
                  className="px-3 py-2 text-sm font-medium text-gray-700 hover:text-teal-500"
                >
                  Scheduling
                </a>
                <a
                  href="/analytics"
                  className="px-3 py-2 text-sm font-medium text-gray-700 hover:text-teal-500"
                >
                  Analytics
                </a>
              </div>
            </div>
          </div>

          {/* Right: Search + User */}
          <div className="flex items-center space-x-4">
            {/* Search */}
            <div className="relative">
              <input
                type="text"
                placeholder="Search patients..."
                className="w-64 px-4 py-2 text-sm border border-gray-300 rounded-lg focus:ring-2 focus:ring-teal-500 focus:border-transparent"
              />
              <svg
                className="absolute right-3 top-2.5 w-4 h-4 text-gray-400"
                fill="currentColor"
                viewBox="0 0 20 20"
              >
                <path
                  fillRule="evenodd"
                  d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z"
                  clipRule="evenodd"
                />
              </svg>
            </div>

            {/* User Info */}
            <div className="flex items-center space-x-3">
              <img
                src="resources/patient-avatars/patient-3.jpg"
                alt="User Avatar"
                className="w-8 h-8 rounded-full object-cover"
              />
              <div className="text-sm">
                <div className="font-medium text-gray-800">Dr. Umair Abid</div>
                <div className="text-gray-500 text-xs">Medical Director</div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </nav>
  );
}

export default Navbar;
