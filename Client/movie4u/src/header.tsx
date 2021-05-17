import React from "react";
import { Layout, Menu, Breadcrumb } from 'antd';
import ReactDOM from "react-dom";
import { Header } from "antd/lib/layout/layout";


export default function header() {

    return (

        <Header>

            <div style={{
                float: 'left', width: '120px', height: '31px',
                margin: "16px 24px 16px 0", backgroundImage: "http://img.huffingtonpost.com/asset/scalefit_600_noupscale/56328113190000a600b9540d.jpeg",
            }} />





            <Menu theme="dark" mode="horizontal" defaultSelectedKeys={['1']}>
                <Menu.Item key="1">Movies</Menu.Item>



            </Menu>
        </Header>



    );

}