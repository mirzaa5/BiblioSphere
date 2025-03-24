export interface Book{
    id : number,
    title : string,
    isbn : string,
    author : Author,
    category : number,
    isavailable : boolean,
    coverImageUrl? : string
}

export interface Author {
    id: number,
    name : string
}