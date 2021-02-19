using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.UserProfileAggregate.Dtos;

namespace Scapel.Domain.UserProfileAggregate
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
      Task <UserProfileDto> GetUserForView(int Id);
      Task CreateOrEditUsers(UserProfileDto input);
      Task<UserProfileDto> GetUserForEdit(UserProfileDto input);
      Task<int> DeleteUser(int Id);
      List<UserProfileDto> GetAllUsers(UserProfileDto input);
      Task<LoginResponseDto> AutheticateUser(LoginRequestDto input);
    }
}
