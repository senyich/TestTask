import UserForm from '../components/UserForm';
import RouteButton from '../components/RouteButton';
import { useParams, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import { useEffect, useState } from 'react';

export default function EditUser() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [initialData, setInitialData] = useState({ name: '', type: '' });

  useEffect(() => {
    async function fetchUser() {
      try {
        const response = await fetch(`http://localhost:5186/api/users/get-user/${id}`);
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        setInitialData({
          name: data.name,
          type: data.type
        });
      } catch (error) {
        toast.error('Failed to fetch user data');
      }
    }
    fetchUser();
  }, [id]);
  const handleSubmit = async (formData) => {
    try {
      const params = new URLSearchParams({
        Id: id,
        Name: formData.name,
        TypeId: formData.typeId
      });
      const response = await fetch(`http://localhost:5186/api/users/update-user?${params.toString()}`, {
        method: 'PUT'
      });
      if (!response.ok) {
        throw new Error(`Ошибка запроса, статус-код: ${response.status}`);
      }
      toast.success('Пользователь обновлен успешно');
      navigate(`/users/${id}`);
    } catch (error) {
      toast.error('Ошибка обновления пользователя');
    }
  };
  return (
    <div>
      <h1 className="text-2xl font-bold text-teal-700 mb-6">Изменить пользователя</h1>
      <UserForm onSubmit={handleSubmit} initialData={initialData} buttonText="Update User" />
    </div>
  );
}
