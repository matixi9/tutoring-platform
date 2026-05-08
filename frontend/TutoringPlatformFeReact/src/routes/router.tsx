import { createBrowserRouter } from 'react-router-dom';
import Home from "../pages/Home";
import Wrapper from '../components/Wrapper';



export const router = createBrowserRouter([
    {
    path: "/",
    element: <Wrapper />,
    children: [
      {
        path: "/", 
        element: <Home />,
      },
    //   {
    //     path: "/login", 
    //     element: <Login />, 
    //   },
    ],
  },
]);