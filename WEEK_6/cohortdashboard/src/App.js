// src/App.js
import './App.css'; // Default App styling
import CohortDetails from './Components/CohortDetails'; // Import the CohortDetails component

function App() {
  return (
    <div className="App">
      <h1 style={{ textAlign: 'center', marginBottom: '30px', color: '#333' }}>Cohorts Details</h1>
      <div style={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center' }}>
        {/* Render multiple CohortDetails components with different data */}
        <CohortDetails
          id="INTADMDF10"
          name=".NET FSD"
          startedOn="22-Feb-2022"
          status="Scheduled"
          coach="Aathma"
          trainer="Jojo Jose"
        />
        <CohortDetails
          id="ADM21JF014"
          name="Java FSD"
          startedOn="10-Sep-2021"
          status="Ongoing"
          coach="Apoorv"
          trainer="Elisa Smith"
        />
        <CohortDetails
          id="CDBJF21025"
          name="Java FSD"
          startedOn="24-Dec-2021"
          status="Ongoing"
          coach="Aathma"
          trainer="John Doe"
        />
        {/* Add more cohorts as needed */}
      </div>
    </div>
  );
}

export default App;