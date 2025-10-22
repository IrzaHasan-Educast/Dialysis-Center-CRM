const form = document.getElementById("add-patient");

form.addEventListener("submit", saveForm);

function saveForm(event) {
  event.preventDefault();

  const firstName = document.getElementById("firstName").value.trim();
  const lastName = document.getElementById("lastName").value.trim();
  const email = document.getElementById("inputEmail").value.trim();
  const age = document.getElementById("age").value.trim();
  const address = document.getElementById("inputAddress").value.trim();
  const country = document.getElementById("inputCountry").value.trim();
  const city = document.getElementById("inputCity").value.trim();
  const zip = document.getElementById("inputZip").value.trim();

  const errorMsg = document.getElementById("error-msg");

  if (
    firstName === "" ||
    lastName === "" ||
    email === "" ||
    age === "" ||
    address === "" ||
    country === "Choose..." ||
    city === "Choose..." ||
    zip === ""
  ) {
    errorMsg.style.color = "red";
    errorMsg.innerText = "⚠️ Please fill all fields before submitting!";
    return;
  }

  errorMsg.innerText = "";

  // Example: Add new row to table
  const tbody = document.querySelector("tbody");
  const newRow = document.createElement("tr");
  newRow.innerHTML = `
    <td>#</td>
    <td>${firstName}</td>
    <td>${lastName}</td>
    <td>${email}</td>
    <td>${age}</td>
    <td>${address}</td>
    <td>${country}</td>
  `;
  tbody.appendChild(newRow);

  form.reset();
}
