// App.jsx
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Navbar from './components/Navbar';
import UserDashboard from './pages/UserDashboard';
import UserDetails from './pages/UserDetails';
import AddUser from './pages/AddUser';
import EditUser from './pages/EditUser';
import Home from './pages/Home';

export default function App() {
  return (
    <Router>
      <div className="flex min-h-screen bg-teal-50">
        <Navbar />
        <main className="flex-1 p-8 transition-all duration-300">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/users" element={<UserDashboard />} />
            <Route path="/users/:id" element={<UserDetails />} />
            <Route path="/users/add" element={<AddUser />} />
            <Route path="/users/edit/:id" element={<EditUser />} />
          </Routes>
        </main>
      </div>
    </Router>
  );
}