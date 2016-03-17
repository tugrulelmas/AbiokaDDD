using System;

namespace AbiokaDDD.Infrastructure.Common.Domain
{
    public abstract class IdEntity<IdType> : IEquatable<IdEntity<IdType>>, IIdEntity<IdType>
    {
        public IdType Id { get; set; }

        public override bool Equals(object entity) {
            return entity != null
               && entity is IdEntity<IdType>
               && this == (IdEntity<IdType>)entity;
        }

        public override int GetHashCode() {
            return Id.GetHashCode();
        }

        public static bool operator ==(IdEntity<IdType> entity1, IdEntity<IdType> entity2) {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(IdEntity<IdType> entity1, IdEntity<IdType> entity2) {
            return (!(entity1 == entity2));
        }

        public bool Equals(IdEntity<IdType> other) {
            if (other == null)
            {
                return false;
            }
            return Id.Equals(other.Id);
        }

        public abstract void Validate();
    }
}
