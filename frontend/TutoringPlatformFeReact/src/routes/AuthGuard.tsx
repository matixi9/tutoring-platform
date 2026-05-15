import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import Spinner from "../components/Spinner";

interface Props {
    allowedRoles?: string[];
}

const AuthGard = ({allowedRoles } : Props) => {
    const { user, isAuthenticated, isInitialLoading } = useAuth();

    if(isInitialLoading){
        return <Spinner text="Ładowanie..."/>
    }

    if(!isAuthenticated){
        return <Navigate to="/login" replace/>;
    }

    if(allowedRoles && user && !allowedRoles.includes(user.role)){
        return <Navigate to="/" replace />;
    }

    return <Outlet/>

};

export default AuthGard;