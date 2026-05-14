import { useEffect, useState } from "react";
import type { TutoringAd } from "../types/TutoringAds";
import { fetchData } from "../services/ApiService";
import AdCard from "../components/AdCard";
import { useLocation } from "react-router-dom";
import Spinner from "../components/Spinner";


const Home = () => {
    const [ads, setAds] = useState<TutoringAd[]>([]);
    const [search,setSearch] = useState('');
    const [onlyOnline, setOnlyOnline] = useState(false);
    const [maxPrice, setMaxPrice] = useState<number | ''>('');
    const [loading, setLoading] = useState(false);

    const location = useLocation();

    const fetchAds = async () => {
        setLoading(true);
        const timer = new Promise(resolve => setTimeout(resolve, 325));
        try{
            const params = new URLSearchParams();
            if(search) params.append('searchPhrase',search);
            if(onlyOnline) params.append('isOnline','true');
            if(maxPrice) params.append('maxPrice', maxPrice.toString());

            const [data] = await Promise.all([fetchData<TutoringAd[]>(`/Ads?${params.toString()}`),timer]);  
            setAds(data);
        } catch (err){
            console.error("Błąd przy pobieraniu ofert: ", err);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        if(location.pathname === '/' && location.search ===''){
            setSearch('');
            setOnlyOnline(false);
            setMaxPrice('');
        }
        fetchAds();
    }, [location]);


    return (
        <div className="home-layout">
            <aside className="filters">
                <h3>Filtry</h3>
            <form onSubmit={(e) => { e.preventDefault(); fetchAds(); }}>

                <div className="filter-group">
                
                    <label>Szukaj</label>
                    <input type="text"
                            className="form-input" 
                            placeholder="np. Analiza 2..."
                            onChange={(e) => setSearch(e.target.value)}
                            value={search}/>
                </div>

                <div className="filter-group">
                    <label>Cena do (zł/h)</label>
                    <input type="number" className="form-input" value={maxPrice} onChange={(e) => setMaxPrice(e.target.value ? Number(e.target.value) : '')} />
                </div>

                <div className="filter-group checkbox">
                    <input type="checkbox" id="online" checked={onlyOnline} onChange={(e) => setOnlyOnline(e.target.checked)} />
                    <label htmlFor="online">Tylko online</label>
                </div>

                <button className="btn-primary auth-button" onClick={fetchAds} type="submit">
                    Zastosuj filtry
                </button>

            </form>
                
                <button className="btn-secondary" 
                        style={{marginTop: '10px', width: '100%'}}
                        onClick={() => {
                            setSearch('');
                            setOnlyOnline(false);
                            setMaxPrice('');
        
                        }}>
                    Wyczyść
                </button>
            </aside>

            <main className="ads-grid">

                {loading ? (
                    <Spinner text="Pobieranie ofert..."/>
                ) : ads.length > 0 ? (
                    ads.map(ad => <AdCard key={ad.id} ad={ad} />)
                ) : (
                    <div className="no-results">
                        <p>Nie znaleźliśmy ogłoszeń spełniających Twoje kryteria.</p>
                        <span style={{color: 'var(--text-p)'}}>Spróbuj zmienić filtry lub wyszukać inną frazę.</span>
                    </div>
             )}     
            </main>
        </div>
    );
}
export default Home;