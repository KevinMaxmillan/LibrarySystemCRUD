import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import { RouterProvider } from 'react-router-dom';
import { router } from './router/Routes';


// Rendering the React application
createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <RouterProvider router={router}/>
  </StrictMode>,
)
