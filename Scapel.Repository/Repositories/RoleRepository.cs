using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.RatingAggregate.Dtos;
using Scapel.Domain.RoleAggregate;
using Scapel.Domain.RoleAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{
    
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ScapelContext context) : base(context)
        {

        }

        public async Task<RoleDto> GetRoleForView(int Id)
        {
            var ratings = await _context.Role.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (ratings != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<RoleDto>(ratings);
            }
            return new RoleDto();
        }

        public async Task<RoleDto> GetRoleForEdit(RoleDto input)
        {
            var users = await _context.Role.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                Role roleDto = MappingProfile.MappingConfigurationSetups().Map<Role>(input);
                _context.Role.Update(roleDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<RoleDto>(roleDto);
            }
            return new RoleDto();
        }

        public async Task<int> DeleteRole(int Id)
        {
            var roles = await _context.Role.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (roles != null)
            {
                _context.Role.Remove(roles);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }

        public async Task CreateOrEditRole(RoleDto input)
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

        protected virtual async Task Create(RoleDto input)
        {
            Role roleDto = MappingProfile.MappingConfigurationSetups().Map<Role>(input);
            _context.Role.Add(roleDto);
            await _context.SaveChangesAsync();

        }

        protected virtual async Task Update(RoleDto input)
        {
            var users = await _context.UserProfile.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                Role roleDto = MappingProfile.MappingConfigurationSetups().Map<Role>(input);
                _context.Role.Update(roleDto);
                await _context.SaveChangesAsync();
            }

        }

        public List<RoleDto> GetAllRole(RoleDto input)
        {
            
            var query = (from rating in _context.Role.ToList()
                         select new RoleDto
                         {                           
                             Name = rating.Name,
                             Id = rating.Id,
                             DateCreated = rating.DateCreated,
                             Status = rating.Status,
                             UserId = rating.UserId

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<RoleDto> roleDto = MappingProfile.MappingConfigurationSetups().Map<List<RoleDto>>(query);

            //Apply Sort
            roleDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, roleDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                roleDto = roleDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.Name != null && p.Name.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return roleDto;

        }


        public List<RoleDto> Sort(string order, string orderDir, List<RoleDto> data)
        {
            // Initialization.
            List<RoleDto> lst = new List<RoleDto>();

            try
            {

                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Name).ToList()
                                                                                                 : data.OrderBy(p => p.Name).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Status).ToList()
                                                                                                 : data.OrderBy(p => p.Status).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DateCreated).ToList()
                                                                                                 : data.OrderBy(p => p.DateCreated).ToList();
                        break;

                  

                    default:

                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Name).ToList()
                                                                                                 : data.OrderBy(p => p.Name).ToList();
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
