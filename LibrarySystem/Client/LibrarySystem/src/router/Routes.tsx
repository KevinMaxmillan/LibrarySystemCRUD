import { RouteObject, createBrowserRouter } from "react-router-dom"
import App from "../App"
import BookForm from "../components/books/BookForm"


// Defining the routes for the application
export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            { path: 'createBook', element: <BookForm key='create' /> }, // Route for creating a new book
            { path: 'editBook/:id', element: <BookForm key='edit' /> }  // Route for editing an existing book
        ]
    }
]

export const router = createBrowserRouter(routes)