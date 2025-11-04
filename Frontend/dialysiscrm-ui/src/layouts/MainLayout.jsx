import React from "react";
import Navbar from "../components/Navbar";

const MainLayout = ({ children }) => {
  return (
      <div className="flex-1 flex flex-col">
        <Navbar />
        <main className="flex-1 overflow-y-auto p-6">{children}</main>
      </div>
  );
};

export default MainLayout;
