const API_URL = 'http://localhost:5104/api/Task';  

document.getElementById('taskForm').addEventListener('submit', async function (e) {
  e.preventDefault();
  const errorDiv = document.getElementById('errorMessages');
  errorDiv.innerHTML = '';

  const description = document.getElementById('description').value.trim();
  const timeSpent = document.getElementById('timeSpent').value;

  if (!description || !timeSpent) {
    alert('Пожалуйста, заполните все поля');
    return;
  }

  const task = {
    description: description,
    timeSpent: timeSpent + ":00",
    executor: "demo_user", // автоматически
    date: new Date().toISOString().split('T')[0] // автоматически
  };

  const response = await fetch(API_URL, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(task)
  });

  if (response.ok) {
    loadTasks();
    this.reset();
  } else {
    const error = await response.json();
    const messages = [];
    for (let key in error.errors) {
      messages.push(...error.errors[key]);
    }
    errorDiv.innerHTML = messages.join("<br>");
  }
});

async function loadTasks() {
  const res = await fetch(API_URL);
  const tasks = await res.json();
  console.log(tasks);
  const tbody = document.getElementById('taskBody');
  tbody.innerHTML = '';

  let totalMinutes = 0;

  tasks.forEach(task => {
    const tr = document.createElement('tr');
    tr.innerHTML = `
      <td>${formatDate(task.date)}</td>
      <td>${task.description}</td>
      <td>${task.timeSpent.slice(0,5)}</td>
      <td>${task.executor}</td>
    `;
    tbody.appendChild(tr);

    const [hh, mm] = task.timeSpent.split(':').map(Number);
    totalMinutes += hh * 60 + mm;
  });

  document.getElementById('totalTime').textContent = formatTime(totalMinutes);
}

function formatTime(minutes) {
  const hh = String(Math.floor(minutes / 60)).padStart(2, '0');
  const mm = String(minutes % 60).padStart(2, '0');
  return `${hh}:${mm}`;
}

function formatDate(dateStr) {
  const date = new Date(dateStr);
  return date.toLocaleDateString('ru-RU');
}

loadTasks();
