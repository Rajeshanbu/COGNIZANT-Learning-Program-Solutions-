import React from 'react';
import '../Stylesheets/mystyle.css'; // Import the CSS file

// Functional component to calculate and display student score
// It accepts props: name, school, total, and goal
function CalculateScore(props) {
    // Destructure props for easier access
    const { name, school, total, goal } = props;

    // Calculate the average score
    const average = total / 2; // Assuming 'total' is sum of 2 scores for simplicity

    // Determine if the goal is met
    const goalMet = average >= goal ? 'Yes' : 'No';

    return (
        <div className="score-card"> {/* Apply a CSS class */}
            <h2>Student Score Card</h2>
            <p><strong>Name:</strong> {name}</p>
            <p><strong>School:</strong> {school}</p>
            <p><strong>Total Score:</strong> {total}</p>
            <p><strong>Average Score:</strong> {average.toFixed(2)}</p> {/* Display average with 2 decimal places */}
            <p><strong>Goal:</strong> {goal}</p>
            <p><strong>Goal Met:</strong> {goalMet}</p>
        </div>
    );
}

export default CalculateScore;