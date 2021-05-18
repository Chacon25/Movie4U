import React, { useState } from 'react'
import App from './App'
import Navbar from './Navbar'

interface MovieChoice {
    id: number;
    title: string;
    genra_ids: number[];
}



export default function Container() {

    const [movieChoices, setMovieChoices] = useState<MovieChoice[]>([]);

    function onChange(choices: MovieChoice[]) {

    }

    return (
        <div>
            <Navbar choices={movieChoices} />
            <App onChange={onChange} />
        </div>
    )
}

