import React from "react";
import { Route, Routes } from "react-router-dom";
import './App.css';
import HomePage from './Components/HomePage'
import EmployeDetails from './Components/EmployeDetails'

function App() {
  return (
    <div className="welcome-body">
      <div className="container mt-5">
        <Routes>
          <Route path='/' element={<HomePage />} />
          <Route path='/details/:id' element={<EmployeDetails />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
