import { NavLink, useNavigate, useParams } from "react-router-dom";
import { BookDto } from "../../models/bookDto";
import { ChangeEvent, useEffect, useState } from "react";
import apiConnector from "../../api/apiConnector";

export default function BookForm() {

    const {id} = useParams();
    const navigate = useNavigate();

    //variable to hold book data
    const [book, setBook] = useState<BookDto>({
        id: undefined,
        title: '',
        author: '',
        description: '',
        createDate: undefined
    }); 

    // useEffect hook to fetch the book details
    useEffect(() => {
        if (id) {
            apiConnector.getBookById(id).then(book => setBook(book!))
        }
    }, [id]);


    // Function to handle form submission
    function handleSubmit() {
        if (!book.id) {
            apiConnector.createBook(book).then(() => navigate('/'));
        } else {
            apiConnector.editBook(book).then(() => navigate('/'));
        }
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setBook({ ...book, [name]: value });
    }

    return (
        <div className="container mt-4 p-4 bg-dark text-white rounded">
            <form onSubmit={handleSubmit} autoComplete="off" className="form">
                <div className="form-group">
                    <label htmlFor="title">Title</label>
                    <input
                        type="text"
                        className="form-control"
                        id="title"
                        name="title"
                        placeholder="Title"
                        value={book.title}
                        onChange={handleInputChange}
                    />
                </div>

                <div className="form-group">
                    <label htmlFor="author">Author</label>
                    <input
                        type="text"
                        className="form-control"
                        id="author"
                        name="author"
                        placeholder="author"
                        value={book.author}
                        onChange={handleInputChange}
                    />
                </div>

                <div className="form-group">
                    <label htmlFor="description">Description</label>
                    <textarea
                        className="form-control"
                        id="description"
                        name="description"
                        placeholder="Description"
                        value={book.description}
                        onChange={handleInputChange}
                    ></textarea>
                </div>

               

                <div className="form-group text-right">
                    <button type="submit" className="btn btn-success mr-2">
                        Submit
                    </button>
                    <NavLink to="/" className="btn btn-secondary">
                        Cancel
                    </NavLink>
                </div>
            </form>
        </div>

    )
}