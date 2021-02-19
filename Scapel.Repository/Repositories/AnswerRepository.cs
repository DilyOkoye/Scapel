using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scapel.Repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Scapel.Repository.Implementations;
using Scapel.Domain.Interfaces;
using AutoMapper;
using Scapel.Repository.MappingConfigurations;
using Microsoft.Extensions.Options;
using Scapel.Domain.Utilities;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Domain.AnswerAggregate;

namespace Scapel.Repository.Repositories
{

    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ScapelContext context) : base(context)
        {

        }
        
      
        public async Task<AnswerDto> GetAnswerForView(int Id)
        {
            var ratings = await _context.Answer.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (ratings != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<AnswerDto>(ratings);
            }
            return new AnswerDto();
        }

        public async Task CreateOrEditAnswer(AnswerDto input)
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

        public async Task<AnswerDto> GetAnswerForEdit(AnswerDto input)
        {
            var users = await _context.Answer.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                Answer answerDto = MappingProfile.MappingConfigurationSetups().Map<Answer>(input);
                _context.Answer.Update(answerDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<AnswerDto>(answerDto);
            }
            return new AnswerDto();
        }

        protected virtual async Task Create(AnswerDto input)
        {
            Answer answerDto = MappingProfile.MappingConfigurationSetups().Map<Answer>(input);

            _context.Answer.Add(answerDto);
            await _context.SaveChangesAsync();

        }


        protected virtual async Task Update(AnswerDto input)
        {
            var users = await _context.UserProfile.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                Answer answerDto = MappingProfile.MappingConfigurationSetups().Map<Answer>(input);
                _context.Answer.Update(answerDto);
                await _context.SaveChangesAsync();
            }

        }
        public async Task<int> DeleteAnswer(int Id)
        {
            var answer = await _context.Answer.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (answer != null)
            {
                _context.Answer.Remove(answer);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }

        public List<AnswerDto> GetAllAnswer(AnswerDto input)
        {
           
            var query = (from answer in _context.Answer.ToList()
                         join question in _context.Question.ToList()
                              on answer.QuestionId equals question.Id
                         join option in _context.Option.ToList()
                         on answer.OptionId equals option.Id
                         select new AnswerDto
                         {
                             Answers = answer.Answers,
                             OptionName = option.Options,
                             QuestionName = question.Questions,
                             Id = answer.Id,
                             DateCreated = answer.DateCreated,
                             Status = answer.Status,
                             UserId = answer.UserId

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<AnswerDto> ratingDto = MappingProfile.MappingConfigurationSetups().Map<List<AnswerDto>>(query);

            //Apply Sort
            ratingDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, ratingDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                ratingDto = ratingDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.Answers != null && p.Answers.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.OptionName != null && p.OptionName.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                || p.QuestionName != null && p.QuestionName.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return ratingDto;

        }



        public List<AnswerDto> Sort(string order, string orderDir, List<AnswerDto> data)
        {
            // Initialization.
            List<AnswerDto> lst = new List<AnswerDto>();

            try
            {

                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Answers).ToList()
                                                                                                 : data.OrderBy(p => p.Answers).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Status).ToList()
                                                                                                 : data.OrderBy(p => p.Status).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.OptionName).ToList()
                                                                                                 : data.OrderBy(p => p.OptionName).ToList();
                        break;

                    case "3":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.OptionName).ToList()
                                                                                                 : data.OrderBy(p => p.OptionName).ToList();
                        break;

                    case "4":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DateCreated).ToList()
                                                                                                 : data.OrderBy(p => p.DateCreated).ToList();
                        break;

                    case "5":

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.QuestionName).ToList()
                                                                                                 : data.OrderBy(p => p.QuestionName).ToList();
                        break;



                    default:

                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Answers).ToList()
                                                                                                 : data.OrderBy(p => p.Answers).ToList();
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
