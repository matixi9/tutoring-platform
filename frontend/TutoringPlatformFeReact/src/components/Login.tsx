import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { fetchData } from '../services/ApiService';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState<string | null>(null);
  const [isLoading, setIsLoading] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);
    setIsLoading(true);

    try {
            const response = await fetchData<{ token: string }>('/Auth/login', {
            method: 'POST',
            body: { Email : email, Password : password }
            });

            localStorage.setItem('token', response.token);

            navigate('/');

        } catch (error : any) {
            setError(error.message);
        } finally{
            setIsLoading(false);
        }


  };

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
        {error && <p style={{ color: 'var(--accent)', fontSize: '0.8rem' }}>{error}</p>}


          <button type="submit" className="btn-primary auth-button" disabled={isLoading}>
            {isLoading ? 'Logowanie...' : 'Zaloguj się'}
          </button>
        </form>

        <div className="auth-footer">
          Nie masz konta? <Link to="/register">Zarejestruj się</Link> lub <Link to="/register">dołącz jako tutor</Link>
        </div>
      </div>
    </div>
  );
};

export default Login;