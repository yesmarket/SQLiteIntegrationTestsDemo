using System.Runtime.Serialization;

namespace ChannelManagement.DataAccess.Contracts.Model
{
    [DataContract]
    public abstract class BaseEntity<T>
    {
        [DataMember]
        public virtual T Id { get; set; }

        public static bool operator ==(BaseEntity<T> a, BaseEntity<T> b)
        {
            return ReferenceEquals(null, a) ? ReferenceEquals(null, b) : a.Equals(b);
        }

        public static bool operator !=(BaseEntity<T> a, BaseEntity<T> b)
        {
            return ReferenceEquals(null, a) ? !ReferenceEquals(null, b) : !a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            var other = obj as BaseEntity<T>;
            if (other == null)
            {
                return false;
            }

            var otherIsTransient = Equals(other.Id, default(T));
            var thisIsTransient = Equals(Id, default(T));
            if (otherIsTransient && thisIsTransient)
            {
                return ReferenceEquals(other, this);
            }

            return (ReferenceEquals(this, other) || Equals(other.Id, Id));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                return hash;
            }
        }
    }
}