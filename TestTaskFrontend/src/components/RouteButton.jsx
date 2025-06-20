import { Link } from "react-router-dom"

export default function RouteButton({path, text}){
    return (
      <div className="mb-4 flex justify-end">
      <Link
        to={path}
        className="px-4 py-2 bg-teal-600 text-white rounded hover:bg-teal-700 focus:outline-none focus:ring-2 focus:ring-teal-500"
      >
         {text}
      </Link>
    </div>
    );
}