import React, { Component, useState } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import Searchbar from './Searchbar';
import './NavMenu.css';
import LoginButton from './Media/Authentication/LoginButton';
import LogoutButton from './Media/Authentication/LogoutButton';
import Profile from './Media/Authentication/Profile';
import { useAuth0 } from "@auth0/auth0-react";
import SignupButton from './Media/Authentication/SignupButton';

const NavMenu = () => {
    const { isAuthenticated } = useAuth0();
    const [collapsed, setCollapsed] = useState(true);
    const [searchbarCollapsed, setSearchbarCollapsed] = useState(true);

    const toggleNavbar = () => {
        setCollapsed(!collapsed);
    }

    const toggleSearchbar = () => {
        setSearchbarCollapsed(!searchbarCollapsed);
    }

    return (
        <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white box-shadow" container light>
                <NavbarBrand className="text-white" tag={Link} to="/">MMDB</NavbarBrand>
                <NavbarToggler onClick={toggleSearchbar} className="mr-2" />
                <NavbarToggler onClick={toggleNavbar} className="mr-2" />
                <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!searchbarCollapsed} navbar>
                    <div className="navmenu-searchbar">
                        <Searchbar />
                    </div>
                </Collapse>
                <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
                    <ul className="navbar-nav flex-grow">
                        {isAuthenticated ? (
                            <ul className="navbar-nav flex-grow">
                                <NavItem className="my-auto">
                                    <Profile />
                                </NavItem>
                                <NavItem>
                                    <LogoutButton />
                                </NavItem>
                            </ul>
                        ) : (
                            <ul className = "navbar-nav flex-grow">
                                <NavItem>
                                    <LoginButton />
                                    {/*<NavLink tag={Link} className="text-white" to="/signup">Sign up</NavLink>*/}
                                </NavItem>
                                <NavItem>
                                    <SignupButton />
                                </NavItem>
                            </ul>
                    )}
                    </ul>
                </Collapse>
            </Navbar>
        </header>
    );
}

export default NavMenu;