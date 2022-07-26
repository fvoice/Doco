using Doco.Domain.Common;
using Doco.Domain.Enums;

namespace Doco.Domain.Entities
{
    public class User : TraceableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
    }
}
