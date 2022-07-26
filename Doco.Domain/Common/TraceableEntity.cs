using System;

namespace Doco.Domain.Common
{
    public abstract class TraceableEntity : BaseEntity
    {
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}