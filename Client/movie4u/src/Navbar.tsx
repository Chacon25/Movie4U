import React from "react";
import { Layout, Menu, Breadcrumb, Button } from 'antd';
import { MailOutlined } from '@ant-design/icons';
import ReactDOM from "react-dom";
import { Header } from "antd/lib/layout/layout";
import logo from './images/logo.png'





export default function Navbar() {

    return (

        <Header style={{ display: "flex" }}>
            <img src={logo} width={100} alt="logo" style={{ margin: '10px' }} />
            <Menu theme="dark" mode="horizontal" defaultSelectedKeys={['1']}>
                <Menu.Item key="1">Movies</Menu.Item>


                <Button type="ghost" shape="round" icon={<MailOutlined />} size='large' style={{ marginLeft: '20px', backgroundColor: 'green', borderColor: 'green', color: 'white' }} >
                    Send


                </Button>



            </Menu>
        </Header >



    );

}