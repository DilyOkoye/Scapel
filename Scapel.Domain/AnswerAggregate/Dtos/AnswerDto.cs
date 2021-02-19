using System;
using System.Collections.Generic;
using System.Text;
using Scapel.Domain.Utilities;

namespace Scapel.Domain.AnswerAggregate.Dtos
{
    public class AnswerDto
    {
        public int? Id { get; set; }
        public int? OptionId { get; set; }
        public int? QuestionId { get; set; }
        public string Answers { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public string OptionName { get; set; }
        public string QuestionName { get; set; }
        public PagedResultDto PagedResultDto { get; set; }

    }
}
