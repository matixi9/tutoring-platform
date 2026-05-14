import { createContext, useState, useEffect, useContext } from 'react';
import { jwtDecode } from 'jwt-decode';

interface User {
  id: string;
  name: string;
  role: 'Student' | 'Tutor';
}

interface AuthContextType {
  user: User | null;
  isAuthenticated: boolean;
  login: (token: string) => void;
  logout: () => void;
}

export const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: {children : React.ReactNode}) => {
    const [user, setUser] = useState<User | null>(null);

    const decodeAndSetUser = (token: string) => {
        try{
            const decoded : any = jwtDecode(token);

            const userData : User = {
                id: decoded.Id,
                name: decoded.Name,
                role: decoded.Role,
            };
            setUser(userData);
        } catch (error: any){
            console.error("Błąd dekodowania tokena", error);
            logout();
        }
    }

    useEffect(() => {
    const token = localStorage.getItem('token');
    if (token) {
        decodeAndSetUser(token);  
     }
  }, []);

    const login = (newToken : string) => {
        localStorage.setItem('token',newToken);
        decodeAndSetUser(newToken);
    }

    const logout = () => {
        localStorage.removeItem('token');
        setUser(null);
    };

    return(
        <AuthContext.Provider value={{ user, isAuthenticated: !!user, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) throw new Error("useAuth must be used within AuthProvider");
  return context;
};