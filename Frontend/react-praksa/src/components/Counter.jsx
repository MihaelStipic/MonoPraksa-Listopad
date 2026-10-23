import { useState, useEffect } from "react";

function Counter({ email }) {
  const storageKey = `clicks_${email}`;

  const [clicks, setClicks] = useState(() => {
    const saved = localStorage.getItem(storageKey);
    return saved ? Number(saved) : 0;
  });

  useEffect(() => {
    localStorage.setItem(storageKey, clicks);
  }, [clicks, storageKey]);

  return (
    <div className="login-card">
      <h1>{clicks}</h1>
      <button className="login-btn" onClick={() => setClicks(clicks + 1)}>
        Press
      </button>
    </div>
  );
}

export default Counter;