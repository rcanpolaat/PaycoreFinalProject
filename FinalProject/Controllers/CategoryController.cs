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

    public class CategoryController : BaseController<CategoryDto, Category>
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;


        public CategoryController(ICategoryService categoryService, IMapper mapper) : base(categoryService, mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

    }
}