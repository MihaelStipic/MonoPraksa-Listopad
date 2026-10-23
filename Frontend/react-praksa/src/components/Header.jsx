import { useState } from "react";

function Header({ isLoggedIn, onLogout }) {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <>
      <div className="card">
        <div className="text">This is my website</div>
        <button
          type="button"
          className="menu-icon"
          onClick={() => setIsOpen(!isOpen)}
          aria-label="Toggle menu">
          ―
        </button>
      </div>

      {isOpen && (
        <div className="dropdown-menu">
          <ul>
            <li className="text-in-border"><a href="#pocetna">Main</a></li>
            <li className="text-in-border"><a href="#postavke">Settings</a></li>
            <li className="text-in-border"><a href="#profil">Profile</a></li>
            {isLoggedIn && (
              <li className="text-in-border">
                <a href="#odjava" onClick={onLogout}>Log out</a>
              </li>
            )}
          </ul>
        </div>
      )}
    </>
  );
}

export default Header;