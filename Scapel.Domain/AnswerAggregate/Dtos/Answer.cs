using System;
namespace Scapel.Domain.AnswerAggregate.Dtos
{
    public class Answer
    {
        public int Id { get; set; }
        public int? OptionId { get; set; }
        public int? QuestionId { get; set; }
        public string Answer1 { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
    }
}
