import { createContext, useState, useEffect, useContext } from 'react';
import { jwtDecode } from 'jwt-decode';

export const AuthContext = createContext<any>(null);

export const AuthProvider = ({ children }: any) => {
    const [token, setToken] = useState(localStorage.getItem('token'))

    const getUserName = (t: string | null) => {
        if(!t) return null;
        try{
            const decoded: any = jwtDecode(t);
            return decoded.Name || "Użytkownik"; 
        } catch { return null; }
    }

    useEffect(() => {
    const token = localStorage.getItem('token');
    if (token) {
      getUserName(token);
    }
  }, []);

    const [userName,setUserName] = useState(getUserName(token))

    const login = (newToken : string) => {
        localStorage.setItem('token',newToken);
        setToken(newToken);
        setUserName(getUserName(newToken));
    }

    const logout = () => {
        localStorage.removeItem('token');
        setToken(null);
        setUserName(null);
    };

    return(
        <AuthContext.Provider value={{ token, userName, login, logout, isAuthenticated: !!token }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => useContext(AuthContext);