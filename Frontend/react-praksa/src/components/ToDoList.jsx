
import { useState, useEffect } from "react";

function ToDoList({ email }) {
  const storageKey = `todos_${email}`;
  const [task, setTask] = useState("");

  const [todos, setTodos] = useState(() => {
    const saved = localStorage.getItem(storageKey);
    return saved ? JSON.parse(saved) : [];
  });






  useEffect(() => {
    localStorage.setItem(storageKey, JSON.stringify(todos));
  }, [todos, storageKey]);



  const handleAddTodo = (e) => {
    e.preventDefault();
    if (task.trim() !== "") {
      setTodos([...todos, { id: Date.now(), text: task }]);
      setTask("");
    }
  };

  const handleDeleteTodo = (id) => {
    setTodos(todos.filter((todo) => todo.id !== id));
  };

  return (
   
    <div className="todo-container">
      <form onSubmit={handleAddTodo} className="todo-form">
        <input
          type="text"
          placeholder="Add task..."
          value={task}
          onChange={(e) => setTask(e.target.value)}
        />
        <button type="submit" className="login-btn">Add</button>
      </form>

      <ul className="todo-list">
        {todos.map((item) => (
          <li key={item.id} className="todo-item">
            <span className="todo-text">{item.text}</span>
            <button className="delete-btn" onClick={() => handleDeleteTodo(item.id)}>
              ✕
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default ToDoList;