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
        try {
        const errorJson = JSON.parse(responseText);
        let finalMessage = "";

        if (errorJson.errors && Array.isArray(errorJson.errors)) {
            finalMessage = errorJson.errors[0].errorMessage;
        } else {
            finalMessage = errorJson.error || errorJson.message || `Błąd: ${response.status}`;
        }
        throw new Error(finalMessage);
    } catch (e: any) {
        throw new Error(e.message || responseText || `Błąd HTTP: ${response.status}`);
    }
    }

    try{
        return JSON.parse(responseText);
    } catch {
        return responseText as any;
    }

};