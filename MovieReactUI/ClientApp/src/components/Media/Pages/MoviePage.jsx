import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { Row, Col, NavLink, Form, Input, Button } from 'reactstrap';
import { Link } from 'react-router-dom';
import axios from 'axios';
import "../../Style.css";
import { parseStatusValue, parseTypeValue, parseGenreValue } from '../../EnumParser';

export const MoviePage = () => {
    const [media, setMedia] = useState({});
    const [similarShows, setSimilarShows] = useState([]);
    const [loading, setLoading] = useState(true);
    const [failed, setFailed] = useState(false);
    const [error, setError] = useState('');
    const { id } = useParams();

    useEffect(() => {
        populateMediaData(id);
        getSimilarShows(id);
    }, [id]);

    const populateMediaData = (id) => {
        axios.get(`api/Media/${id}`).then(result => {
            const response = result.data;
            setMedia(response);
            setLoading(false);
        })
        .catch(error => {
            console.error('Error fetching media data:', error);
            setFailed(true);
            setError('Error fetching media data: ' + error);
            setLoading(false);
        })
    }

    const getSimilarShows = (id) => {
        axios.get(`api/Media/GetSimilarShows/${id}`).then(result => {
            const response = result.data;
            setSimilarShows(response);
            //Loading?
        })
        .catch(error => {
            console.error('Error fetching media data:', error);
            setError('Error fetching media data: ' + error);
            setFailed(true);
            //Loading?
        })
    }

    const renderPage = (media) => (
        <Row className="ms-0" lg="auto" md="auto" sm="auto">
            <Col className="page-info-bar">
                <Row className="justify-content-center">
                    <img className="page-info-poster" src={`https://wsrv.nl/?url=https://simkl.in/posters/${media.poster}_m.jpg`} alt={media.title} />
                </Row>
                <Row className="justify-content-center page-info-header my-2">
                    Information
                </Row>
                <Row>
                    Year: {media.year}
                </Row>
                <Row>
                    YearStartEnd: {media.yearStartEnd}
                </Row>
                <Row>
                    Released: {media.released}
                </Row>
                <Row>
                    Director: {media.director}
                </Row>
                <Row>
                    Certification: {media.certification}
                </Row>
                <Row>
                    FirstAired: {media.firstAired}
                </Row>
                <Row>
                    LastAired: {media.lastAired}
                </Row>
                <Row>
                    Runtime: {media.runtime}
                </Row>
                <Row>
                    Total episodes: {media.totalEpisodes}
                </Row>
                <Row>
                    Network: {media.network}
                </Row>
                <Row>
                    Studios: {media.studios?.map(x => (
                        x.name
                    )).join(', ')}
                </Row>
                <Row>
                    Season: {media.season}
                </Row>
                <Row>
                    Status: {parseStatusValue(media.status)}
                </Row>
                <Row>
                    Type: {parseTypeValue(media.type)}
                </Row>
                <Row>
                    Genres: {media.genres?.map(x => (
                        x.name
                    )).join(', ')}
                </Row>
            </Col>
            <Col className="page-description">
                <Row className="m-0 page-score">
                    <Col>
                        <Row className="m-0 page-score-rating">
                            {media.ratings["simkl"].rating}
                        </Row>
                        <Row className="m-0">
                            Score
                        </Row>
                    </Col>
                    <Col>
                        <Row className="m-0 page-score-rating">
                            {media.ratings["simkl"].votes}
                        </Row>
                        <Row className="m-0">
                            Votes
                        </Row>
                    </Col>
                </Row>
                <Row className="m-0 my-2 page-info-header">Overview</Row>
                <Row className="m-0 mb-5">
                    { media.overview }
                </Row>
                {media.relations.length > 0 ? (
                    <>
                        <Row className="m-0 my-2 page-info-header">Relations</Row>
                        <Row className="m-0 mb-5">
                            {media.relations.map((x, index) => (
                                <Row key={x.id}>{x.title}</Row>
                            ))}
                        </Row>
                    </>
                ) : null}
                <Row className="m-0 my-2 page-info-header">Similar shows</Row>
                <Row className="m-0 mb-5">
                    {similarShows.map((x, index) => (
                        <Col className="page-similar me-2 mb-2" lg="auto" md="auto" sm="auto" key={x.id}>
                            <NavLink tag={Link} to={`/media/${x.id}`}>
                                <Row>
                                    <img className="page-similar-poster" src={`https://wsrv.nl/?url=https://simkl.in/posters/${x.poster}_c.jpg`} alt={x.title} />
                                </Row>
                                <Row>
                                    <div className="page-similar-card">{x.title}</div>
                                </Row>
                            </NavLink>
                        </Col>
                    ))}
                </Row>
                <Row className="m-0 my-2 page-info-header">Comments</Row>
                <Row>
                    <Form>
                        <Input
                            placeholder="Comment"
                            type="text"
                        />
                        <Button>
                            Submit
                        </Button>
                    </Form>
                </Row>
                <Row className="m-0 mb-5">
                    {media.posts.map((x, index) => (
                        <Row key={x.id}>{x.comment}</Row>
                    ))}
                </Row>
            </Col>
        </Row>
    );

    return (
        <div>
            {failed ? (
                <div className="text-danger">
                    {error}
                </div>
            ) : (
                <div>
                    <h1>{media.title}</h1>
                    <p>Here you can see info about {media.title}</p>
                    { loading ? <p><em>Loading...</em></p> : renderPage(media) }
                </div>
            )}
        </div>
    )
}