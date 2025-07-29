// src/App.js
import React from 'react';
import './App.css'; // This will contain our custom styles
import BookDetails from './BookDetails'; // [cite: 61]
import BlogDetails from './BlogDetails'; // [cite: 62]
import CourseDetails from './CourseDetails'; // [cite: 63]

// Import data
import { books } from './data/booksData';
import { blogs } from './data/blogsData';
import { courses } from './data/coursesData';

function App() {
    return (
        <div className="App">
            <div style={{ display: 'flex', justifyContent: 'space-around', padding: '20px' }}>
                {/* Course Details Column */}
                <div className="myStyle1 column-container"> {/* Renamed from 'mystyle1' for clarity, but matches hint  */}
                    <CourseDetails courses={courses} />
                </div>

                {/* Book Details Column */}
                <div className="st2 column-container"> {/* Matches hint  */}
                    <BookDetails books={books} />
                </div>

                {/* Blog Details Column */}
                <div className="v1 column-container"> {/* Matches hint  */}
                    <BlogDetails blogs={blogs} />
                </div>
            </div>
        </div>
    );
}

export default App;