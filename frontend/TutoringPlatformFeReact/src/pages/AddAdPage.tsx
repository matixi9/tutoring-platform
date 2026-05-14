import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { fetchData } from '../services/ApiService';

const AddAdPage = () => {
    const navigate = useNavigate();
    const [loading, setLoading] = useState(false);
    const [success, setSuccess] = useState(false);
    const [error, setError] = useState<string | null>(null);

    const [formData, setFormData] = useState({
        title: '',
        description: '',
        price: 0,
        isOnline: false,
        isAvailable: true
    });

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true);
        setError(null);

        try{
            await fetchData('/Ads',{
                method: 'POST',
                body: formData
            });

            setSuccess(true);
            setTimeout(() => navigate('/'), 2000);
        } catch (error:any){
            setError(error.message);
        } finally{}
        setLoading(false);
    };

    return (
        <div className='auth-container'>
            <form className="auth-card" onSubmit={handleSubmit}>
                <h2>Opublikuj ogłoszenie</h2>
                <p>Przedstaw swoją ofertę nauczania.</p>

                {success && <div className="success-message">Ogłoszenie dodane pomyślnie!</div>}
                {error && <div className="error-message">{error}</div>}

                <div className='form-group'>
                    <label>Tytuł ogłoszenia</label>
                    <input 
                        type="text" 
                        className="form-input"
                        placeholder="np. Korepetycje z Analizy Matematycznej 2"
                        onChange={(e) => setFormData({...formData, title: e.target.value})}
                    />
                </div>

                <div className="form-group">
                    <label>Opis</label>
                    <textarea 
                        className="form-input"
                        placeholder='metody nauczania, doświadczenie itp.'
                        style={{minHeight: '120px'}}
                        required
                        onChange={(e) => setFormData({...formData, description: e.target.value})}
                    ></textarea>
                </div>

                <div className='form-row'>
                    <div className='form-group'>
                        <label htmlFor='price'>Cena (zł/h)</label>
                        <input 
                            type="number" 
                            placeholder='np. 80'
                            className="form-input"
                            onChange={(e) => setFormData({...formData, price: Number(e.target.value)})}
                        />
                    </div>

                    <div className="filter-group checkbox" style={{marginTop: '35px'}}>
                        <input 
                            type="checkbox" 
                            id="isOnline"
                            onChange={(e) => setFormData({...formData, isOnline: e.target.checked})}
                        />
                        <label htmlFor="isOnline">Lekcje Online</label>
                    </div>
                </div>

                <button type="submit" className="btn-primary" disabled={loading} style={{ display: 'block', margin: '0 auto' }}
>
                    {loading ? 'Publikowanie...' : 'Opublikuj ofertę'}
                </button>

            </form>
        </div>
    );
}
export default AddAdPage;