using Labb_LibraryApi.Data;
using Labb_LibraryApi.Models.DTOs;
using Labb_LibraryApi.Models;
using System.Net;
using Labb_LibraryApi.Repositories;
using AutoMapper;

namespace Labb_LibraryApi.EndPoints
{
    public static class BookEndpoints
    {
        public static void ConfigurationBookEndPoints(this WebApplication app)
        {
            app.MapGet("/api/books", GetAllBooks).WithName("GetBooks").Produces<APIResponse>();
            app.MapGet("/api/books/{id:int}", GetBookById).WithName("GetBookById").Produces<APIResponse>(404);
            app.MapGet("/api/books/search/{word}", GetBookByWord).WithName("GetBookByWord").Produces<APIResponse>(200);
            app.MapGet("/api/books/available", GetAvailableBooks).WithName("GetAvailableBooks").Produces<APIResponse>();
            app.MapPost("/api/book", CreateBook).WithName("CreateBook").Accepts<CreateBookDTO>("application/json").Produces<APIResponse>(201).Produces(400);
            app.MapPut("/api/book", UpdateBook).WithName("UpdateBook").Accepts<UpdateBookDTO>("application/json").Produces<APIResponse>(200).Produces(400);
            app.MapDelete("/api/book/{id:int}", DeleteBook).WithName("DeleteBook").Produces<APIResponse>(204).Produces(404);
        }

        private async static Task<IResult> GetAllBooks(IBookRepository _bookRepository, IMapper _mapper)
        {
            APIResponse response = new APIResponse();

            var books = await _bookRepository.GetAllBooksAsync();

            var bookDTOS = _mapper.Map<List<BookDTO>>(books);
            response.Result = bookDTOS;
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private async static Task<IResult> GetBookById(IBookRepository _bookRepository, IMapper _mapper, int id)
        {
            APIResponse response = new APIResponse();
            var book = await _bookRepository.GetBookAsync(id);

            if (book != null)
            {
                var bookDTO = _mapper.Map<BookDTO>(book);

                response.Result = bookDTO;
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;

                return Results.Ok(response);
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage.Add($"Book with ID {id} not found");
                response.StatusCode = HttpStatusCode.NotFound;

                return Results.NotFound(response);
            }
        }
        private async static Task<IResult> GetBookByWord(IBookRepository _bookRepository, IMapper _mapper, string word)
        {
            APIResponse response = new APIResponse();

            var books = await _bookRepository.GetBookAsync(word);

            if (books.Any())
            {
                var bookDtos = _mapper.Map<List<BookDTO>>(books);

                response.Result = bookDtos;
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;

                return Results.Ok(response);
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage.Add($"No books found with word '{word}' in the title");
                response.StatusCode = HttpStatusCode.NotFound;

                return Results.NotFound(response);
            }

        }
        private async static Task<IResult> GetAvailableBooks(IBookRepository _bookRepository, IMapper _mapper)
        {
            APIResponse response = new APIResponse();

            var books = await _bookRepository.GetAvailableBooksAsync();

            var bookDTOS = _mapper.Map<List<BookDTO>>(books);
            response.Result = bookDTOS;
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private async static Task<IResult> CreateBook(IBookRepository _bookRepository, IMapper _mapper, CreateBookDTO book_c_dto)
        {
            APIResponse response = new()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest
            };

            if (string.IsNullOrEmpty(book_c_dto.Title) || string.IsNullOrEmpty(book_c_dto.Author))
            {
                response.IsSuccess = false;
                response.ErrorMessage.Add("Title and Author are required fields.");
                response.StatusCode = HttpStatusCode.BadRequest;
                return Results.BadRequest(response);
            }

            if (!Enum.TryParse(typeof(BookGenre), book_c_dto.Genre, true, out var genre))
            {
                response.IsSuccess = false;
                response.ErrorMessage.Add("Invalid genre.");
                response.StatusCode = HttpStatusCode.BadRequest;
                return Results.BadRequest(response);
            }

            var newBook = _mapper.Map<Book>(book_c_dto);
            newBook.Genre = (BookGenre)genre;

            await _bookRepository.CreateBookAsync(newBook);

            response.Result = newBook;
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.Created;

            return Results.Created($"/api/books/{newBook.BookID}", response);
        }

        private async static Task<IResult> UpdateBook(IBookRepository _bookRepository, IMapper _mapper, UpdateBookDTO book_u_dto)
        {
            APIResponse response = new()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest
            };

            await _bookRepository.UpdateBookAsync(_mapper.Map<Book>(book_u_dto));
            await _bookRepository.SaveAsync();

            response.Result = _mapper.Map<UpdateBookDTO>(await _bookRepository.GetBookAsync(book_u_dto.BookID));
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return Results.Ok(response);

        }

        private async static Task<IResult> DeleteBook(IBookRepository _bookRepository, int id)
        {
            APIResponse response = new()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest
            };

            var bookFromDb = await _bookRepository.GetBookAsync(id);

            if (bookFromDb != null)
            {
                await _bookRepository.RemoveBookAsync(bookFromDb);

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.NoContent;
                return Results.Ok(response);
            }
            else
            {
                response.ErrorMessage.Add("Invalid ID");
                response.StatusCode = HttpStatusCode.NotFound;
                return Results.NotFound(response);
            }
        }
    }
}
