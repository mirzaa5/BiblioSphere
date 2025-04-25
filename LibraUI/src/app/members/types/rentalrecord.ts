import { Book } from "../../books/types/book";


export interface Member {
    id: number;
    name: string;
    email: string;
    password: string;
    govtId: string | null;
    phoneNumber: string | null;
    memberShip: string | null;
}

export interface Rental {
    id: number;
    book: Book;
    member: Member;
    rentalDate: string;
    returnDate: string;
    actualReturnDate: string | null;
}