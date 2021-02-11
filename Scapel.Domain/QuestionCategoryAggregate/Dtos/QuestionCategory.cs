using System;
namespace Scapel.Domain.QuestionCategoryAggregate.Dtos
{
    public class QuestionCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
    }
}
