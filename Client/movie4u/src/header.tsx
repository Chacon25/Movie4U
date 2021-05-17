import React from "react";
import { Layout, Menu, Breadcrumb } from 'antd';
import ReactDOM from "react-dom";
import { Header } from "antd/lib/layout/layout";
import logo from './images/logo.png'


export default function header() {

    return (

        <Header style={{ display: "flex" }}>
            <img src={logo} width={100} alt="logo" style={{ margin: '10px' }} />
            <Menu theme="dark" mode="horizontal" defaultSelectedKeys={['2']}>
                <Menu.Item key="1">Movies</Menu.Item>

            </Menu>
        </Header>



    );

}