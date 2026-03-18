const express = require('express');
const { Pool } = require('pg');
const cors = require('cors');
const path = require('path');
require('dotenv').config();

const app = express();
app.use(cors());

// Database connection - using environment variables for security
const pool = new Pool({
  user: process.env.DB_USER,
  host: process.env.DB_HOST,
  database: process.env.DB_NAME,
  password: process.env.DB_PASSWORD,
  port: process.env.DB_PORT
});

// Serve HTML at root
app.get('/', (req, res) => {
  res.sendFile(path.join(__dirname, 'index.html'));
});

// API route to get message from DB
app.get('/hello', async (req, res) => {
  try {
    const result = await pool.query('SELECT message FROM greetings LIMIT 1;');
    res.json({ message: result.rows[0].message });
  } catch (err) {
    console.error('Database query failed:', err);
    res.status(500).send('Database error');
  }
});

// Start server
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => console.log(`Server running at http://localhost:${PORT}`));
