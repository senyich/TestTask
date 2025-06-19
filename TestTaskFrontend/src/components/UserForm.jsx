import { useState, useEffect } from 'react';

export default function UserForm({ onSubmit, initialData = { name: '', typeId: '' }, buttonText = 'Submit' }) {
  const [formData, setFormData] = useState(initialData);
  const [types, setTypes] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    setFormData(initialData);
  }, [initialData]);

  useEffect(() => {
    async function fetchTypes() {
      try {
        const response = await fetch('http://localhost:5186/api/users/get-all-types');
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        setTypes(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    }
    fetchTypes();
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit({
      name: formData.name,
      typeId: formData.typeId
    });
  };

  if (loading) return <div className="text-center py-8">Загрузка типов пользователей...</div>;
  if (error) return <div className="text-center py-8 text-red-500">Ошибка при загрузке {error}</div>;

  return (
    <form onSubmit={handleSubmit} className="space-y-6 max-w-md mx-auto bg-white p-8 rounded-lg shadow-md">
      <div>
        <label htmlFor="name" className="block text-sm font-medium text-gray-700">
          Name
        </label>
        <input
          type="text"
          name="name"
          id="name"
          value={formData.name}
          onChange={handleChange}
          className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm py-2 px-3 focus:outline-none focus:ring-teal-500 focus:border-teal-500"
          required
        />
      </div>
      <div>
        <label htmlFor="typeId" className="block text-sm font-medium text-gray-700">
          Тип
        </label>
        <select
          name="typeId"
          id="typeId"
          value={formData.typeId}
          onChange={handleChange}
          className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm py-2 px-3 focus:outline-none focus:ring-teal-500 focus:border-teal-500"
          required
        >
          <option value="">Тип пользователя</option>
          {types.map(type => (
            <option key={type.id} value={type.id}>
              {type.name}
            </option>
          ))}
        </select>
      </div>
      <div>
        <button
          type="submit"
          className="w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-teal-600 hover:bg-teal-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-teal-500 transition-colors duration-200"
        >
          {buttonText}
        </button>
      </div>
    </form>
  );
}
