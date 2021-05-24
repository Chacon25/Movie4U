import React from 'react'

import { Auth0Provider, useAuth0 } from '@auth0/auth0-react'
import { Button } from 'antd';
export const logoutButton = () => {

    const { logout } = useAuth0();
    return (
        <Button onClick={() => logout({ returnTo: window.location.origin })} > Logout </ Button>
    )
}


