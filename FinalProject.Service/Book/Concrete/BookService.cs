using AutoMapper;
using NHibernate;
using FinalProject.Dto;
using System.Collections.Generic;
using System;
using FinalProject.Base;
using FinalProject.Data;

namespace FinalProject.Service
{
    public class BookService : BaseService<BookDto, Book>, IBookService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Book> hibernateRepository;

        public BookService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Book>(session);
        }

    }
}