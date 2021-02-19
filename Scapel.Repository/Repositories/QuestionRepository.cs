using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Domain.QuestionAggregate;
using Scapel.Domain.QuestionAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{


    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ScapelContext context) : base(context)
        {

        }
        public async Task<QuestionDto> GetQuestionForView(int Id)
        {
            var leaderboard = await _context.Question.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (leaderboard != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<QuestionDto>(leaderboard);
            }
            return new QuestionDto();
        }

        public async Task CreateOrEditQuestion(QuestionDto input)
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

        public async Task<QuestionDto> GetQuestionForEdit(QuestionDto input)
        {
            var leaderboard = await _context.Question.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (leaderboard != null)
            {
                Question leaderboardDto = MappingProfile.MappingConfigurationSetups().Map<Question>(input);
                _context.Question.Update(leaderboardDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<QuestionDto>(leaderboardDto);
            }
            return new QuestionDto();
        }

        protected virtual async Task Create(QuestionDto input)
        {
            Question comment = MappingProfile.MappingConfigurationSetups().Map<Question>(input);

            _context.Question.Add(comment);
            await _context.SaveChangesAsync();

        }


        protected virtual async Task Update(QuestionDto input)
        {
            var question = await _context.Question.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (question != null)
            {
                Question questionDto = MappingProfile.MappingConfigurationSetups().Map<Question>(input);
                _context.Question.Update(questionDto);
                await _context.SaveChangesAsync();
            }

        }
        public async Task<int> DeleteQuestion(int Id)
        {
            var question = await _context.Question.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (question != null)
            {
                _context.Question.Remove(question);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }

       

        public List<QuestionDto> GetAllQuestion(QuestionDto input)
        {

            var query = (from question in _context.Question.ToList()
                         join questionCategory in _context.QuestionCategory.ToList()
                              on question.CategoryId equals questionCategory.Id

                        
                         select new QuestionDto
                         {
                             CategoryName = questionCategory.Name,
                             Weight = question.Weight,
                             Id = question.Id,
                             DateCreated = question.DateCreated,
                             Status = question.Status,
                             UserId = question.UserId,
                             Questions = question.Questions

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<QuestionDto> ratingDto = MappingProfile.MappingConfigurationSetups().Map<List<QuestionDto>>(query);

            //Apply Sort
            ratingDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, ratingDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                ratingDto = ratingDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.Questions != null && p.Questions.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.CategoryName != null && p.CategoryName.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                || p.Weight != null && p.Weight.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return ratingDto;

        }



        public List<QuestionDto> Sort(string order, string orderDir, List<QuestionDto> data)
        {
            // Initialization.
            List<QuestionDto> lst = new List<QuestionDto>();

            try
            {

                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Questions).ToList()
                                                                                                 : data.OrderBy(p => p.Questions).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Status).ToList()
                                                                                                 : data.OrderBy(p => p.Status).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Weight).ToList()
                                                                                                 : data.OrderBy(p => p.Weight).ToList();
                        break;

                    case "3":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Id).ToList()
                                                                                                 : data.OrderBy(p => p.Id).ToList();
                        break;

                    case "4":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DateCreated).ToList()
                                                                                                 : data.OrderBy(p => p.DateCreated).ToList();
                        break;

                    case "5":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.CategoryName).ToList()
                                                                                                 : data.OrderBy(p => p.CategoryName).ToList();
                        break;



                    default:

                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Questions).ToList()
                                                                                                 : data.OrderBy(p => p.Questions).ToList();
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
