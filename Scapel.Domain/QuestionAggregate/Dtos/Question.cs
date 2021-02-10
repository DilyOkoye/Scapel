using System;
namespace Scapel.Domain.QuestionAggregate.Dtos
{
    public class Question
    {
        public int Id { get; set; }
        public int? Weight { get; set; }
        public int? CategoryId { get; set; }
        public string Question1 { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
    }
}
