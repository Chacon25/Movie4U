import React from "react";
import { Layout, Menu, Breadcrumb } from 'antd';
import ReactDOM from "react-dom";
import { Header } from "antd/lib/layout/layout";
import logo from './images/logo.png'


export default function header() {

    return (

        <Header style={{ display: "flex" }}>

            {/* <div style={{
                float: 'left', width: '120px', height: '31px',
                margin: "16px 24px 16px 0", background: "rgba(255, 255, 255, 0.3)",
            }} /> */}
            <img src={logo} width={50} alt="logo" style={{ margin: '10px' }} />
            <Menu theme="dark" mode="horizontal" defaultSelectedKeys={['2']}>
                <Menu.Item key="1">Movies</Menu.Item>

            </Menu>
        </Header>



    );

}