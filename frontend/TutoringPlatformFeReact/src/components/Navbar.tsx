import { Link } from 'react-router-dom';

const Navbar = () => {
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
                <Link to="/login" >
                  <button className="btn-secondary">Logowanie</button>
                </Link>
                <button className="btn-primary">Dołącz jako tutor</button>
            </div>
        </nav>
    );
}
export default Navbar;