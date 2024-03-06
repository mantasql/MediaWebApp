import React from 'react';
import { Card, CardBody, CardTitle } from "reactstrap";

const PosterCard = ({ item }) => {
    return (
        <Card>
            <img src={item.src} alt={item.altText} />
            <CardBody>
                <CardTitle>{item.title}</CardTitle>
            </CardBody>
        </Card>
   );
}

export default PosterCard;