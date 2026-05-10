import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
// import { apiFetch } from '../services/api';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

//     try {
//       // Zakładamy, że backend zwraca obiekt { token: "..." }
//       const data = await apiFetch<{ token: string }>('/auth/login', {
//         method: 'POST',
//         body: JSON.stringify({ email, password }),
//       });

//       localStorage.setItem('token', data.token); // Zapisujemy bilet wstępu
//       navigate('/'); // Wracamy na stronę główną
//     } catch (err: any) {
//       setError(err.message || 'Nieudane logowanie');
//     }
  };

  return (
    <div className="auth-container">
      <div className="auth-card">
        <h2>Logowanie do systemu</h2>
        <p className="auth-subtitle">Zaloguj się do kredkorepetycje</p>

        {error && <p style={{ color: 'var(--accent)', fontSize: '0.8rem' }}>{error}</p>}

        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label>Email</label>
            <input 
              type="email" 
              className="form-input" 
              value={email} 
              onChange={(e) => setEmail(e.target.value)} 
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
          <button type="submit" className="btn-primary auth-button">Zaloguj się</button>
        </form>

        <div className="auth-footer">
          Nie masz konta? <Link to="/register">Zarejestruj się</Link> lub <Link to="/register">dołącz jako tutor</Link>
        </div>
      </div>
    </div>
  );
};

export default Login;