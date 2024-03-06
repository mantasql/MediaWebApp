import React, { Component } from 'react';
import axios from 'axios';
import RenderMediaTable from './RenderMediaTable';

export class Anime extends Component {
    constructor(props) {
        super(props);

        this.state = {
            media: [],
            loading: true
        }
    }

    componentDidMount() {
        this.populateMediaData();
    }

    populateMediaData() {
        axios.get("api/Media/GetAll?type=Anime").then(result => {
            const response = result.data;
            this.setState({ media: response, loading: false });
        });
    }

    render() {

        let content = this.state.loading ? (
            <p>
                <em>Loading...</em>
            </p>
        ) : (
            <RenderMediaTable media={this.state.media} />
        );

        return (
            <div>
                <h1>All Anime</h1>
                <p>Here you can see all anime</p>
                {content}
            </div>
        );
    }
}