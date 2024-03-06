import React, { Component } from 'react';
import axios from 'axios';
import RenderMediaTable from './RenderMediaTable';

export class Media extends Component {
    constructor(props) {
        super(props);

        this.state = {
            media: [],
            loading: true,
            failed: false,
            error: ''
        }
    }

    componentDidMount() {
        this.populateMediaData();
    }

    populateMediaData() {
        axios.get("api/Media/GetAll").then(result => {
            const response = result.data;
            this.setState({ media: response, loading: false, failed: false, error: '' });
        }).catch(error => {
            this.setState({ media: [], loading: false, failed: true, error: error });
        });
    }

    render() {

        let content = this.state.loading ? (
            <p>
                <em>Loading...</em>
            </p>
        ) : ( this.state.failed ? (
            <div className="text-dange">
                <em>{this.state.error}</em>
            </div>
        ) : (
            <RenderMediaTable media={this.state.media} />
        ));

        return (
            <div>
                <h1>All media</h1>
                <p>Here you can see all media</p>
                {content}
            </div>
        );
    }
}