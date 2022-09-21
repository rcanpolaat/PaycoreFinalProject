using Microsoft.AspNetCore.Mvc;
using FinalProject.Data;
using FinalProject.Dto;
using FinalProject.Service;
using FinalProject.Base;
using AutoMapper;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookController : BaseController<BookDto, Book>
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;


        public BookController(IBookService bookService, IMapper mapper) : base(bookService, mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

    }
}