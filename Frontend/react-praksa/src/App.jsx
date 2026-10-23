import "./App.css";
import { useState } from "react";
import Header from "./components/Header";
import LoginForm from "./components/LoginForm";
import Counter from "./components/Counter";
import ToDoList from "./components/ToDoList";

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [email, setEmail] = useState("");

  const handleLogin = (userEmail) => {
    setEmail(userEmail);
    setIsLoggedIn(true);
  };

  const handleLogout = () => {
    setEmail("");
    setIsLoggedIn(false);
  };

  return (
    <div className="main">
      <Header isLoggedIn={isLoggedIn} onLogout={handleLogout} />

      <h1 className="hero-title">
        Welcome to my page{isLoggedIn && `, ${email}`}
      </h1>

      {isLoggedIn ? (
        <>
          <Counter email={email} />
          <ToDoList email={email} />
        </>
      ) : (
        <LoginForm onLogin={handleLogin} />
      )}
    </div>
  );
}

export default App;