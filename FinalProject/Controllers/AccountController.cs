using Microsoft.AspNetCore.Mvc;
using FinalProject.Data;
using FinalProject.Dto;
using FinalProject.Service;
using FinalProject.Base;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AccountController
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;


        public AccountController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        // If IsOfferable field is "true", you can see is offerable book in here

        [Authorize]
        [HttpGet("GetOfferableBook")]
        public BaseResponse<IEnumerable<BookDto>> GetAll()
        {
            
            var response = bookService.GetAll();
            response.Response.Where(x => x.IsOfferable == true).ToList();
            return response;
        }

        //Book buying field

        [Authorize]
        [HttpPost("BuyBook")]
        public BaseResponse<BookDto> Create([FromBody] BookDto dto)
        {
            var response = bookService.Insert(dto);
            return response;
        }

    }
}