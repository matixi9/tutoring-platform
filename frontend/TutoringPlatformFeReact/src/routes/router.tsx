import { createBrowserRouter } from 'react-router-dom';
import Wrapper from '../components/Wrapper';
import Home from '../pages/Home';
import AuthGuard from './AuthGuard';
import Login from '../pages/Login';
import Register from '../pages/Register';
import AddAdPage from '../pages/AddAdPage';


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
                    // { path: "/me", element: <Profile /> },
                ]

            },
            { 
                element: <AuthGuard allowedRoles={['Tutor']}/>,
                children: [
                    { path: "/addAd", element: <AddAdPage /> },
                    // { path: "/myOffers", element: <MyOffers /> },
                ]

            },
            {
                element: <AuthGuard allowedRoles={['Student']} />, 
                children: [
                    // { path: "/myLessons", element: <MyLessons /> },
                ]
            }
        ],
    },
]);