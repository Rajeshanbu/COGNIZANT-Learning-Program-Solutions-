// Post.js
// Defines a simple JavaScript class to represent a blog post.
class Post {
    /**
     * Constructor for the Post class.
     * @param {number} id - The unique ID of the post.
     * @param {string} title - The title of the post.
     * @param {string} body - The content/body of the post.
     */
    constructor(id, title, body) {
        this.id = id;
        this.title = title;
        this.body = body;
    }
}

export default Post; // Export the Post class for use in other files