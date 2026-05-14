import { Link } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

const Navbar = () => {
        const { user, logout} = useAuth();
        return (
        <nav className="navbar">
            <Link to="/" className="logo">
                <span className="logo-k">k</span>
                <span className="logo-text">redkorepetycje</span>
            </Link>

            {/* <div className="nav-center">
                 <Link to="/how-it-works" className="nav-link">Jak to działa?</Link>
            </div> */}

            <div className="nav-right">
                {user?.role === 'Tutor' && (
                    <Link to="/addAd">
                        <button className="btn-secondary">Dodaj ogłoszenie</button>
                    </Link>
                )}
                {!!user ? (
                    <>
                    <span className="user-name">Witaj, {user.name}!</span>
                    <button onClick={logout} className="btn-secondary">
                        Wyloguj
                    </button>
                    </>
                ) : <>
                    <Link to="/login" >
                        <button className="btn-secondary">Logowanie</button>
                    </Link>

                    <Link to="/register?role=Tutor">
                        <button className="btn-primary">Dołącz jako tutor</button>
                    </Link>
                </>}
            </div>
        </nav>
    );
}
export default Navbar;