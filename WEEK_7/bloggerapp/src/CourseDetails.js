// src/CourseDetails.js
import React from 'react';

function CourseDetails(props) {
    // This is the 'coursedet' variable (similar concept to bookdet)
    const coursedet = props.courses.map(course => (
        <div key={course.id}>
            <h3>{course.name}</h3>
            <p>{course.date}</p>
        </div>
    ));

    return (
        <div className="course-details">
            <h1>Course Details</h1>
            {props.courses.length > 0 && coursedet} {/* Conditional rendering using logical && */}
            {props.courses.length === 0 && <p>No course details available.</p>}
        </div>
    );
}

export default CourseDetails;