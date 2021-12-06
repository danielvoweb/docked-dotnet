import React, {useState, useEffect} from "react";
import axios from "axios";

const App = () => {

    const [post, setPost] = useState({});
    const [posts, setPosts] = useState([]);

    useEffect(() => {
        axios.get("/api/posts")
            .then(response => {
                setPosts(response.data);
            });
    }, []);

    const renderedPosts = posts.map(post => <li key={post.id}>{post.content}<button>Remove</button></li>);

    const onSubmit = (event) => {
        event.preventDefault();

        axios.post("/api/posts", Object.fromEntries(new FormData(event.target)))
            .then(response => {
                setPosts([...posts, response.data]);
            });
    };

    return (
        <div>
            <ul>
                {renderedPosts.length > 0 ? renderedPosts : "nothing to show."}
            </ul>
            <form onSubmit={onSubmit}>
                <textarea name="content" value={post.content}/>
                <input name="author" value={post.author}/>
                <button>Add Post</button>
            </form>
        </div>
    )
};

export default App;
