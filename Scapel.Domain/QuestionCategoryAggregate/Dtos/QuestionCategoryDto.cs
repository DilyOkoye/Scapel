using System;
using Scapel.Domain.Utilities;

namespace Scapel.Domain.QuestionCategoryAggregate.Dtos
{
    public class QuestionCategoryDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public PagedResultDto PagedResultDto { get; set; }
    }
}
