import React, { useEffect, useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { fetchData } from '../services/ApiService';
import { useAuth } from '../context/AuthContext';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState<string | null>(null);
  const [isLoading, setIsLoading] = useState(false);
  const navigate = useNavigate();

  const {login, isAuthenticated} = useAuth();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);
    setIsLoading(true);

    try {
            const response = await fetchData<{ token: string }>('/Auth/login', {
            method: 'POST',
            body: { Email : email, Password : password }
            });

           login(response.token);

            navigate('/');

        } catch (error : any) {
            setError(error.message);
        } finally{
            setIsLoading(false);
        }
  };

  useEffect(() => {
    if (isAuthenticated) {
        navigate('/'); 
    }
}, [isAuthenticated, navigate]);
  return (
    <div className="auth-container">
      <div className="auth-card">
        <h2>Logowanie do systemu</h2>
        <p className="auth-subtitle">Zaloguj się, aby móc przeglądać oferty bez ograniczeń!</p>

        <form onSubmit={handleSubmit}>
            
          <div className="form-group">
            <label>Email</label>
            <input 
              type="email" 
              className="form-input" 
              value={email} 
              onChange={(e) => {
                setEmail(e.target.value);
                if (error) setError(null); 
            }}
              required 
            />
          </div>
          <div className="form-group">
            <label>Hasło</label>
            <input 
              type="password" 
              className="form-input" 
              value={password} 
              onChange={(e) => setPassword(e.target.value)} 
              required 
            />
          </div>


        {error && (
                <div className="error-message">
                    {error}
                </div>
            )}


          <button type="submit" className="btn-primary auth-button" disabled={isLoading}>
            {isLoading ? 'Logowanie...' : 'Zaloguj się'}
          </button>
        </form>

        <div className="auth-footer">
          Nie masz konta? {" "}<Link to="/register?role=Student">Zarejestruj się</Link> lub <Link to="/register?role=Tutor">dołącz jako tutor</Link>
        </div>
      </div>
    </div>
  );
};

export default Login;