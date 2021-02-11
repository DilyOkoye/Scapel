using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.UserProfileAggregate.Dtos;

namespace Scapel.Domain.UserProfileAggregate
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
      Task <UserProfile> GetUserForView(int Id);
      Task CreateOrEditUsers(UserProfileDto input);
      Task<UserProfile> GetUserForEdit(UserProfileDto input);
      Task<int> DeleteUser(int Id);
      List<UserProfileDto> GetAllUsers(UserProfileDto input);
      Task<LoginResponseDto> AutheticateUser(LoginRequestDto input);
    }
}
