import { RouteObject, createBrowserRouter } from "react-router-dom"
import App from "../App"
import BookForm from "../components/books/BookForm"

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            { path: 'createBook', element: <BookForm key='create' /> },
            { path: 'editBook/:id', element: <BookForm key='edit' /> }
        ]
    }
]

export const router = createBrowserRouter(routes)