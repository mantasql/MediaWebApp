import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';
import CusCarousel from './Carousel';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);

        this.toggleAllDropdown = this.toggleAllDropdown.bind(this);
        this.toggleMoviesDropdown = this.toggleMoviesDropdown.bind(this);
        this.toggleTvSeriesDropdown = this.toggleTvSeriesDropdown.bind(this);
        this.toggleAnimeDropdown = this.toggleAnimeDropdown.bind(this);
        this.state = {
            dropdownAllOpen: false,
            dropdownMoviesOpen: false,
            dropdownTvSeriesOpen: false,
            dropdownAnimeOpen: false
        }
    }

    toggleAllDropdown() {
        this.setState(prewState => ({
            dropdownAllOpen: !prewState.dropdownAllOpen
        }));
    }

    toggleMoviesDropdown() {
        this.setState(prewState => ({
            dropdownMoviesOpen: !prewState.dropdownMoviesOpen
        }));
    }

    toggleTvSeriesDropdown() {
        this.setState(prewState => ({
            dropdownTvSeriesOpen: !prewState.dropdownTvSeriesOpen
        }));
    }

    toggleAnimeDropdown() {
        this.setState(prewState => ({
            dropdownAnimeOpen: !prewState.dropdownAnimeOpen
        }));
    }

    render() {
        return (
            <div>
                <Row className="m-0 my-2 page-info-header">
                Premieres
                </Row>
                <Row>
                    <CusCarousel />
                </Row>
            </div>

        );
    }
}

/*                                 <Dropdown isOpen={this.state.dropdownAllOpen} toggle={this.toggleAllDropdown}>
                                    <DropdownToggle caret>All</DropdownToggle>
                                    <DropdownMenu>
                                        <DropdownItem tag={Link} to="/top-airing">Top Airing</DropdownItem>
                                        <DropdownItem tag={Link} to="/upcoming">Upcoming</DropdownItem>
                                        <DropdownItem tag={Link} to="/most-popular">Most Popular</DropdownItem>
                                    </DropdownMenu>
                                </Dropdown> */
