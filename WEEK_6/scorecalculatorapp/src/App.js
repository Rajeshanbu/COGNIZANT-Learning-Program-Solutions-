import './App.css'; // Default App styling
import CalculateScore from './Components/CalculateScore'; // Import the CalculateScore component

function App() {
  return (
    <div className="App">
      {/* Render the CalculateScore component with example props */}
      <CalculateScore
        name="John Doe"
        school="Central High"
        total={180} // Example total score
        goal={90}    // Example goal score
      />

      {/* You can add more instances of CalculateScore with different data if you like */}
      <CalculateScore
        name="Jane Smith"
        school="North Academy"
        total={195}
        goal={95}
      />
    </div>
  );
}

export default App;