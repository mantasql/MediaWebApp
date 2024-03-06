import React from "react";
import { NavLink, Button } from "reactstrap";
import { useAuth0 } from "@auth0/auth0-react";
import { Link } from 'react-router-dom';

const SignupButton = () => {
    const { loginWithRedirect } = useAuth0();

    return <NavLink tag={Link} onClick={() => loginWithRedirect({
        authorizationParams: {
            screen_hint: "signup"
        }
    })}>Sign Up</NavLink>;
};

export default SignupButton;