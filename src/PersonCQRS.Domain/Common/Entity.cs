using System;

namespace PersonCQRS.Domain.Common
{
    public abstract class Entity
    {
        private int _Id;
        private int? _requestedHashCode;

        public virtual int Id
        {
            get { return _Id; }
            protected set { _Id = value; }
        }

        public bool IsTransient()
        {
            return this.Id == default(Int32);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Entity))
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            Entity item = obj as Entity;
            if (item.IsTransient() || this.IsTransient())
                return false;
            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // Xor
                return _requestedHashCode.Value;
            }
            return base.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            return left.Equals(right);
        }
        
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}