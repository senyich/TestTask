import UserList from '../components/UserList';

export default function UserDashboard(){
  return (
    <div>
      <h1 className="text-2xl font-bold text-teal-700 mb-6">Список пользователей</h1>
      <UserList endpoint="get-all-users" />
    </div>
  );
};