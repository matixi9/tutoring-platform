import { Outlet } from "react-router-dom";
import Navbar from "./Navbar";
import { Toaster } from 'react-hot-toast';

const Wrapper = () => {
    return (
        <div className="app-container">
            <Navbar />

            <Toaster 
            position="top-right" 
            toastOptions={{
                className: "react-hot-toast",
                duration: 4000,  
              
            style: { 
                background: 'var(--bg-card)',
                color: 'var(--text-h)',
                border: '1px solid var(--border)',
                borderRadius: '12px',
                padding: '16px',
                fontSize: '0.9rem',
                fontFamily: 'sans-serif',
                
            },
            success: {
              iconTheme: {
                primary: '#2ecc71',
                secondary: '#fff',
            },
         },
            error: {
                iconTheme: {
                    primary: 'var(--accent)', 
                    secondary: '#fff',
             },
            style: {
                border: '1px solid var(--accent)',
            }
            },
            
            }} />

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