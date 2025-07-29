// src/Components/ListofPlayers.js
import React from 'react';

/**
 * ListofPlayers functional component.
 * This component demonstrates ES6 map() for rendering lists
 * and arrow functions for filtering data.
 *
 * @param {object} props - The properties passed to the component.
 * @param {Array<object>} props.players - An array of player objects, each with 'name' and 'score'.
 * @returns {JSX.Element} The rendered React elements displaying player lists.
 */
function ListofPlayers(props) {
    const { players } = props;
    const playersBelow70 = players.filter(player => player.score < 70);

    return (
        <div style={{ padding: '20px', fontFamily: 'Arial, sans-serif' }}>
            <h1 style={{ color: '#333', borderBottom: '2px solid #eee', paddingBottom: '10px' }}>List of Players</h1>
            <ul style={{ listStyleType: 'disc', paddingLeft: '0px' }}> {/* Changed paddingLeft to 0px */}
                {players.map((item, index) => (
                    <li key={index} style={{ marginBottom: '5px', fontSize: '1.1em' }}>
                        Mr. {item.name} <span style={{ fontWeight: 'bold', color: '#007bff' }}>{item.score}</span>
                    </li>
                ))}
            </ul>

            <h1 style={{ color: '#333', borderBottom: '2px solid #eee', paddingBottom: '10px', marginTop: '30px' }}>
                List of Players having Scores Less than 70
            </h1>
            <ul style={{ listStyleType: 'disc', paddingLeft: '0px' }}> {/* Changed paddingLeft to 0px */}
                {playersBelow70.map((item, index) => (
                    <li key={index} style={{ marginBottom: '5px', fontSize: '1.1em' }}>
                        Mr. {item.name} <span style={{ fontWeight: 'bold', color: '#dc3545' }}>{item.score}</span>
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default ListofPlayers;
