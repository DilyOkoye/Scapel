using System;
using System.Collections.Generic;
using System.Text;
using Scapel.Domain.Utilities;

namespace Scapel.Domain.OptionAggregate.Dtos
{
    public class OptionDto
    {
        public int? Id { get; set; }
        public string Options { get; set; }
        public int? QuestionId { get; set; }
        public string OptionType { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public string QuestionName { get; set; }
        public PagedResultDto PagedResultDto { get; set; }
    }
}
