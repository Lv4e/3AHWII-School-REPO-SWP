# 3AHWII-School-REPO-SWP
Repository for SWP in 3AHWII

## Änderungen basierend auf Feedback vom 18.03.2026

### Kritische Sicherheitsprobleme behoben ✅

**Problem:** Passwort war im Quellcode sichtbar (`2025-11-12 helloWorld with Prisma/index.js:14`)

**Lösung:**
- Hardcodiertes Passwort entfernt
- Environment Variables mit `dotenv` Package implementiert
- `.env` Datei für lokale Konfiguration erstellt (wird nicht committed)
- `.env.example` als Vorlage ohne sensitive Daten hinzugefügt
- `.gitignore` aktualisiert um `.env` Dateien auszuschließen

### Code-Qualität verbessert ✅

1. **Tippfehler behoben:**
   - `2025-09-10 Exeption aufnahme` → `2025-09-10 Exception Handling`

2. **Unit-Tests implementiert:**
   - 12 umfassende Tests für die Fraction-Klasse in `BrucheMitTestVersion`
   - Alle Tests erfolgreich (12/12 passing)
   - Test-Coverage für: Konstruktor, Parsing, Addition, ToString, Exception Handling

3. **Fraction-Klasse hinzugefügt:**
   - Vollständige Implementierung mit Properties, Operatoren und Methoden
   - Demo-Programm in Program.cs

### Repository-Verbesserungen ✅

1. **Verbesserte .gitignore:**
   - `node_modules/` hinzugefügt
   - `.env` und `.env.local` hinzugefügt
   - Bereits bestehende Einträge für `bin/`, `obj/` bleiben aktiv

2. **Dokumentation:**
   - Detailliertes README für Node.js-Projekt mit Sicherheitshinweisen
   - Setup-Anleitung für Entwicklungsumgebung

3. **Dependencies aktualisiert:**
   - `dotenv`, `cors`, `pg` zu `package.json` hinzugefügt

### Nächste Schritte

Empfohlene Verbesserungen für die Zukunft:
- [ ] Regelmäßigere Commit-Gewohnheit entwickeln
- [ ] Bessere Commit-Nachrichten (beschreibend statt "Add files via upload")
- [ ] Code vor dem Commit auf Tippfehler überprüfen
- [ ] Projekte konsequent weiterentwickeln statt duplizieren

## Projekt-Übersicht

- **2025-09-04.cs** - Bruchrechnung (einfache Version)
- **2025-09-10 Exception Handling** - Bruchrechnung mit Exception Handling
- **2025-09-20 testfälle added** - Bruchrechnung mit erweiterten Testfällen
- **2025-11-12 helloWorld with Prisma** - Node.js/Express mit PostgreSQL
- **2025-11-16 Fraction Programm** - Objektorientierte Bruch-Klasse
- **2025-12-01 BrucheMitTestVersion** - Bruch-Projekt mit Unit-Tests ✅ (neu implementiert)
- **2026-01-14 CsvFileOutput** - CSV-Datei Reader
