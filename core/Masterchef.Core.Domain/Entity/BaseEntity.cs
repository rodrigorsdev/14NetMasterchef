using FluentValidation;
using FluentValidation.Results;
using System;

namespace Masterchef.Core.Domain.Entity
{
    public abstract class BaseEntity<TEntity> : AbstractValidator<TEntity> where TEntity : BaseEntity<TEntity>
    {
        public BaseEntity()
        {
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; protected set; }

        public ValidationResult ValidationResult { get; protected set; }
        public DateTime AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public abstract bool IsValid();

        public override bool Equals(object obj)
        {
            var compareTo = obj as BaseEntity<TEntity>;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (ReferenceEquals(null, compareTo))
                return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(BaseEntity<TEntity> a, BaseEntity<TEntity> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity<TEntity> a, BaseEntity<TEntity> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name}[id={Id}]";
        }
    }
}
