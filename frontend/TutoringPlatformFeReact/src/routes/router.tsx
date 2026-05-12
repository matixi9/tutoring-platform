import { createBrowserRouter } from 'react-router-dom';
import Wrapper from '../components/Wrapper';
import Home from '../pages/Home';
import AuthGuard from './AuthGuard';
import Login from '../pages/Login';
import Register from '../pages/Register';


export const router = createBrowserRouter([
    {
        path: "/",
        element : <Wrapper />,
        children: [
            {path: "/", element: <Home/>},
            {path: "/login", element: <Login/>},
            {path: "/register", element: <Register/> },
            {
                element: <AuthGuard/>,
                children: [
                    // {path : "/moje-lekcje", element: <MyLessons />},
                    // { path: "/dodaj-ogloszenie", element: <CreateOffer /> },
                    // { path: "/profil", element: <Profile /> },
                ]

            }

        ],
    },
]);