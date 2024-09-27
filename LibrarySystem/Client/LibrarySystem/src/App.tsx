
import { Outlet, useLocation } from 'react-router-dom'
import './App.css'
import BookTable from './components/books/BookTable'

function App() {

    const location = useLocation();

  return (
      <>
          <h1 className="text-center">
            Library System
          </h1>

          {location.pathname === '/' ? <BookTable/> : (
              <div className="container mt-4">
                  <Outlet/>
              </div>
          ) }
    </>
  )
}

export default App
