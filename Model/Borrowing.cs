using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Borrowing : IEquatable<Borrowing>
    {
        public string Id { get; set; }
        public Book Book { get; set; }
        public Contact Owner { get; set; }
        public DateTime BorrowedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }

        public bool Equals(Borrowing? other)
            => Id == other.Id;

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Borrowing);
        }

        public override int GetHashCode()
            => Id.GetHashCode();
    }
}
