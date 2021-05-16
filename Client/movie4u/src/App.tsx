import { Row, Checkbox } from "antd";
import React, { useEffect, useState } from "react";
import Display from "./displays";

interface Movie {
  id: number;
  title: string;
  overview: string;
  poster_path: string;
  genra_ids: number[];
}

function App() {
  const [posts, setPosts] = useState<Movie[]>([]);
  useEffect(() => {
    fetch("https://api.themoviedb.org/3/discover/movie?api_key=03fdd8f321f29b9e3f052238c9a26c14&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_watch_monetization_types=flatrate")
      .then((response) => response.json())
      .then((posts) => setPosts(posts.results.slice(0, 10)));
  }, []);

  return (
    <div>
      <Checkbox.Group onChange={(checkedValues) => console.log(checkedValues)
      }>
        <Row gutter={[8, 8]}>
          {posts.map((post) => (
            <Display title={post.title} overview={post.overview} poster_path={"http://image.tmdb.org/t/p/w185/" + post.poster_path} id={post.id} key={post.id} />
          ))}
        </Row>
      </Checkbox.Group>
    </div >
  );
}




export default App;
