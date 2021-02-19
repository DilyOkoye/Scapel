using System;
using System.Linq;
using System.Collections.Generic;
using Scapel.Domain.AnswerAggregate;
using Scapel.Domain.AnswerAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Scapel.Domain.VoteAggregate;
using Scapel.Domain.VoteAggregate.Dtos;
using System.Threading.Tasks;
using Scapel.Repository.MappingConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Scapel.Repository.Repositories
{
   

    public class VoteRepository : GenericRepository<Vote>, IVoteRepository
    {
        public VoteRepository(ScapelContext context) : base(context)
        {

        }

        public async Task<VoteDto> GetVoteForView(int Id)
        {
            var votes = await _context.Vote.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (votes != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<VoteDto>(votes);
            }
            return new VoteDto();
        }

        public async Task<VoteDto> GetVoteForEdit(VoteDto input)
        {
            var votes = await _context.Vote.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (votes != null)
            {
                Vote voteDto = MappingProfile.MappingConfigurationSetups().Map<Vote>(input);
                _context.Vote.Update(voteDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<VoteDto>(voteDto);
            }
            return new VoteDto();
        }

        public async Task<int> DeleteVote(int Id)
        {
            var tags = await _context.Vote.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (tags != null)
            {
                _context.Vote.Remove(tags);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }


        public async Task CreateOrEditVote(VoteDto input)
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

        protected virtual async Task Create(VoteDto input)
        {
            Vote voteDto = MappingProfile.MappingConfigurationSetups().Map<Vote>(input);
            _context.Vote.Add(voteDto);
            await _context.SaveChangesAsync();

        }

        protected virtual async Task Update(VoteDto input)
        {
            var votes = await _context.Vote.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (votes != null)
            {
                Vote votesDto = MappingProfile.MappingConfigurationSetups().Map<Vote>(input);
                _context.Vote.Update(votesDto);
                await _context.SaveChangesAsync();
            }

        }

        public List<VoteDto> GetAllVote(VoteDto input)
        {
           
            var query = (from votes in _context.Vote.ToList()
                         join topic in _context.Topic.ToList()
                              on votes.TopicId equals topic.Id
                         select new VoteDto
                         {
                             TopicName = topic.Name,
                             TopicId = topic.Id,
                             UpVoteCount = votes.UpVoteCount,
                             DownVoteCount = votes.DownVoteCount,
                             Id = votes.Id,
                             DateCreated = votes.DateCreated,
                             Status = votes.Status,
                             UserId = votes.UserId

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<VoteDto> ratingDto = MappingProfile.MappingConfigurationSetups().Map<List<VoteDto>>(query);

            //Apply Sort
            ratingDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, ratingDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                ratingDto = ratingDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.TopicName != null && p.TopicName.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.UpVoteCount != null && p.UpVoteCount.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                || p.DownVoteCount != null && p.DownVoteCount.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return ratingDto;

        }


        public List<VoteDto> Sort(string order, string orderDir, List<VoteDto> data)
        {
            // Initialization.
            List<VoteDto> lst = new List<VoteDto>();

            try
            {

                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.UpVoteCount).ToList()
                                                                                                 : data.OrderBy(p => p.UpVoteCount).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DownVoteCount).ToList()
                                                                                                 : data.OrderBy(p => p.DownVoteCount).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DateCreated).ToList()
                                                                                                 : data.OrderBy(p => p.DateCreated).ToList();
                        break;


                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TopicName).ToList()
                                                                                                 : data.OrderBy(p => p.TopicName).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Status).ToList()
                                                                                                 : data.OrderBy(p => p.Status).ToList();
                        break;

                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DateCreated).ToList()
                                                                                                 : data.OrderBy(p => p.DateCreated).ToList();
                        break;

                    default:

                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TopicName).ToList()
                                                                                                 : data.OrderBy(p => p.TopicName).ToList();
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
