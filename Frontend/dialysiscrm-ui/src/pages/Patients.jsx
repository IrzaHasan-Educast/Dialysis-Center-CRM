import React from 'react';
import AppNavbar from '../components/Navbar';
import Footer from '../components/Footer';
import PatientTable from '../components/patients/PatientTable';

const Patients = () => {
  return (
    <>
      <AppNavbar />
      <PatientTable />
      <Footer />
    </>
  );
};

export default Patients;
