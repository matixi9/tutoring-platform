# Kredkorepetycje - Platforma Korepetycyjna
Platforma łącząca uczniów i korepetytorów. 
System umożliwia przeglądanie ofert, rejestrację użytkowników oraz zarządzanie ogłoszeniami z autoryzacją JWT.

## Instrukcja uruchomienia

### 1. Baza danych (wymagany Docker)
```bash
docker compose up -d
```

### 2. Konfiguracja Backendu (wymagany .NET 10 SDK)
```bash
cd backend/TutoringPlatform
dotnet run
```
Aplikacja domyślnie uruchomi się pod adresem: `http://localhost:5192`.
Dokumentacja API (Swagger) jest dostępna pod: `http://localhost:5192/swagger`.

### 3. Konfiguracja Frontendu (wymagany Node.js)
```bash
cd frontend/TutoringPlatformFeReact
npm install
npm run dev
```

## Autoryzacja
Dostęp do zarządzania ogłoszeniami (POST, PUT, DELETE) wymaga roli `Tutor` oraz poprawnego tokena JWT. 
Token należy przekazać w nagłówku:
`Authorization: Bearer {Twój_Token}`. 
Token otrzymuje się po zalogowaniu jako istniejący `Tutor`.