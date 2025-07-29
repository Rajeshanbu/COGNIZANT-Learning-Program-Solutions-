// src/BookDetails.js
import React from 'react';

function BookDetails(props) {
    // This is the 'bookdet' variable from the hint image
    const bookdet = (
        <ul>
            {props.books.map(book => (
                <div key={book.id}> {/* Use key for list items  */}
                    <h3>{book.bname}</h3>
                    <h4>{book.price}</h4>
                </div>
            ))}
        </ul>
    );

    return (
        <div className="book-details">
            <h1>Book Details</h1>
            {bookdet}
        </div>
    );
}

export default BookDetails;