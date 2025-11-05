import React, { useState } from "react";
import { Modal, Button, Form, Nav } from "react-bootstrap";
import axios from "axios";
import "../styles/AddPatientModal.css";

const AddPatientModal = ({ show, handleClose, refreshPatients }) => {
  const [step, setStep] = useState(1);
  const [formData, setFormData] = useState({
    fullName: "",
    dateOfBirth: "",
    gender: "",
    phone: "",
    email: "",
    address: "",
    medicalInfo: {
      diagnosis: "",
      chronicConditions: "",
      treatmentPlan: "",
      referringPhysician: "",
      physicianContact: "",
    },
    insurance: {
      provider: "",
      policyNumber: "",
      coverage: "",
    },
  });

  const handleChange = (e, section) => {
    const { name, value } = e.target;
    if (section) {
      setFormData((prev) => ({
        ...prev,
        [section]: { ...prev[section], [name]: value },
      }));
    } else {
      setFormData((prev) => ({ ...prev, [name]: value }));
    }
  };

  const handleNext = () => setStep((s) => s + 1);
  const handleBack = () => setStep((s) => s - 1);

  const handleSubmit = async () => {
    try {
      await axios.post("http://localhost:5277/api/Patient", formData);
      alert("Patient added successfully!");
      handleClose();
      refreshPatients(); // refresh table after adding
    } catch (error) {
      console.error("Error adding patient:", error);
      alert("Something went wrong. Check console for details.");
    }
  };

  return (
    <Modal show={show} onHide={handleClose} size="lg" centered>
      <Modal.Header closeButton>
        <Modal.Title>Add New Patient</Modal.Title>
      </Modal.Header>

      <Modal.Body>
        <Nav variant="tabs" activeKey={step}>
          <Nav.Item>
            <Nav.Link eventKey={1} onClick={() => setStep(1)}>
              Basic Information
            </Nav.Link>
          </Nav.Item>
          <Nav.Item>
            <Nav.Link eventKey={2} onClick={() => setStep(2)}>
              Medical History
            </Nav.Link>
          </Nav.Item>
          <Nav.Item>
            <Nav.Link eventKey={3} onClick={() => setStep(3)}>
              Insurance & Documents
            </Nav.Link>
          </Nav.Item>
        </Nav>

        {/* Step 1: Basic Info */}
        {step === 1 && (
          <Form className="mt-4">
            <Form.Group className="mb-3">
              <Form.Label>Full Name</Form.Label>
              <Form.Control
                name="fullName"
                value={formData.fullName}
                onChange={handleChange}
                placeholder="Enter full name"
              />
            </Form.Group>

            <Form.Group className="mb-3">
              <Form.Label>Date of Birth</Form.Label>
              <Form.Control
                type="date"
                name="dateOfBirth"
                value={formData.dateOfBirth}
                onChange={handleChange}
              />
            </Form.Group>

            <Form.Group className="mb-3">
              <Form.Label>Gender</Form.Label>
              <Form.Select
                name="gender"
                value={formData.gender}
                onChange={handleChange}
              >
                <option value="">Select gender</option>
                <option value="Male">Male</option>
                <option value="Female">Female</option>
              </Form.Select>
            </Form.Group>

            <Form.Group className="mb-3">
              <Form.Label>Phone</Form.Label>
              <Form.Control
                name="phone"
                value={formData.phone}
                onChange={handleChange}
                placeholder="Enter phone"
              />
            </Form.Group>

            <Form.Group className="mb-3">
              <Form.Label>Email</Form.Label>
              <Form.Control
                type="email"
                name="email"
                value={formData.email}
                onChange={handleChange}
                placeholder="Enter email"
              />
            </Form.Group>

            <Form.Group>
              <Form.Label>Address</Form.Label>
              <Form.Control
                name="address"
                value={formData.address}
                onChange={handleChange}
                placeholder="Enter address"
              />
            </Form.Group>
          </Form>
        )}

        {/* Step 2: Medical Info */}
        {step === 2 && (
          <Form className="mt-4">
            <Form.Group className="mb-3">
              <Form.Label>Diagnosis</Form.Label>
              <Form.Control
                name="diagnosis"
                value={formData.medicalInfo.diagnosis}
                onChange={(e) => handleChange(e, "medicalInfo")}
                placeholder="Enter diagnosis"
              />
            </Form.Group>

            <Form.Group className="mb-3">
              <Form.Label>Chronic Conditions</Form.Label>
              <Form.Control
                name="chronicConditions"
                value={formData.medicalInfo.chronicConditions}
                onChange={(e) => handleChange(e, "medicalInfo")}
                placeholder="Enter chronic conditions"
              />
            </Form.Group>

            <Form.Group className="mb-3">
              <Form.Label>Treatment Plan</Form.Label>
              <Form.Control
                name="treatmentPlan"
                value={formData.medicalInfo.treatmentPlan}
                onChange={(e) => handleChange(e, "medicalInfo")}
                placeholder="Enter treatment plan"
              />
            </Form.Group>

            <Form.Group className="mb-3">
              <Form.Label>Referring Physician</Form.Label>
              <Form.Control
                name="referringPhysician"
                value={formData.medicalInfo.referringPhysician}
                onChange={(e) => handleChange(e, "medicalInfo")}
                placeholder="Enter physician name"
              />
            </Form.Group>

            <Form.Group>
              <Form.Label>Physician Contact</Form.Label>
              <Form.Control
                name="physicianContact"
                value={formData.medicalInfo.physicianContact}
                onChange={(e) => handleChange(e, "medicalInfo")}
                placeholder="Enter physician contact"
              />
            </Form.Group>
          </Form>
        )}

        {/* Step 3: Insurance */}
        {step === 3 && (
          <Form className="mt-4">
            <Form.Group className="mb-3">
              <Form.Label>Insurance Provider</Form.Label>
              <Form.Control
                name="provider"
                value={formData.insurance.provider}
                onChange={(e) => handleChange(e, "insurance")}
                placeholder="Enter insurance provider"
              />
            </Form.Group>

            <Form.Group className="mb-3">
              <Form.Label>Policy Number</Form.Label>
              <Form.Control
                name="policyNumber"
                value={formData.insurance.policyNumber}
                onChange={(e) => handleChange(e, "insurance")}
                placeholder="Enter policy number"
              />
            </Form.Group>

            <Form.Group>
              <Form.Label>Coverage Details</Form.Label>
              <Form.Control
                name="coverage"
                value={formData.insurance.coverage}
                onChange={(e) => handleChange(e, "insurance")}
                placeholder="Enter coverage details"
              />
            </Form.Group>
          </Form>
        )}
      </Modal.Body>

      <Modal.Footer>
        {step > 1 && (
          <Button variant="secondary" onClick={handleBack}>
            Back
          </Button>
        )}
        {step < 3 && (
          <Button variant="teal" onClick={handleNext}>
            Next
          </Button>
        )}
        {step === 3 && (
          <Button variant="success" onClick={handleSubmit}>
            Submit
          </Button>
        )}
        <Button variant="outline-secondary" onClick={handleClose}>
          Cancel
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default AddPatientModal;
