using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.QuestionCategoryAggregate;
using Scapel.Domain.QuestionCategoryAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{


    public class QuestionCategoryRepository : GenericRepository<QuestionCategory>, IQuestionCategoryRepository
    {
        public QuestionCategoryRepository(ScapelContext context) : base(context)
        {

        }

        public async Task<QuestionCategoryDto> GetQuestionCategoryForView(int Id)
        {
            var questionCategory = await _context.QuestionCategory.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (questionCategory != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<QuestionCategoryDto>(questionCategory);
            }
            return new QuestionCategoryDto();
        }

        public async Task<QuestionCategoryDto> GetQuestionCategoryForEdit(QuestionCategoryDto input)
        {
            var questionCategory = await _context.QuestionCategory.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (questionCategory != null)
            {
                QuestionCategory questionCategoryDto = MappingProfile.MappingConfigurationSetups().Map<QuestionCategory>(input);
                _context.QuestionCategory.Update(questionCategoryDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<QuestionCategoryDto>(questionCategoryDto);
            }
            return new QuestionCategoryDto();
        }

        public async Task<int> DeleteQuestionCategory(int Id)
        {
            var questionCategory = await _context.QuestionCategory.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (questionCategory != null)
            {
                _context.QuestionCategory.Remove(questionCategory);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }

        public async Task CreateOrEditQuestionCategory(QuestionCategoryDto input)
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

        protected virtual async Task Create(QuestionCategoryDto input)
        {
            QuestionCategory questionCategoryDto = MappingProfile.MappingConfigurationSetups().Map<QuestionCategory>(input);
            _context.QuestionCategory.Add(questionCategoryDto);
            await _context.SaveChangesAsync();

        }

        protected virtual async Task Update(QuestionCategoryDto input)
        {
            var questionCategory = await _context.QuestionCategory.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (questionCategory != null)
            {
                QuestionCategory questionCategoryDto = MappingProfile.MappingConfigurationSetups().Map<QuestionCategory>(input);
                _context.QuestionCategory.Update(questionCategoryDto);
                await _context.SaveChangesAsync();
            }

        }

        public List<QuestionCategoryDto> GetAllQuestionCategory(QuestionCategoryDto input)
        {
           
            var query = (from questionCategory in _context.QuestionCategory.ToList()
                         select new QuestionCategoryDto
                         {
                             Name = questionCategory.Name,
                             Id = questionCategory.Id,
                             DateCreated = questionCategory.DateCreated,
                             Status = questionCategory.Status,
                             UserId = questionCategory.UserId

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<QuestionCategoryDto> roleDto = MappingProfile.MappingConfigurationSetups().Map<List<QuestionCategoryDto>>(query);

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


        public List<QuestionCategoryDto> Sort(string order, string orderDir, List<QuestionCategoryDto> data)
        {
            // Initialization.
            List<QuestionCategoryDto> lst = new List<QuestionCategoryDto>();

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
