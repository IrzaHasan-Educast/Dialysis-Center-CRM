import React from "react";
import PatientTable from "../components/patients/PatientTable";

const Patients = () => {
  return (
    <div>
      <h2 className="text-3xl font-semibold text-gray-800 mb-4">Patients</h2>
      <PatientTable />
    </div>
  );
};

export default Patients;
