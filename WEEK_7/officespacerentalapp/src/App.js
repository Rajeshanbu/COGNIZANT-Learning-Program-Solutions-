import React from 'react';
import './App.css'; // You can keep or remove this if not using external CSS

function App() {
    // Create an element to display the heading of the page. 
    const pageHeading = <h1>Welcome to Office Space Rentals</h1>;

    // Attribute to display the image of the office space. 
    const officeImage = (
        <img
            src="https://via.placeholder.com/400x200?text=Office+Space" // Placeholder image URL
            alt="Office Space"
            style={{ maxWidth: '100%', height: 'auto', marginBottom: '20px' }}
        />
    );

    // Create an object of office to display the details like Name, Rent and Address. 
    const singleOffice = {
        name: 'Modern Office Hub',
        rent: 55000,
        address: '123 Business Park, City Center'
    };

    // Create a list of Object and loop through the office space item to display more data. 
    const officeSpaces = [
        { name: 'Tech Innovations', rent: 75000, address: '456 Silicon Valley, Metro' },
        { name: 'Creative Corner', rent: 48000, address: '789 Art Street, Downtown' },
        { name: 'Executive Suites', rent: 90000, address: '101 Corporate Towers, Financial District' },
        { name: 'Startup Loft', rent: 59000, address: '222 Incubator Lane, Tech Park' },
        { name: 'Small Business Unit', rent: 35000, address: '333 Main Road, Suburban Area' }
    ];

    return (
        <div className="App" style={{ textAlign: 'center', fontFamily: 'Arial, sans-serif' }}>
            {pageHeading}

            {officeImage}

            <h2>Details of a Single Office Space:</h2>
            <div style={{ border: '1px solid #ccc', padding: '15px', margin: '20px auto', maxWidth: '500px' }}>
                <h3>{singleOffice.name}</h3>
                <p>
                    Rent: ₹<span style={{ color: singleOffice.rent < 60000 ? 'red' : 'green' }}>
                        {singleOffice.rent}
                    </span> 
                </p>
                <p>Address: {singleOffice.address}</p>
            </div>

            <h2>Available Office Spaces:</h2>
            <div style={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center' }}>
                {officeSpaces.map((office, index) => (
                    <div
                        key={index}
                        style={{
                            border: '1px solid #ddd',
                            padding: '15px',
                            margin: '10px',
                            width: '280px',
                            boxShadow: '2px 2px 5px rgba(0,0,0,0.1)'
                        }}
                    >
                        <h3>{office.name}</h3>
                        <p>
                            Rent: ₹<span style={{ color: office.rent < 60000 ? 'red' : 'green' }}>
                                {office.rent}
                            </span> 
                        </p>
                        <p>Address: {office.address}</p>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default App;