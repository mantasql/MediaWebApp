import React from "react";
import { NavLink } from "reactstrap";
import { useAuth0 } from "@auth0/auth0-react";
import { Link } from 'react-router-dom';

const LoginButton = () => {
    const { loginWithRedirect } = useAuth0();

    return <NavLink tag={Link} onClick={() => loginWithRedirect()}>Log In</NavLink>;
};

export default LoginButton;