import { useEffect, useState } from "react";
import { getAllPatients } from "../../services/api";

function PatientList() {
  const [patients, setPatients] = useState([]);

  useEffect(() => {
    const fetchPatients = async () => {
      const data = await getAllPatients();
      setPatients(data);
    };
    fetchPatients();
  }, []);

  return (
    <div className="p-4">
      <h2>Patient List</h2>
      <table border="1" cellPadding="8" style={{ marginTop: "10px" }}>
        <thead>
          <tr>
            <th>ID</th>
            <th>Full Name</th>
            <th>Phone</th>
            <th>Email</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {patients.map((p) => (
            <tr key={p.id}>
              <td>{p.id}</td>
              <td>{p.fullName}</td>
              <td>{p.phone}</td>
              <td>{p.email}</td>
              <td>
                <button>👁️ View</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default PatientList;
