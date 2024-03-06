import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Media } from "./components/Media/Media";
import { Movies } from "./components/Media/Movies";
import { TvSeries } from "./components/Media/TvSeries";
import { MoviePage } from "./components/Media/Pages/MoviePage";
import { ProfilePage } from "./components/Media/User/ProfilePage";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
    },
    {
        path: '/media',
        element: <Media />
    },
    {
        path: '/movies',
        element: <Movies />
    },
    {
        path: '/tv-series',
        element: <TvSeries />
    },
    {
        path: '/media/:id',
        element: <MoviePage />
    },
    {
        path: '/profile/:id',
        element: <ProfilePage />
    }
];

export default AppRoutes;
