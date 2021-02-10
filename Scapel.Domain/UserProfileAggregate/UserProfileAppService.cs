using System;
using System.Threading.Tasks;
using AutoMapper;
using Scapel.Domain.Interfaces;
using Scapel.Domain.UserProfileAggregate.Dtos;

namespace Scapel.Domain.UserProfileAggregate
{
    public class UserProfileAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserProfileAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

       
    }
}
