import { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import LoadingSpinner from '../components/LoadingSpinner';
import ErrorAlert from '../components/ErrorAlert';
import RouteButton from '../components/RouteButton';

export default function UserDetails(){
  const { id } = useParams();
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const response = await axios.get(`http://localhost:5186/api/users/get-user/${id}`);
        setUser(response.data);
        setLoading(false);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      }
    };

    fetchUser();
  }, [id]);

  if (loading) return <LoadingSpinner />;
  if (error) return <ErrorAlert message={error} />;

  return (
    <div className="max-w-md mx-auto bg-white rounded-xl shadow-md overflow-hidden">
    <RouteButton text={"Вернуться к списку"} path={"/users"}/>
      <div className="p-8">
        <div className="uppercase tracking-wide text-sm text-teal-600 font-semibold">Карточка пользователя</div>
        <div className="mt-4">
          <p className="text-gray-700"><span className="font-semibold">ID:</span> {user.id}</p>
          <p className="text-gray-700"><span className="font-semibold">Имя:</span> {user.name}</p>
          <p className="text-gray-700"><span className="font-semibold">Тип:</span> {user.type}</p>
        </div>
      </div>
    </div>
  );
};