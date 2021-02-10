using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scapel.Domain.UserProfileAggregate;
using Scapel.Domain.UserProfileAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Scapel.Repository.Implementations;
using Scapel.Domain.Interfaces;
using AutoMapper;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {

        public UserProfileRepository(ScapelContext context) : base(context)
        {
        }

        public async Task<UserProfile> GetUserForView(int Id)
        {
            return await _context.UserProfile.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<UserProfile> GetUserForEdit(UserProfileDto input)
        {
            var users = await _context.UserProfile.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                UserProfile userDto = MappingProfile.MappingConfigurationSetups().Map<UserProfile>(input);
                _context.UserProfile.Update(userDto);
                await _context.SaveChangesAsync();
                return userDto;
            }
            return new UserProfile();
        }


        public async Task<int> DeleteUser(int Id)
        {
            var users = await _context.UserProfile.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (users != null)
            {
                _context.UserProfile.Remove(users);
                return await _context.SaveChangesAsync();
                 
            }
            return 0;
        }


        public async Task CreateOrEditUsers(UserProfileDto input)
        {
            if (input.Id == null || input.Id == 0)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
           
        }

        protected virtual async Task Create(UserProfileDto input)
        {
            UserProfile userDto = MappingProfile.MappingConfigurationSetups().Map<UserProfile>(input);
            _context.UserProfile.Add(userDto);
           await  _context.SaveChangesAsync();
           
        }

        protected virtual async Task Update(UserProfileDto input)
        {
            var users = await _context.UserProfile.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                UserProfile userDto = MappingProfile.MappingConfigurationSetups().Map<UserProfile>(input);
                _context.UserProfile.Update(userDto);
                await _context.SaveChangesAsync();
            }
           
        }


        public List<UserProfileDto> GetAllUsers(UserProfileDto input)
        {
           var allUsers = _context.UserProfile.ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<UserProfileDto> userDto = MappingProfile.MappingConfigurationSetups().Map<List<UserProfileDto>>(allUsers);

            //Apply Sort
            userDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, userDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                userDto = userDto.Where(p => p.UserName != null && p.UserName.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.EmailAddress != null && p.EmailAddress.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.FirstName != null && p.FirstName.ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.LastName != null && p.LastName.ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                || p.MiddleName != null && p.MiddleName.ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.PhoneNumber != null && p.PhoneNumber.ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return  userDto;

        }


        public List<UserProfileDto> Sort(string order, string orderDir, List<UserProfileDto> data)
        {
            // Initialization.
            List<UserProfileDto> lst = new List<UserProfileDto>();

            try
            {

                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.UserName).ToList()
                                                                                                 : data.OrderBy(p => p.UserName).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EmailAddress).ToList()
                                                                                                 : data.OrderBy(p => p.EmailAddress).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FirstName).ToList()
                                                                                                 : data.OrderBy(p => p.FirstName).ToList();
                        break;


                    case "3":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.LastName).ToList()
                                                                                                 : data.OrderBy(p => p.LastName).ToList();
                        break;

                    case "4":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.MiddleName).ToList()
                                                                                                 : data.OrderBy(p => p.MiddleName).ToList();
                        break;

                   

                    default:

                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.PhoneNumber).ToList()
                                                                                                 : data.OrderBy(p => p.PhoneNumber).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {


            }

            // info.
            return lst;
        }


    }
}
