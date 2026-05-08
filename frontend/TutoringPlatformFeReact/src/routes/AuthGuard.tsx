import { Navigate, Outlet } from "react-router-dom";

const AuthGard = () => {
    const token = localStorage.getItem('token');

    if(!token){
        return <Navigate to="/login" replace/>;
    }

    return <Outlet />
};

export default AuthGard;