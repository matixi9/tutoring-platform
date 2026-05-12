import { useEffect, useState } from "react";
import { useNavigate, Link, useSearchParams } from 'react-router-dom';
import { fetchData } from "../services/ApiService";
import { useAuth } from "../context/AuthContext";

const Register = () => {
  const [searchParams] = useSearchParams();
    
  const initialRole = searchParams.get('role') || 'Student';

  const{isAuthenticated} = useAuth();

  const [formData, setFormData] = useState({
    name: '',
    email: '',
    password: '',
    role: initialRole
  });
  const [error, setError] = useState<string | null>(null);
  const [isLoading, setIsLoading] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);
    setIsLoading(true);
    try {
      await fetchData<string>('/Auth/register', {
            method: 'POST',
            body: formData
            });
      navigate('/login'); 
    } catch (error : any) {
    setError(error.message);
    } finally {
        setIsLoading(false);
    }
  };

  useEffect(() => {
    const roleFromUrl = searchParams.get('role');
    if (roleFromUrl) {
      setFormData(prev => ({ ...prev, role: roleFromUrl }));
    }
  }, [searchParams]);

  useEffect(() => {
    if (isAuthenticated) {
        navigate('/');
    }
}, [isAuthenticated, navigate]);

  return (
    <div className="auth-container">
      <div className="auth-card">
        <h2>Rejestracja jako {formData.role === 'Tutor' ? 'Tutor' : 'Student'}</h2>
        <p className="auth-subtitle">Dołącz do społeczności kredkorepetycje</p>

        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label>Imię i Nazwisko</label>
            <input 
              type="text" 
              className="form-input" 
              value={formData.name}
              onChange={(e) => {setFormData({...formData, name: e.target.value}); if (error) setError(null); }} 
              required 
            />
          </div>
          <div className="form-group">
            <label>Rola</label>
            <select 
              className="form-input" 
              value={formData.role}
              onChange={(e) => setFormData({...formData, role: e.target.value})}
            >
              <option value="Student">Student (szukam pomocy)</option>
              <option value="Tutor">Tutor (chcę uczyć)</option>
            </select>
          </div>
          <div className="form-group">
            <label>Email</label>
            <input 
              type="email" 
              className="form-input" 
              value={formData.email}
              onChange={(e) => setFormData({...formData, email: e.target.value})} 
              required 
            />
          </div>
          <div className="form-group">
            <label>Hasło</label>
            <input 
              type="password" 
              className="form-input" 
              value={formData.password}
              onChange={(e) => setFormData({...formData, password: e.target.value})} 
              required 
            />
          </div>

             {error && (
                <div className="error-message">
                    {error}
                </div>
            )}

          <button type="submit" className="btn-primary auth-button">{isLoading ? 'Logowanie...' : 'Zarejestruj się'}</button>
        </form>

        <div className="auth-footer">
          Masz już konto? <Link to="/login">Zaloguj się</Link>
        </div>
      </div>
    </div>
  );
}

export default Register;