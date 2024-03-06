import React, { useState, useEffect } from 'react';
import { Row, Col, NavLink, Button } from 'reactstrap';
import { Link } from 'react-router-dom';
import axios from 'axios';
import '../Style.css';
import { parseTypeValue } from '../EnumParser';

const RenderMediaTable = ({ media }) => {
    return (
        <table className="table table-striped text-white">
            <thead>
                <tr className="text-center">
                    <th>Rank</th>
                    <th>Title</th>
                    <th>Rating</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tbody>
                {
                    media?.map((m, index) => (
                        <tr key={m.id}>
                            <td className="text-white ranking-table-rank text-center align-middle">{index + 1}</td>
                            <td className="text-white ranking-table-title text-center">
                                <Row lg="auto" md="auto" xs="auto" className="">
                                    <Col>
                                        <NavLink tag={Link} to={`${m.id}`}>
                                            <img className="ranking-table-icon" src={`https://wsrv.nl/?url=https://simkl.in/posters/${m.poster}_cm.jpg`} alt={m.title} />
                                        </NavLink>
                                    </Col>
                                    <Col className="mt-1">
                                        <Row>
                                            <NavLink tag={Link} to={`${m.id}`}>
                                                {m.title}
                                            </NavLink>
                                        </Row>
                                        <Row className="ranking-table-info">
                                            {parseTypeValue(m.type)}
                                        </Row>
                                    </Col>
                                </Row>
                            </td>
                            <td className="text-white text-center align-middle">{m.ratings["simkl"].rating}</td>
                            <td className="text-white text-center align-middle">
                                <Button color="primary">
                                    Add To List
                                </Button> 
                            </td>
                        </tr>
                    ))
                }
            </tbody>
        </table>
    );
}

export default RenderMediaTable;