export async function fetchData<T>(url: string): Promise<T> {
    const response = await fetch(url, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    });
    if(!response.ok){
        throw new Error(
      `Błąd podczas pobierania danych. Status: ${response.status}`,
    );
    };
    const data = await response.json();
    return data as T;
    
}