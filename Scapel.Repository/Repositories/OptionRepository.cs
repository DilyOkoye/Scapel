using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.OptionAggregate;
using Scapel.Domain.OptionAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{

    public class OptionRepository : GenericRepository<Option>, IOptionRepository
    {
        public OptionRepository(ScapelContext context) : base(context)
        {

        }
        public async Task<OptionDto> GetOptionForView(int Id)
        {
            var option = await _context.Option.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (option != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<OptionDto>(option);
            }
            return new OptionDto();
        }

        public async Task CreateOrEditOption(OptionDto input)
        {
            if (input.Id == 0)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        public async Task<OptionDto> GetOptionForEdit(OptionDto input)
        {
            var option = await _context.Option.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (option != null)
            {
                Option optionDto = MappingProfile.MappingConfigurationSetups().Map<Option>(input);
                _context.Option.Update(optionDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<OptionDto>(optionDto);
            }
            return new OptionDto();
        }

        protected virtual async Task Create(OptionDto input)
        {
            Option comment = MappingProfile.MappingConfigurationSetups().Map<Option>(input);

            _context.Option.Add(comment);
            await _context.SaveChangesAsync();

        }


        protected virtual async Task Update(OptionDto input)
        {
            var option = await _context.Option.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (option != null)
            {
                Option optionDto = MappingProfile.MappingConfigurationSetups().Map<Option>(input);
                _context.Option.Update(optionDto);
                await _context.SaveChangesAsync();
            }

        }
        public async Task<int> DeleteOption(int Id)
        {
            var leaderboard = await _context.Option.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (leaderboard != null)
            {
                _context.Option.Remove(leaderboard);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }

     

        public List<OptionDto> GetAllOption(OptionDto input)
        {

            var query = (from option in _context.Option.ToList()
                         join question in _context.Question.ToList()
                              on option.QuestionId equals question.Id

                         select new OptionDto
                         {
                             QuestionName = question.Questions,
                             Id = option.Id,
                             DateCreated = option.DateCreated,
                             Status = option.Status,
                             UserId = option.UserId,
                             Options = option.Options

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<OptionDto> ratingDto = MappingProfile.MappingConfigurationSetups().Map<List<OptionDto>>(query);

            //Apply Sort
            ratingDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, ratingDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                ratingDto = ratingDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.QuestionName != null && p.QuestionName.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.Options != null && p.Options.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return ratingDto;

        }



        public List<OptionDto> Sort(string order, string orderDir, List<OptionDto> data)
        {
            // Initialization.
            List<OptionDto> lst = new List<OptionDto>();

            try
            {

                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Options).ToList()
                                                                                                 : data.OrderBy(p => p.Options).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Status).ToList()
                                                                                                 : data.OrderBy(p => p.Status).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.QuestionName).ToList()
                                                                                                 : data.OrderBy(p => p.QuestionName).ToList();
                        break;

                    case "3":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Id).ToList()
                                                                                                 : data.OrderBy(p => p.Id).ToList();
                        break;

                    case "4":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DateCreated).ToList()
                                                                                                 : data.OrderBy(p => p.DateCreated).ToList();
                        break;

                 

                    default:

                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Options).ToList()
                                                                                                 : data.OrderBy(p => p.Options).ToList();
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
