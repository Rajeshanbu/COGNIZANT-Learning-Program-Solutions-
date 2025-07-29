// Posts.js
import React from 'react';
import Post from './Post'; // Import the Post class we just created

// Define the Posts class component, extending React.Component
class Posts extends React.Component {
    /**
     * Constructor for the Posts component.
     * Initializes the component's state.
     * @param {object} props - The properties passed to the component.
     */
    constructor(props) {
        super(props); // Call the parent React.Component constructor

        // Initialize the component's state
        // 'posts' will store the fetched blog posts
        // 'error' will store any error encountered during fetching
        this.state = {
            posts: [],
            error: null,
        };
    }

    /**
     * Asynchronous method to load posts from an API using Fetch API.
     * Updates the component's state with the fetched posts or an error.
     */
    async loadPosts() {
        try {
            // Fetch data from the JSONPlaceholder API
            const response = await fetch('https://jsonplaceholder.typicode.com/posts');

            // Check if the response is OK (status code 200-299)
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }

            // Parse the JSON response
            const data = await response.json();

            // Map the raw data to instances of our Post class
            const fetchedPosts = data.map(item => new Post(item.id, item.title, item.body));

            // Update the component's state with the fetched posts
            this.setState({ posts: fetchedPosts, error: null });
        } catch (error) {
            // If an error occurs during fetching, update the state with the error
            console.error("Failed to fetch posts:", error);
            this.setState({ error: error.message });
        }
    }

    /**
     * componentDidMount is a lifecycle hook that runs immediately after the component
     * is mounted (inserted into the DOM tree). This is a good place to make network requests.
     */
    componentDidMount() {
        console.log("Posts component mounted. Fetching data...");
        this.loadPosts(); // Call the loadPosts method to fetch data
    }

    /**
     * componentDidCatch is a lifecycle hook for error handling.
     * It catches errors that occur during rendering, in lifecycle methods,
     * and in constructors of any child components.
     * @param {Error} error - The error that was thrown.
     * @param {object} info - An object with a componentStack key containing
     * information about which component threw the error.
     */
    componentDidCatch(error, info) {
        console.error("Error caught by componentDidCatch:", error, info);
        // In a real application, you might log this error to an error reporting service.
        // For this lab, we'll display a simple message.
        // IMPORTANT: Do NOT use alert() in production React apps.
        // For this exercise, we'll simulate an alert by updating state and rendering a message.
        this.setState({ error: `An error occurred: ${error.message}. Please try again later.` });
    }


    /**
     * The render method is required for class components and returns the JSX to be rendered.
     */
    render() {
        const { posts, error } = this.state;

        // If an error exists, display an error message
        if (error) {
            return (
                <div className="error-message" style={{ color: 'red', textAlign: 'center', padding: '20px' }}>
                    <h2>Error Loading Posts</h2>
                    <p>{error}</p>
                    <p>Please check your network connection or try again later.</p>
                </div>
            );
        }

        // If no posts are loaded yet, display a loading message
        if (posts.length === 0) {
            return (
                <div style={{ textAlign: 'center', padding: '20px' }}>
                    <h2>Loading Posts...</h2>
                    <p>Please wait while we fetch the latest blog posts.</p>
                </div>
            );
        }

        // If posts are loaded, display them
        return (
            <div className="posts-container" style={{ maxWidth: '800px', margin: '20px auto', padding: '0 15px' }}>
                <h1 style={{ textAlign: 'center', color: '#333' }}>Blog Posts</h1>
                {posts.map(post => (
                    <div key={post.id} className="post-item" style={{
                        border: '1px solid #ddd',
                        borderRadius: '8px',
                        padding: '15px',
                        marginBottom: '15px',
                        backgroundColor: '#fff',
                        boxShadow: '0 2px 4px rgba(0,0,0,0.05)'
                    }}>
                        <h2 style={{ color: '#007bff', marginBottom: '10px' }}>{post.title}</h2>
                        <p style={{ lineHeight: '1.6', color: '#555' }}>{post.body}</p>
                    </div>
                ))}
            </div>
        );
    }
}

export default Posts; // Export the Posts component