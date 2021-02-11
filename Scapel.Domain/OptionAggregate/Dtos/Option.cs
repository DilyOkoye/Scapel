using System;
namespace Scapel.Domain.OptionAggregate.Dtos
{
    public class Option
    {
        public int Id { get; set; }
        public string Option1 { get; set; }
        public int? QuestionId { get; set; }
        public string OptionType { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
    }
}
