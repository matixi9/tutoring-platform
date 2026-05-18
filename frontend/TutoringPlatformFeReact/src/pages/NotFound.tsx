import { Link } from "react-router-dom";

const NotFound = () => {
    return (
        <div style={{textAlign: 'center', 
            padding: '100px 20px', 
            color: 'var(--text-h)'}}>

            <h1 style={{fontSize: '6rem', color: 'var(--accent)', margin: 0}}>404</h1>
            <h2>Ups! Strona nie istnieje</h2>
            <p style={{color: 'var(--text-p)', marginBottom: '2rem'}}>Niestety zabłądziłaś/eś w odkrywaniu Kredkorepetycji</p> 
            <Link to="/" className="btn-primary" style={{ textDecoration: 'none' }}>
                Wróć na stronę główną
            </Link>       
            
        </div>
    );
};

export default NotFound;