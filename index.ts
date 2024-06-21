import express from 'express';
import bodyParser from 'body-parser';
import fs from 'fs';

const app = express();
const PORT = 3000;

app.use(bodyParser.json());

const dbFilePath = './src/db.json';

app.get('/ping', (req, res) => {
  res.send(true);
});

app.post('/submit', (req, res) => {
  const { name, email, phone, github_link, stopwatch_time } = req.body;
  const newSubmission = { name, email, phone, github_link, stopwatch_time };

  const db = JSON.parse(fs.readFileSync(dbFilePath, 'utf-8'));
  db.submissions.push(newSubmission);
  fs.writeFileSync(dbFilePath, JSON.stringify(db));

  res.sendStatus(201);
});

app.get('/read', (req, res) => {
  const index = parseInt(req.query.index as string, 10);

  const db = JSON.parse(fs.readFileSync(dbFilePath, 'utf-8'));
  if (index >= 0 && index < db.submissions.length) {
    res.json(db.submissions[index]);
  } else {
    res.status(404).send('Submission not found');
  }
});

app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});
