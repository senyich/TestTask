import UserCard from './UserCard';
import { useState, useEffect, useCallback } from 'react';
import LoadingSpinner from './LoadingSpinner';
import ErrorAlert from './ErrorAlert';

export default function UserList({ endpoint }) {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [downloading, setDownloading] = useState(false);

  const fetchUsers = useCallback(async () => {
    setLoading(true);
    setError(null);
    try {
      const response = await fetch(`http://localhost:5186/api/users/${endpoint}`);
      if (!response.ok) {
        throw new Error(`Не удалось получить список пользователей`);
      }
      const data = await response.json();
      setUsers(data);
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  }, [endpoint]);

  useEffect(() => {
    fetchUsers();
  }, [fetchUsers]);

  const handleDownload = () => {
    setDownloading(true);
    fetch('http://localhost:5186/api/users/export-users', {
      method: 'GET',
      headers: {
        accept: '*/*',
      },
    })
      .then((res) => {
        if (!res.ok) throw new Error('Ошибка при загрузке файла');
        return res.blob();
      })
      .then((blob) => {
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = 'users.xlsx'; 
        document.body.appendChild(a);
        a.click();
        a.remove();
        window.URL.revokeObjectURL(url);
      })
      .catch((err) => {
        alert(`Ошибка при скачивании файла: ${err.message}`);
      })
      .finally(() => {
        setDownloading(false);
      });
  };

  if (loading) return <LoadingSpinner />;
  if (error) return <ErrorAlert message={error} />;
  return (
    <div>
      <div className="mb-4 flex justify-end space-x-2">
        <button
          onClick={fetchUsers}
          className="px-4 py-2 bg-teal-600 text-white rounded hover:bg-teal-700 focus:outline-none focus:ring-2 focus:ring-teal-500"
          type="button"
          disabled={downloading}
        >
          Обновить список пользователей
        </button>
        <button
          onClick={handleDownload}
          className="px-4 py-2 bg-teal-600 text-white rounded hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500"
          type="button"
          disabled={downloading}
        >
          {downloading ? 'Скачивание...' : 'Скачать XLSX таблицу с пользователями'}
        </button>
      </div>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {users.map(user => (
          <UserCard key={user.id} user={user} />
        ))}
      </div>
    </div>
  );
}
