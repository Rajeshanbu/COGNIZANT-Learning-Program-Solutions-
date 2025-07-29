// src/App.js
import './App.css'; // Imports the default CSS for the App component.
import ListofPlayers from './Components/ListofPlayers'; // Import the ListofPlayers component.
import IndianPlayers from './Components/IndianPlayers'; // Import the IndianPlayers component.

/**
 * The main App component that conditionally renders different player lists.
 * This demonstrates how to switch between different components based on a condition.
 * @returns {JSX.Element} The rendered React elements.
 */
function App() {
    // This 'flag' variable controls which set of components is displayed.
    // Change it to 'false' to see the IndianPlayers output.
    const flag = true; // Set to 'true' to show ListofPlayers; set to 'false' to show IndianPlayers.
    // Use 'const' for variables that are not reassigned (modern JS best practice).

    // Sample data for the 'players' prop of the ListofPlayers component.
    // Currently has 12 players. If exactly 11 are required, remove one entry.
    const players = [
        { name: 'Rohit Sharma', score: 264 }, // Added Rohit Sharma as requested
        { name: 'Jack', score: 50 },
        { name: 'Michael', score: 70 },
        { name: 'John', score: 40 },
        { name: 'Ann', score: 61 },
        { name: 'Elisabeth', score: 61 },
        { name: 'Sachin', score: 95 },
        { name: 'Dhoni', score: 100 },
        { name: 'Virat', score: 84 },
        { name: 'Jadeja', score: 64 },
        { name: 'Raina', score: 75 },
        { name: 'Rohit', score: 80 },
    ];

    // Sample data for the 'indianTeam' prop of the IndianPlayers component.
    // This array needs at least 6 elements for the OddPlayers and EvenPlayers destructuring examples to work well.
    const indianTeamPlayers = [
        'Sachin1', 'Dhoni2', 'Virat3', 'Rohit4', 'Yuvraj5', 'Raina6'
    ];

    return (
        <div className="App">
            {/* Conditional rendering using a ternary operator (modern equivalent of if-else in JSX) */}
            {flag ? (
                // Render ListofPlayers when flag is true
                <div>
                    <ListofPlayers players={players} />
                </div>
            ) : (
                // Render IndianPlayers when flag is false
                <div>
                    <IndianPlayers indianTeam={indianTeamPlayers} />
                </div>
            )}
        </div>
    );
}

// Export the App component as the default export.
export default App;
