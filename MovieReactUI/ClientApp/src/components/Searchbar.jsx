import React, { useState, useEffect } from 'react';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem, Input } from 'reactstrap';
import { Nav, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import axios from 'axios';
import './Menu.css';

const Searchbar = () => {
    const [dropdownOpen, setDropdownOpen] = useState(false);
    const [query, setQuery] = useState('');
    const [categoryQuery, setCategoryQuery] = useState('');
    const [fetchedItems, setFetchedItems] = useState([]);

    const toggle = () => setDropdownOpen((prevState) => fetchedItems.length != 0 ? !prevState : prevState);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get('api/Media/GetByTitle?title=' + query + '&' + 'category=' + categoryQuery);
                console.log(`Tried to query: 'api/Media/GetByTitle?title=${query}&category=${categoryQuery}`);
                setFetchedItems(response.data);
            } catch (error) {
                console.error('Error fetching data', error);
            }
        };

        if (query.trim() !== '') {
            fetchData();
        } else {
            setFetchedItems([]);
        }
    }, [query, categoryQuery]);

/*    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = categoryQuery === "" ? await axios.get(`https://search.imdbot.workers.dev/?q=${query}`) : await axios.get(`https://api.simkl.com/search/${categoryQuery}?q=${query}&client_id=d99bf2964e9049ceb60cfa6ed3bff23d479332b5db7c348f367f4c9315baf979`);
                
                setFetchedItems(response.data);
            } catch (error) {
                console.error('Error fetching data', error);
            }
        };

        if (query.trim() !== '') {
            fetchData();
        } else {
            setFetchedItems([]);
        }
    }, [query, categoryQuery]);*/

    return (
        <Nav className="navbar-nav flex-grow menu-nav">
            <NavItem>
                <Input className="category-input" id="category-select" name="select" type="select" onChange={(e) => setCategoryQuery(e.target.value)}>
                    <option value="">All</option>
                    <option value="movie">Movies</option>
                    <option value="tv">TvSeries</option>
                    <option value="anime">Anime</option>
                </Input>
            </NavItem>
            <NavItem>
                <Dropdown isOpen={dropdownOpen} toggle={toggle}>
                    <DropdownToggle className="searchbar">
                        <Input className="search-input" onChange={(e) => setQuery(e.target.value)} placeholder="search media" value={query} />
                    </DropdownToggle>
                    <DropdownMenu className="search-dropdown">
                        {fetchedItems?.map((item) => (
                            <NavLink key={item.id} tag={Link} to={`media/${item.id}`} >
                                <DropdownItem key={item.id}>{item.title}</DropdownItem>
                            </NavLink>
                        ))}
                    </DropdownMenu>
                </Dropdown>
            </NavItem>
        </Nav>
    )
};

export default Searchbar;