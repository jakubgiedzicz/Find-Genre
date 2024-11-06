import { createBrowserRouter } from 'react-router-dom';
import Home from '../Pages/Home/Home';
import App from '../App';
import SearchByTag from '../Pages/SearchByTag/SearchByTag';
import GenreDetails from '../Pages/GenreDetails/GenreDetails';
export const Router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children: [
            { path: "", element: <Home /> },
            { path: "/search-by-tag", element: <SearchByTag /> },
            { path: "/genre-details", element: <GenreDetails /> }
        ]
    }
])