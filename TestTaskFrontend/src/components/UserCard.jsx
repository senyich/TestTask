import { Link } from 'react-router-dom';

export default function UserCard({ user }){
  return (
    <div className="bg-white rounded-lg shadow-md overflow-hidden hover:shadow-lg transition-shadow duration-300">
      <div className="p-6">
        <div className="flex items-center space-x-4">
          <div className="flex-shrink-0">
            <div className="h-12 w-12 rounded-full bg-teal-100 flex items-center justify-center text-teal-600 font-bold">
              {user.name.charAt(0).toUpperCase()}
            </div>
          </div>
          <div className="flex-1 min-w-0">
            <p className="text-lg font-medium text-gray-900 truncate">{user.name}</p>
            <p className="text-sm text-teal-600 truncate">{user.type}</p>
          </div>
        </div>
        <div className="mt-4 flex justify-end space-x-2">
          <Link
            to={`/users/${user.id}`}
            className="px-3 py-1 bg-teal-100 text-teal-700 rounded-md text-sm font-medium hover:bg-teal-200 transition-colors duration-200"
          >
            Показать подробную информацию
          </Link>
          <Link
            to={`/users/edit/${user.id}`}
            className="px-3 py-1 bg-teal-600 text-white rounded-md text-sm font-medium hover:bg-teal-700 transition-colors duration-200"
          >
            Редактировать
          </Link>
        </div>
      </div>
    </div>
  );
};