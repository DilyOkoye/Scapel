using System;
using System.Linq;
using System.Collections.Generic;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Domain.AssessmentAggregate;
using Scapel.Domain.AssessmentAggregate.Dtos;
using System.Threading.Tasks;
using Scapel.Repository.MappingConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Scapel.Repository.Repositories
{


    public class AssessmentRepository : GenericRepository<Assessment>, IAssessmentRepository
    {
        public AssessmentRepository(ScapelContext context) : base(context)
        {

        }

        public async Task<AssessmentDto> GetAssessmentForView(int Id)
        {
            var assessment = await _context.Assessment.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (assessment != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<AssessmentDto>(assessment);
            }
            return new AssessmentDto();
        }

        public async Task CreateOrEditAssessment(AssessmentDto input)
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

        public async Task<AssessmentDto> GetAssessmentForEdit(AssessmentDto input)
        {
            var users = await _context.Assessment.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                Assessment answerDto = MappingProfile.MappingConfigurationSetups().Map<Assessment>(input);
                _context.Assessment.Update(answerDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<AssessmentDto>(answerDto);
            }
            return new AssessmentDto();
        }

        protected virtual async Task Create(AssessmentDto input)
        {
            Assessment assessment = MappingProfile.MappingConfigurationSetups().Map<Assessment>(input);

            _context.Assessment.Add(assessment);
            await _context.SaveChangesAsync();

        }


        protected virtual async Task Update(AssessmentDto input)
        {
            var assessment = await _context.Assessment.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (assessment != null)
            {
                Assessment assessmentDto = MappingProfile.MappingConfigurationSetups().Map<Assessment>(input);
                _context.Assessment.Update(assessmentDto);
                await _context.SaveChangesAsync();
            }

        }
        public async Task<int> DeleteAssessment(int Id)
        {
            var assessment = await _context.Assessment.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (assessment != null)
            {
                _context.Assessment.Remove(assessment);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }

     
        public List<AssessmentDto> GetAllAssessment(AssessmentDto input)
        {

            var query = (from assessment in _context.Assessment.ToList()
                         join question in _context.Question.ToList()
                              on assessment.QuestionId equals question.Id
                         join answer in _context.Answer.ToList()
                         on assessment.AnswerId equals answer.Id
                         select new AssessmentDto
                         {
                             AnswerName = answer.Answers,
                             QuestionName = question.Questions,
                             Id = assessment.Id,
                             DateCreated = assessment.DateCreated,
                             Status = assessment.Status,
                             UserId = assessment.UserId

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<AssessmentDto> ratingDto = MappingProfile.MappingConfigurationSetups().Map<List<AssessmentDto>>(query);

            //Apply Sort
            ratingDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, ratingDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                ratingDto = ratingDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.Answers != null && p.Answers.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.AnswerName != null && p.AnswerName.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                || p.QuestionName != null && p.QuestionName.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return ratingDto;

        }



        public List<AssessmentDto> Sort(string order, string orderDir, List<AssessmentDto> data)
        {
            // Initialization.
            List<AssessmentDto> lst = new List<AssessmentDto>();

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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.AnswerName).ToList()
                                                                                                 : data.OrderBy(p => p.AnswerName).ToList();
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
