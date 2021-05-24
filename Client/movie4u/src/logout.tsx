import React from 'react'

import { Auth0Provider, useAuth0 } from '@auth0/auth0-react'
import { Button } from 'antd';
export const LogoutButton = () => {

    const { logout } = useAuth0();
    return (
        <Button size='large' style={{ display: 'flex', margin: '10px 10px 10px auto', backgroundColor: 'green', borderColor: 'green', color: 'white', }} onClick={() => logout({ returnTo: window.location.origin })} > Logout </ Button>
    )
}


