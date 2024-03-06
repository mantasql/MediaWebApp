import React from 'react';
import { Navbar, NavItem, Nav, NavbarToggler, Collapse } from 'reactstrap';
import { NavLink } from 'react-router-dom';
import './Menu.css';
import Searchbar from './Searchbar';

const Menu = () => {
    return (
        <div className="menu">
            <div className="menu-left">
                <Navbar className="navbar-expand-sm background-blue">
                    <Nav className="navbar-nav flex-grow">
                        <NavItem>
                            <NavLink className="nav-link nav-links" to="/media">All</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink className="nav-link nav-links" to="/movies">Movies</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink className="nav-link nav-links" to="/tv-series">Tv series</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink className="nav-link nav-links" to="/anime">Anime</NavLink>
                        </NavItem>
                    </Nav>
                </Navbar>
            </div>
            <div className="menu-right">
                <div className="menu-searchbar">
                    <Navbar className="navbar-expand-sm navbar-toggleable-sm background-blue menu-nav">
                        <Searchbar />
                    </Navbar>
                </div>
            </div>
        </div>
    );
};

export default Menu;