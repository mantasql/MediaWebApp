import React from 'react';

export const parseTypeValue = (type) => {
    switch (type) {
        case 0:
            return "Movie";
        case 1:
            return "TV series";
        case 2:
            return "Anime";
        default: return 'Unknown';
    }
}

export const parseStatusValue = (status) => {
    switch (status) {
        case 0:
            return "Airing";
        case 1:
            return "Finished airing";
        default: return 'Unknown';
    }
}

export const parseGenreValue = (genre) => {
    switch (genre) {
        case 0:
            return "Action";
        case 1:
            return "Comedy";
        case 2:
            return "Drama";
        case 3:
            return "Fantasy";
        case 4:
            return "Horror";
        case 5:
            return "Mystery";
        case 6:
            return "Romance";
        case 7:
            return "Thriller";
        case 8:
            return "Western";
        case 9:
            return "Crime";
        case 10:
            return "Super Power";
        case 11:
            return "Shounen";
        case 12:
            return "Sci-Fi";
        case 13:
            return "Military";
        case 14:
            return "Adventure";
        case 15:
            return "Science Fiction";
        case 16:
            return "Suspense";
        case 17:
            return "Psychological";
        case 18:
            return "Supernatural";
        case 19:
            return "School";
        case 20:
            return "Mecha";
        case 21:
            return "Magic";
        case 22:
            return "Demons";
        default: return 'Unknown';
    }
}