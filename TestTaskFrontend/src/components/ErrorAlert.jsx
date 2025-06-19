
export default function ErrorAlert({ message }){
  return (
    <div className="bg-red-100 border-l-4 border-red-500 text-red-700 p-4 rounded-md" role="alert">
      <p className="font-bold">Ошибка</p>
      <p>{message}</p>
    </div>
  );
};