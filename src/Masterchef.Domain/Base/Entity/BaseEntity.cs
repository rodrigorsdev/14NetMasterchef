using System;

namespace Masterchef.Domain.Base.Entity
{
    public abstract class BaseEntity
    {
        public DateTime AdditionDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}