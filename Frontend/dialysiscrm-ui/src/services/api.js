import axios from "axios";

const API_BASE_URL = "http://localhost:5277/api"; // backend base URL

const api = axios.create({
  baseURL: API_BASE_URL,
});

// Get all patients
export const getAllPatients = async () => {
  try {
    const response = await api.get("/Patient");
    return response.data;
  } catch (error) {
    console.error("Error fetching patients:", error);
    throw error;
  }
};

// Get single patient by ID
export const getPatientById = async (id) => {
  try {
    const response = await api.get(`/Patient/${id}`);
    return response.data;
  } catch (error) {
    console.error("Error fetching patient:", error);
    throw error;
  }
};
