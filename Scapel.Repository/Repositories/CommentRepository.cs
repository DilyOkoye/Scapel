using System;
using System.Collections.Generic;
using System.Linq;
using Scapel.Domain.CommentAggregate;
using Scapel.Domain.CommentAggregate.Dtos;
using Scapel.Repository.DatabaseContext;
using Scapel.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Scapel.Repository.MappingConfigurations;

namespace Scapel.Repository.Repositories
{


    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ScapelContext context) : base(context)
        {

        }


        public async Task<CommentDto> GetCommentForView(int Id)
        {
            var comment = await _context.Comment.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (comment != null)
            {
                return MappingProfile.MappingConfigurationSetups().Map<CommentDto>(comment);
            }
            return new CommentDto();
        }

        public async Task CreateOrEditComment(CommentDto input)
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

        public async Task<CommentDto> GetCommentForEdit(CommentDto input)
        {
            var users = await _context.Comment.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (users != null)
            {
                Comment commentDto = MappingProfile.MappingConfigurationSetups().Map<Comment>(input);
                _context.Comment.Update(commentDto);
                await _context.SaveChangesAsync();

                return MappingProfile.MappingConfigurationSetups().Map<CommentDto>(commentDto);
            }
            return new CommentDto();
        }

        protected virtual async Task Create(CommentDto input)
        {
            Comment comment = MappingProfile.MappingConfigurationSetups().Map<Comment>(input);

            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();

        }


        protected virtual async Task Update(CommentDto input)
        {
            var comment = await _context.Comment.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            if (comment != null)
            {
                Comment commentDto = MappingProfile.MappingConfigurationSetups().Map<Comment>(input);
                _context.Comment.Update(commentDto);
                await _context.SaveChangesAsync();
            }

        }
        public async Task<int> DeleteComment(int Id)
        {
            var comment = await _context.Comment.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (comment != null)
            {
                _context.Comment.Remove(comment);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }       

        public List<CommentDto> GetAllComment(CommentDto input)
        {

            var query = (from comment in _context.Comment.ToList()
                         join topic in _context.Topic.ToList()
                              on comment.TopicId equals topic.Id
                         
                         select new CommentDto
                         {
                             TopicName = topic.Name,
                             ContentType = comment.ContentType,
                             Id = comment.Id,
                             DateCreated = comment.DateCreated,
                             Status = comment.Status,
                             UserId = comment.UserId,
                             Content =comment.Content

                         }).ToList().Skip((input.PagedResultDto.Page - 1) * input.PagedResultDto.SkipCount).Take(input.PagedResultDto.MaxResultCount);

            // Map Records
            List<CommentDto> ratingDto = MappingProfile.MappingConfigurationSetups().Map<List<CommentDto>>(query);

            //Apply Sort
            ratingDto = Sort(input.PagedResultDto.Sort, input.PagedResultDto.SortOrder, ratingDto);

            // Apply search
            if (!string.IsNullOrEmpty(input.PagedResultDto.Search))
            {
                ratingDto = ratingDto.Where(p => p.Status != null && p.Status.ToLower().ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.TopicName != null && p.TopicName.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.DateCreated != null && p.DateCreated.ToString().ToLower().Contains(input.PagedResultDto.Search.ToLower())
                || p.ContentType != null && p.ContentType.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                || p.Content != null && p.Content.ToString().ToLower().ToString().Contains(input.PagedResultDto.Search.ToLower())
                ).ToList();

            }
            return ratingDto;

        }



        public List<CommentDto> Sort(string order, string orderDir, List<CommentDto> data)
        {
            // Initialization.
            List<CommentDto> lst = new List<CommentDto>();

            try
            {

                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TopicName).ToList()
                                                                                                 : data.OrderBy(p => p.TopicName).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Status).ToList()
                                                                                                 : data.OrderBy(p => p.Status).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ContentType).ToList()
                                                                                                 : data.OrderBy(p => p.ContentType).ToList();
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

                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Content).ToList()
                                                                                                 : data.OrderBy(p => p.Content).ToList();
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
