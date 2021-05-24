import React from "react";

import { Menu, Button } from 'antd';
import { MailOutlined } from '@ant-design/icons';
import { Header } from "antd/lib/layout/layout";
import logo from './images/logo.png'
import { MovieChoice } from "./models";

import Profile from "./Profile";
import { LoginButton } from "./Login"
import { LogoutButton } from "./Logout"
import { useAuth0 } from "@auth0/auth0-react";

type NavbarProps = {
    choices: MovieChoice[];
}



export default function Navbar({ choices }: NavbarProps) {

    const { user, isAuthenticated } = useAuth0();
    return (

        <>
            <Header style={{ display: "flex" }}>
                <img src={logo} width={100} alt="logo" style={{ margin: '10px' }} />

                {isAuthenticated ? (
                    <>

                        <Button type="ghost" shape="round" icon={<MailOutlined />} size='large' style={{ margin: '10px', backgroundColor: 'green', borderColor: 'green', color: 'white' }} onClick={() => {
                            // console.log('call backend');
                            //   console.log(user);

                            fetch("https://localhost:44390/api/Recommendation", {
                                method: 'POST',
                                body: JSON.stringify({ choices, user }),
                                headers: {
                                    'Content-Type': 'application/json'
                                }
                            }).then(res => res.json())
                                .catch(error => console.error('Error:', error))
                                .then(response => console.log('Success:', response));


                        }}

                        >
                            Send
                        </Button>

                        <Profile />
                        <LogoutButton />

                    </>

                ) : (
                    < LoginButton />

                )}

            </Header >

        </>



    );

}