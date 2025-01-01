import { AuthorRequest } from "./author-request.model";
import { GenreRequest } from "./genre-request.model";

export interface AddBookRequest{
    bookId: string; // Guid en C# devient string en TypeScript
  title: string; // "required string" est un champ obligatoire en TypeScript
  genres: GenreRequest | null; // Assurez-vous que Genre est aussi défini comme un type
  publicationYear: number;
  isbn?: string; // Champ optionnel en TypeScript
  coverImage: string;
  text?: string; // Champ optionnel
  createdAt: Date;
  isVisible: boolean;
  author: AuthorRequest | null; // Assurez-vous que Author est défini comme un type ou interface
  totalPages: number;
}