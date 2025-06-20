import UserForm from '../components/UserForm';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import { useState } from 'react';
import RouteButton from '../components/RouteButton';

export default function AddUser() {
  const navigate = useNavigate();
  const [initialData] = useState({ name: '', typeId: '' }); 

  const handleSubmit = async (formData) => {
    try {
      const params = new URLSearchParams({
        Name: formData.name,
        TypeId: formData.typeId
      });

      const response = await fetch(`http://localhost:5186/api/users/add-user?${params.toString()}`, {
        method: 'POST',
        headers: {
          'Accept': 'application/json'
        }
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.json();
      toast.success(`Пользователь успешно добавлен, его id: ${data.id}`);
      navigate('/users');
    } catch (error) {
      toast.error('Ошибка добавления пользователя');
    }
  };

  return (
    <div>
      <h1 className="text-2xl font-bold text-teal-700 mb-6">Добавить пользователя</h1>
      <RouteButton text={"Вернуться к списку"} path={"/users"} />
      <UserForm onSubmit={handleSubmit} initialData={initialData} buttonText="Добавить" />
    </div>
  );
}
