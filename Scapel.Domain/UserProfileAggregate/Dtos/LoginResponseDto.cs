using System;
namespace Scapel.Domain.UserProfileAggregate.Dtos
{
    public class LoginResponseDto
    {
        public int EnforcePassChange { get; set; }
        public string FullName { get; set; }
        public long UserId { get; set; }
        public string EmailAddress { set; get; }
        public string Status { set; get; }
        public int? RoleId { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseText { get; set; }
        public string Url { get; set; }
    }
}
