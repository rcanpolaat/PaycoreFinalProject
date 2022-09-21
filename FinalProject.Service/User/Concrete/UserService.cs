using AutoMapper;
using NHibernate;
using FinalProject.Dto;
using System.Collections.Generic;
using System;
using FinalProject.Base;
using FinalProject.Data;

namespace FinalProject.Service
{
    public class UserService : BaseService<UserDto, User>, IUserService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<User> hibernateRepository;

        public UserService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<User>(session);
        }

    }
}