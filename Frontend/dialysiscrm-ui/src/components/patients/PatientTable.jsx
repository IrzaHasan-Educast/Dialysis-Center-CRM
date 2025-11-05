import React, { useEffect, useState } from "react";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import "../styles/PatientTable.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEye } from "@fortawesome/free-solid-svg-icons";

const PatientTable = () => {
  const [patients, setPatients] = useState([]);

  useEffect(() => {
    axios
      .get("http://localhost:5277/api/Patient")
      .then((response) => setPatients(response.data))
      .catch((error) => console.error("Error fetching patients:", error));
  }, []);

  return (
    <div className="container mt-5 p-5 patient-page">
      <div className="d-flex justify-content-between align-items-center mb-4">
        <h2 className="fw-bold title-text">Patient Management</h2>
        <div>
          <button className="btn btn-teal me-2">+ Add New Patient</button>
          <button className="btn btn-outline-secondary">Export Data</button>
        </div>
      </div>

      <p className="text-muted mb-4">
        Comprehensive patient profiles, intake, and compliance tracking
      </p>

      <div className="table-responsive p-3 shadow">
        <table className="table custom-table">
          <thead>
            <tr>
              <th>#</th>
              <th>Full Name</th>
              <th>Email</th>
              <th>Phone</th>
              <th>Address</th>
              <th>Gender</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {patients.map((patient, index) => (
              <tr key={patient.id}>
                <td>{index + 1}</td>
                <td>{patient.fullName}</td>
                <td>{patient.email}</td>
                <td>{patient.phone}</td>
                <td>{patient.address || "-"}</td>
                <td>{patient.gender || "-"}</td>
                <td>
                  <button className="btn btn-link text-secondary">
                    <FontAwesomeIcon icon={faEye} />
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default PatientTable;
