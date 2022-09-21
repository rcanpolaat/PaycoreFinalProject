using AutoMapper;
using FinalProject.Base;
using FinalProject.Dto;
using FinalProject.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;


        public UserController(IUserService userService, IMapper mapper) 
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        
        [HttpPost("Signin")]
        public BaseResponse<UserDto> Create([FromBody] UserDto dto)
        {
            var response = userService.Insert(dto);
            return response;
        }
    }
}