# Hello World with PostgreSQL

A simple Node.js/Express application that connects to a PostgreSQL database.

## Setup Instructions

### 1. Install Dependencies
```bash
npm install
```

### 2. Configure Environment Variables
Copy the `.env.example` file to `.env`:
```bash
cp .env.example .env
```

Then edit `.env` and fill in your actual database credentials:
```
DB_USER=postgres
DB_HOST=localhost
DB_NAME=testDB
DB_PASSWORD=your_actual_password
DB_PORT=5432
PORT=3000
```

**WICHTIG:** Die `.env` Datei wird nicht ins Repository committed (ist in `.gitignore`). 
Passwörter dürfen niemals im Quellcode stehen!

### 3. Run the Application
```bash
npm start
```

## Security Improvements
- ✅ Passwörter werden nun in `.env` Dateien gespeichert (nicht im Quellcode)
- ✅ `.env` ist in `.gitignore` eingetragen
- ✅ `.env.example` dient als Vorlage ohne sensitive Daten
- ✅ Verwendung von `dotenv` Package für Environment Variables

## Dependencies
- `express` - Web framework
- `pg` - PostgreSQL client
- `cors` - Cross-Origin Resource Sharing
- `dotenv` - Environment variable management
