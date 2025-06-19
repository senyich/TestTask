import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

toast.configure({
  position: "top-right",
  autoClose: 3000,
  hideProgressBar: false,
  closeOnClick: true,
  pauseOnHover: true,
  draggable: true,
  progress: undefined,
  theme: "colored"
});

export const showSuccessToast = (message) => {
  toast.success(message, {
    className: 'bg-teal-600'
  });
};

export const showErrorToast = (message) => {
  toast.error(message);
};