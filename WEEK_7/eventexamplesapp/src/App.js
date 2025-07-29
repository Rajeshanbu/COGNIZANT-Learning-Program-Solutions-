import React, { Component } from 'react';
import './App.css';

class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            counter: 0
        };
        // Binding 'this' for methods to ensure it refers to the component instance
        this.incrementCounter = this.incrementCounter.bind(this);
        this.decrementCounter = this.decrementCounter.bind(this);
        this.sayHelloMessage = this.sayHelloMessage.bind(this);
        this.increaseAndSayHello = this.increaseAndSayHello.bind(this);
        this.sayWelcome = this.sayWelcome.bind(this);
        this.handleSyntheticClick = this.handleSyntheticClick.bind(this); // Bind for synthetic event
    }

    // Method to increment the counter value 
    incrementCounter() {
        this.setState(prevState => ({
            counter: prevState.counter + 1
        }));
        console.log('Counter Incremented!');
    }

    // Method to decrement the counter value 
    decrementCounter() {
        this.setState(prevState => ({
            counter: prevState.counter - 1
        }));
        console.log('Counter Decremented!');
    }

    // Method to say a static message 
    sayHelloMessage() {
        alert('Hello! This is a static message.');
        console.log('Hello message displayed.');
    }

    // Method to invoke multiple methods 
    increaseAndSayHello() {
        this.incrementCounter(); // Invokes incrementCounter 
        this.sayHelloMessage(); // Invokes sayHelloMessage 
    }

    // Method that takes 'welcome' as an argument 
    sayWelcome(message) {
        alert(message);
        console.log(`Message received: ${message}`);
    }

    // Event handler for synthetic event (using onClick for web, similar to OnPress concept) 
    handleSyntheticClick(event) {
        alert('I was clicked using a synthetic event!');
        console.log('Synthetic event triggered:', event);
    }

    render() {
        return (
            <div className="App" style={{ textAlign: 'center', marginTop: '50px' }}>
                <h1>Counter: {this.state.counter}</h1>

                {/* Increment button to increase the value of the counter  */}
                <button onClick={this.incrementCounter} style={{ margin: '10px', padding: '10px 20px' }}>
                    Increment
                </button>

                {/* Decrement button to decrease the value of the counter  */}
                <button onClick={this.decrementCounter} style={{ margin: '10px', padding: '10px 20px' }}>
                    Decrement
                </button>
                <hr />

                {/* "Increase" button should invoke multiple methods  */}
                <button onClick={this.increaseAndSayHello} style={{ margin: '10px', padding: '10px 20px' }}>
                    Increase (and Say Hello)
                </button>
                <hr />

                {/* Create a button "Say Welcome" which invokes the function which takes “welcome” as an argument.  */}
                <button onClick={() => this.sayWelcome('Welcome!')} style={{ margin: '10px', padding: '10px 20px' }}>
                    Say Welcome
                </button>
                <hr />

                {/* Create a button which invokes synthetic event “OnPress” which display “I was clicked”  */}
                {/* Note: "OnPress" is commonly associated with React Native. For web React, 'onClick' is the standard synthetic event for a click. */}
                <button onClick={this.handleSyntheticClick} style={{ margin: '10px', padding: '10px 20px' }}>
                    Trigger Synthetic Event (Click)
                </button>
                <hr />

                {/* CurrencyConvertor component will be rendered here [cite: 24] */}
                <CurrencyConvertor />
            </div>
        );
    }
}

// Create a “CurrencyConvertor” component [cite: 24]
class CurrencyConvertor extends Component {
    constructor(props) {
        super(props);
        this.state = {
            rupees: '',
            euro: ''
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this); // Bind handleSubmit for the button click [cite: 25]
    }

    handleChange(event) {
        this.setState({ rupees: event.target.value });
    }

    // Handle the Click event of the button to invoke the handleSubmit event and handle the conversion of the euro to rupees. [cite: 25]
    handleSubmit() {
        const indianRupees = parseFloat(this.state.rupees);
        // Assuming a fixed conversion rate for demonstration
        const conversionRate = 0.011; // Example: 1 INR = 0.011 Euro (This rate is illustrative)

        if (!isNaN(indianRupees)) {
            const convertedEuro = indianRupees * conversionRate;
            this.setState({ euro: convertedEuro.toFixed(2) }); // Displaying with 2 decimal places
        } else {
            this.setState({ euro: 'Invalid Input' });
        }
    }

    render() {
        return (
            <div style={{ border: '1px solid #ccc', padding: '20px', margin: '20px auto', maxWidth: '400px' }}>
                <h2>Currency Converter</h2>
                <div>
                    <label htmlFor="rupees">Indian Rupees (INR): </label>
                    <input
                        type="number"
                        id="rupees"
                        value={this.state.rupees}
                        onChange={this.handleChange}
                        placeholder="Enter amount in INR"
                        style={{ padding: '8px', margin: '5px' }}
                    />
                </div>
                <div>
                    <button onClick={this.handleSubmit} style={{ margin: '10px', padding: '10px 20px' }}>
                        Convert to Euro
                    </button>
                </div>
                <div>
                    <label>Euro (EUR): </label>
                    <input
                        type="text"
                        value={this.state.euro}
                        readOnly
                        style={{ padding: '8px', margin: '5px', backgroundColor: '#f0f0f0' }}
                    />
                </div>
            </div>
        );
    }
}

export default App;