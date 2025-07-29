// src/BlogDetails.js
import React from 'react';

function BlogDetails(props) {
    const blogdet = props.blogs.map(blog => (
        <div key={blog.id}>
            <h3>{blog.title}</h3>
            <p>{blog.author}</p>
            <p>{blog.content}</p>
        </div>
    ));

    // Conditional rendering: Display content if blogs exist, otherwise a message
    const content = props.blogs && props.blogs.length > 0 ? blogdet : <p>No blog details available.</p>;

    return (
        <div className="blog-details">
            <h1>Blog Details</h1>
            {content}
        </div>
    );
}

export default BlogDetails;