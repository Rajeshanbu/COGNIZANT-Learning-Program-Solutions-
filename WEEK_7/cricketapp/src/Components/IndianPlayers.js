// src/Components/IndianPlayers.js
import React from 'react';

export function OddPlayers([first, , third, , fifth]) {
    return (
        <div style={{ marginBottom: '20px' }}>
            <ul style={{ listStyleType: 'none', paddingLeft: '0' }}> {/* Already 0px */}
                <li style={{ marginBottom: '5px', fontSize: '1.1em' }}>First : {first}</li>
                <li style={{ marginBottom: '5px', fontSize: '1.1em' }}>Third : {third}</li>
                <li style={{ marginBottom: '5px', fontSize: '1.1em' }}>Fifth : {fifth}</li>
            </ul>
        </div>
    );
}

export function EvenPlayers([, second, , fourth, , sixth]) {
    return (
        <div style={{ marginBottom: '20px' }}>
            <ul style={{ listStyleType: 'none', paddingLeft: '0' }}> {/* Already 0px */}
                <li style={{ marginBottom: '5px', fontSize: '1.1em' }}>Second : {second}</li>
                <li style={{ marginBottom: '5px', fontSize: '1.1em' }}>Fourth : {fourth}</li>
                <li style={{ marginBottom: '5px', fontSize: '1.1em' }}>Sixth : {sixth}</li>
            </ul>
        </div>
    );
}

const T20Players = ['First Player', 'Second Player', 'Third Player'];
const RanjiTrophyPlayers = ['Fourth Player', 'Fifth Player', 'Sixth Player'];
export const IndianPlayersMerged = [...T20Players, ...RanjiTrophyPlayers];

function IndianPlayers(props) {
    const { indianTeam } = props;

    return (
        <div style={{ padding: '20px', fontFamily: 'Arial, sans-serif' }}>
            <h1 style={{ color: '#333', borderBottom: '2px solid #eee', paddingBottom: '10px' }}>Indian Team</h1>

            <h2 style={{ color: '#555', marginTop: '20px' }}>Odd Players</h2>
            {OddPlayers(indianTeam)}

            <h2 style={{ color: '#555', marginTop: '20px' }}>Even Players</h2>
            {EvenPlayers(indianTeam)}

            <h1 style={{ color: '#333', borderBottom: '2px solid #eee', paddingBottom: '10px', marginTop: '30px' }}>
                List of Indian Players Merged:
            </h1>
            <ul style={{ listStyleType: 'disc', paddingLeft: '0px' }}> {/* Changed paddingLeft to 0px */}
                {IndianPlayersMerged.map((player, index) => (
                    <li key={index} style={{ marginBottom: '5px', fontSize: '1.1em' }}>
                        Mr. {player}
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default IndianPlayers;
