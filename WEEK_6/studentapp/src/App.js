import './App.css'; // This imports the default styling for the App component
import Home from './Components/Home';      // Corrected import path for Home component
import About from './Components/About';    // Corrected import path for About component
import Contact from './Components/Contact';  // Corrected import path for Contact component

/**
 * The main App component that renders the Home, About, and Contact components.
 * This is a functional component, a common way to define components in modern React.
 *
 * @returns {JSX.Element} The rendered React elements.
 */
function App() {
  return (
    <div className="App">
      {/* Render the Home component */}
      <Home />
      {/* Render the About component */}
      <About />
      {/* Render the Contact component */}
      <Contact />
    </div>
  );
}

export default App; // Export the App component so it can be used in index.js
