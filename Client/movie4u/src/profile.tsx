import React from 'react';

import { useAuth0 } from '@auth0/auth0-react'
import { Divider } from 'antd';



export default function Profile() {

    const { user, isAuthenticated, isLoading } = useAuth0();
    return (
        <div>
            {
                isAuthenticated && (
                    <div>
                        <img width={40} style={{ margin: '10px 30px 20px', backgroundColor: 'green', borderColor: 'green', color: 'white' }} src={user?.picture} alt={user?.name} />
                        <h2 style={{ margin: '-70px 100px 20px', color: 'white' }}> {user?.name}</h2>
                        {/* <p>Email: {user?.email}</p> */}
                    </div>
                )
            }
        </div>
    )
}



