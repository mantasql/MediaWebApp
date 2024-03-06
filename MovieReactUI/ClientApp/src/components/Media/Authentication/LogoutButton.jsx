import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { Link } from 'react-router-dom';
import { NavLink } from "reactstrap";

const LogoutButton = () => {
    const { logout } = useAuth0();

    return (
        <NavLink tag={Link} onClick={() => logout({ logoutParams: { returnTo: window.location.origin } })}>
            Log Out
        </NavLink>
    );
};

export default LogoutButton;