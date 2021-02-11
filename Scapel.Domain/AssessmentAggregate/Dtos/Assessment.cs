using System;
namespace Scapel.Domain.AssessmentAggregate.Dtos
{
    public partial class Assessment
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public string Answers { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
    }
}
