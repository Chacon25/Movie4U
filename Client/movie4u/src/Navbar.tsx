import React from "react";
import { Menu, Button } from 'antd';
import { MailOutlined } from '@ant-design/icons';
import { Header } from "antd/lib/layout/layout";
import logo from './images/logo.png'
import { MovieChoice } from "./models";



type NavbarProps = {
    choices: MovieChoice[];
}

export default function Navbar({ choices }: NavbarProps) {

    return (

        <Header style={{ display: "flex" }}>
            <img src={logo} width={100} alt="logo" style={{ margin: '10px' }} />
            <Button type="ghost" shape="round" icon={<MailOutlined />} size='large' style={{ margin: '10px', backgroundColor: 'green', borderColor: 'green', color: 'white' }} onClick={() => {
                // console.log('call backend');
                // console.log(choices);

                fetch("https://localhost:44390/api/Recommendation", {
                    method: 'POST',
                    body: JSON.stringify(choices),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }).then(res => res.json())
                    .catch(error => console.error('Error:', error))
                    .then(response => console.log('Success:', response));


            }} >
                Send
            </Button>
        </Header >



    );

}