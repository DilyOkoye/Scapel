using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scapel.Domain.Interfaces;
using Scapel.Domain.VideoCategoryAggregate.Dtos;

namespace Scapel.Domain.VideoCategoryAggregate
{
    
    public interface IVideoCategoryRepository : IGenericRepository<VideoCategory>
    {

        Task<VideoCategoryDto> GetVideoCategoryForView(int Id);
        Task CreateOrEditVideoCategory(VideoCategoryDto input);
        Task<VideoCategoryDto> GetVideoCategoryForEdit(VideoCategoryDto input);
        Task<int> DeleteVideoCategory(int Id);
        List<VideoCategoryDto> GetAllVideoCategory(VideoCategoryDto input);
    }
}
