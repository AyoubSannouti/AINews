using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Authentication.Queries.Me
{
    public class MeDto
    {
        public string Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
