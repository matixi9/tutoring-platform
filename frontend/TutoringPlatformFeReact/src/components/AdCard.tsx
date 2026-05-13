import type { TutoringAd } from "../types/TutoringAds";

const AdCard = ({ad} : {ad : TutoringAd}) => {
    return (
        <div className="ad-card">
            <div className="ad-status">
                {ad.isOnline ? (
                    <span className="badge badge-online">Online</span>
                ) : (
                    <span className="badge badge-local">Stacjonarnie</span>
                )}
            </div>
            <h3 className="ad-title">{ad.title}</h3>
            <p className="ad-description">
                {ad.description.length > 93
                    ? ad.description.substring(0, 93) + "..." 
                    : ad.description}
            </p>
            <div className="ad-footer">
                <div className="ad-info">
                    <span className="ad-price">{ad.price} zł/h</span>
                    <span className="ad-tutor">korepetytor: {ad.tutorName || "Anonim"}</span>
                </div>
                <button className="btn-primary-sm">Szczegóły</button>
            </div>
        </div>
    );
};
export default AdCard;