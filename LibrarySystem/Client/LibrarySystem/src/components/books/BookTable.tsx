import { useEffect, useState } from "react"
import { BookDto } from "../../models/bookDto"
import apiConnector from "../../api/apiConnector";
import BookTableItem from "./BookTableItem";
import { NavLink } from "react-router-dom";

export default function BookTable() {


    // State variable to hold the list of books
    const [books, SetBooks] = useState < BookDto [] > ([]);

    // useEffect hook to fetch data
    useEffect(() => {
        const fetchData = async () => {
            // Fetch books from the API
            const fetchBooks = await apiConnector.getBooks();
            SetBooks(fetchBooks);
        }

        fetchData();

    }, []);// Empty dependency array

    return (
        <>
            <div className="container mt-4">
                <table className="table table-dark table-hover text-center">
                    <thead>
                        <tr>
                            <th scope="col">Id</th>
                            <th scope="col">Title</th>
                            <th scope="col">Author</th>
                            <th scope="col">Description</th>
                            <th scope="col">CreateDate</th>
                            <th scope="col">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {books.length !== 0 && (
                            books.map((book, index) => (
                                <BookTableItem key={index} book={book} />
                            ))
                        )}
                    </tbody>
                </table>

               

                <NavLink to="/createBook" className="btn btn-success float-right">
                    Add New Book
                </NavLink>

            </div>
        </>

    )
}