import { Row, Checkbox } from "antd";
import React, { useEffect, useState } from "react";
import Display from "./Display";
import { MovieChoice } from "./models";


export interface Movie {
  id: number;
  title: string;
  overview: string;
  poster_path: string;
  genra_ids: number[];
}

type AppProps = {
  onChange(MovieChoices: MovieChoice[]): void;
}

function App(props: AppProps) {
  const [posts, setPosts] = useState<Movie[]>([]);

  const onChecked = (movieIds: number[]) => {
    const choices = posts.filter(x => movieIds.includes(x.id))
    props.onChange(choices);
  }


  useEffect(() => {
    fetch("https://api.themoviedb.org/3/discover/movie?api_key=03fdd8f321f29b9e3f052238c9a26c14&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_watch_monetization_types=flatrate")
      .then((response) => response.json())
      .then((posts) => setPosts(posts.results.slice(0, 12)));
  }, []);

  return (
    <div style={{ maxWidth: '1350px', display: 'flex', margin: 'auto' }}>
      <Checkbox.Group onChange={(checkedValues) => onChecked(checkedValues as number[])
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
