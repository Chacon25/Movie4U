import React, { useState } from 'react'
import App from './App'
import { MovieChoice } from './models';
import Navbar from './Navbar';
import { Typography } from "antd";

const { Paragraph } = Typography;

export default function Container() {

    const [movieChoices, setMovieChoices] = useState<MovieChoice[]>([]);

    function onChange(choices: MovieChoice[]) {
        setMovieChoices(choices);
    }

    return (
        <div>
            <Navbar choices={movieChoices} />
            <Paragraph style={{ margin: '50px', textAlign: 'center', fontSize: '20px' }}>Please check the movies that you like and click on the send button to get recommendations.</Paragraph>
            <App onChange={onChange} />


        </div>
    )
}

