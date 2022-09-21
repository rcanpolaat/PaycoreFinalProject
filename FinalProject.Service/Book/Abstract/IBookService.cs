using FinalProject.Dto;
using FinalProject.Base;
using FinalProject.Data;

namespace FinalProject.Service
{
    public interface IBookService : IBaseService<BookDto, Book>
    {
    }
}