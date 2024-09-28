import axios, {  AxiosResponse } from "axios";
import { BookDto } from "../models/bookDto";
import { GetBookResponse } from "../models/getBookResponse";
import { GetBookByIdResponse } from "../models/getBookByIdResponse";
import { API_BASE_URL } from "../../config.ts";


// API connector methods for API interactions
const apiConnector = {


    // Fetch all books
    getBooks: async (): Promise<BookDto[]> => {
        try {
            const response: AxiosResponse<GetBookResponse> = await axios.get(`${API_BASE_URL}/Books`);

            const books = response.data.bookDtos.map(book => ({
                ...book, createDate: book.createDate?.slice(0, 10) ?? ""
            }))
            return books;
        }catch (error) {
            console.log('Error fetching books:', error);
            throw error;
        }
    },

    // Create a new book
    createBook: async (book: BookDto): Promise<void> => {
        try {
            await axios.post<number>(`${API_BASE_URL}/Books`, book);

        } catch (error) {
            console.log(error);
            throw error;
        }

    },


    // Edit an existing book
    editBook: async (book: BookDto): Promise<void> => {
       
        try {
            await axios.put<number>(`${API_BASE_URL}/Books/${book.id}`, book);

        } catch (error) {
            console.log(error);
            throw error;
        }

    },


    // Delete a book by Id
    deleteBook: async (bookId: string): Promise<void> => {
        try {
            await axios.delete<number>(`${API_BASE_URL}/Books/${bookId}`);

        } catch (error) {
            console.log(error);
            throw error;
        }

    },


    // Fetch a single book by ID
    getBookById: async (bookId: string): Promise<BookDto | undefined> => {

        
        try {
            const response = await axios.get<GetBookByIdResponse>(`${API_BASE_URL}/Books/${bookId}`);
            return response.data.bookDtos

        } catch (error) {
            console.log(error);
            throw error;
        }

    }
    



}

export default apiConnector;