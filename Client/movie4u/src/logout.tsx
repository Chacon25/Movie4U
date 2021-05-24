import React from 'react'

import { Auth0Provider, useAuth0 } from '@auth0/auth0-react'
export const logoutButton = () => {

    const { logout } = useAuth0();
    return (
        <button onClick={() => logout({ returnTo: window.location.origin })} > Logout </ button>
    )
}


