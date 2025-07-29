// src/Components/CohortDetails.js
import React from 'react';
import styles from './CohortDetails.module.css';
// We will import the CSS Module here in a later step
// import styles from './CohortDetails.module.css';

/**
 * CohortDetails functional component displays details of a single cohort.
 * It accepts cohort data as props.
 *
 * @param {object} props - The properties passed to the component.
 * @param {string} props.id - The unique ID of the cohort.
 * @param {string} props.name - The name/title of the cohort.
 * @param {string} props.startedOn - The start date of the cohort.
 * @param {string} props.status - The current status of the cohort (e.g., "Ongoing", "Scheduled", "Completed").
 * @param {string} props.coach - The name of the coach.
 * @param {string} props.trainer - The name of the trainer.
 * @returns {JSX.Element} The rendered React element for cohort details.
 */
function CohortDetails(props) {
    const { id, name, startedOn, status, coach, trainer } = props;

    // Define inline style for the <h3> element based on cohort status
    const h3Style = {
        color: status === 'Ongoing' ? 'green' : 'blue', // Green for 'Ongoing', Blue for others
        marginBottom: '10px',
        textAlign: 'center'
    };

    return (
        // We will apply the CSS Module class 'box' here in a later step
        <div /* className={styles.box} */>
            <h3 style={h3Style}>{id} - {name}</h3>
            <dl> {/* Definition List for details */}
                <dt>Started On</dt>
                <dd>{startedOn}</dd>

                <dt>Current Status</dt>
                <dd>{status}</dd>

                <dt>Coach</dt>
                <dd>{coach}</dd>

                <dt>Trainer</dt>
                <dd>{trainer}</dd>
            </dl>
        </div>
    );
}

export default CohortDetails;