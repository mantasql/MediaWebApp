import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { NavLink, NavItem } from "reactstrap";
import { Link } from 'react-router-dom';

const Profile = () => {
    const { user, isAuthenticated, isLoading } = useAuth0();

    if (isLoading) {
        return <div>Loading ...</div>;
    }

    return (
        isAuthenticated && (
            <NavLink tag={Link} to="profile">
                <div className="text-center">
                    <img src={user.picture} alt={user.name} style={{ width: "12%" }} />
                    {user.name.split('@')[0]}
                </div>
            </NavLink>
        )
    );
};

export default Profile;