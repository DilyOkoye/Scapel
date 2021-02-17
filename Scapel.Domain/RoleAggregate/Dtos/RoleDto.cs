using System;
using Scapel.Domain.Utilities;

namespace Scapel.Domain.RoleAggregate.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public PagedResultDto PagedResultDto { get; set; }
    }
}
