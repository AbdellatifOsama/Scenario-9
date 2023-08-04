import { IBook } from "./ibook";

export interface BooksApiResponse {
  pageIndex: number,
  pageSize: number,
  count: number,
  data: IBook[]
}
