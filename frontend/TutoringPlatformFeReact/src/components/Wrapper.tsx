import { Outlet } from "react-router-dom";
import Navbar from "./Navbar";

const Wrapper = () => {
    return (
        <div className="app-container">
            <Navbar />

            <main className="content">
                <Outlet/>
            </main>
            <footer className="footer">
                <p className="footer-text">© 2026 Kredkorepetycje</p>
            </footer>       
        </div>
    );
};
export default Wrapper;