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

    if(!response.ok){
       const errorData = await response.json().catch(() => ({}));
       throw new Error(errorData.message || `Błąd HTTP: ${response.status}`
       );
    };

    if (response.status === 204) {
    return {} as T;
  }

  return await response.json();
}