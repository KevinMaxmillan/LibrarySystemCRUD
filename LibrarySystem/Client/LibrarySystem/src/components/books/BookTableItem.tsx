import { BookDto } from "../../models/bookDto"
import Button from "react-bootstrap/esm/Button";
import apiConnector from "../../api/apiConnector";
import { NavLink } from "react-router-dom";

interface Props {
    book: BookDto;
}


export default function BookTableItem({ book }: Props) {
    return (
        <>
            <tr className="center aligned">
                <td data-label="Id">{book.id}</td>
                <td data-label="Title">{book.title}</td>
                <td data-label="Author">{book.author}</td>
                <td data-label="Description">{book.description}</td>
                <td data-label="CreateDate">{book.createDate}</td>
                
                <td data-label="Action">
                    
                    <NavLink to={`/editBook/${book.id}`} className="btn btn-warning">
                        Edit
                    </NavLink>

                    <Button type="button"  onClick={async () => {
                        await apiConnector.deleteBook(book.id!);
                        window.location.reload();
                    }}>
                        Delete
                    </Button>
                </td>
            </tr>
        </>

    )
}