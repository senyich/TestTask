import { NavLink } from 'react-router-dom';
import NavButton from './NavButton';
import { useState } from 'react';

export default function Navbar(){
  const [isOpen, setIsOpen] = useState(false);

  return (
    <nav className={`fixed right-0 top-0 h-full w-64 bg-teal-700 shadow-xl transform ${isOpen ? 'translate-x-0' : 'translate-x-64'} transition-transform duration-300 ease-in-out z-50`}>
      <button 
        onClick={() => setIsOpen(!isOpen)}
        className={`absolute -left-12 top-4 bg-teal-600 hover:bg-teal-500 text-white p-3 rounded-l-lg transition-all duration-300 ${isOpen ? 'rotate-180' : ''}`}
      >
        <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M15 19l-7-7 7-7" />
        </svg>
      </button>

      <div className="p-6">
        <h1 className="text-2xl font-bold text-teal-100 mb-8">Возможные действия</h1>
        <ul className="space-y-4">
          <li>
            <NavButton to="/" icon="home" label="Главная страница" />
          </li>
          <li>
            <NavButton to="/users" icon="users" label="Список пользователей" />
          </li>
          <li>
            <NavButton to="/users/add" icon="user-add" label="Добавить пользователя" />
          </li>
        </ul>
      </div>
    </nav>
  );
};