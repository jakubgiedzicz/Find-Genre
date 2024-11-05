import { createBrowserRouter } from 'react-router-dom';
import Home from '../Pages/Home/Home';
import App from '../App';
export const Router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children: [
            { path: "", element: <Home /> }
        ]
    }
])