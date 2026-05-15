import toast from 'react-hot-toast';

const baseURL = "http://localhost:5192/api";

interface RequestOptions extends RequestInit{
    body?: any;
}

export async function fetchData<T>(endpoint : string, options : RequestOptions = {}): Promise<T> {
    const {body, ...customConfig} = options;

    const token = localStorage.getItem('token');

    const headers : HeadersInit = {
        'Content-Type': 'application/json',
        ...(token ? { 'Authorization': `Bearer ${token}` } : {}),
        ...customConfig.headers,
    }

    const config: RequestInit = {
        ...customConfig,
        headers,
        ...(body ? { body: JSON.stringify(body) } : {}),
    }
    
    const response = await fetch(`${baseURL}${endpoint}`, config);


    if (response.status === 204) return {} as T;

    const responseText = await response.text();

    if(!response.ok){

        let finalMessage = "Błąd: ";

        try {
        const errorJson = JSON.parse(responseText);

        if (errorJson.errors && Array.isArray(errorJson.errors)) {
            finalMessage = errorJson.errors[0].errorMessage;
        } else {
            finalMessage = errorJson.error || errorJson.message || `Błąd: ${response.status}`;
        }
    } catch{
        finalMessage = (responseText || `Błąd HTTP: ${response.status}`);
    }

        switch(response.status){
            case 400: 
                toast.error(`Błędne dane: ${finalMessage}!`)
                break;
            case 401:
                if(localStorage.getItem('token')){
                    toast.error("Sesja wygasła. Zaloguj się ponownie.");
                    localStorage.removeItem('token');
                }else toast.error("Błędny login, spróbuj jeszcze raz")
                break;
            case 403:
                toast.error("Nie masz uprawnień do tej akcji.");
                break;
            case 500:
                toast.error("Błąd serwera. Spróbuj później.");
                break;
            default:
                toast.error(finalMessage);
        }

        throw new Error(finalMessage);
    }

    try{
        return JSON.parse(responseText);
    } catch {
        return responseText as any;
    }

};