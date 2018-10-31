using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Savarankiškas_darbas
{
    abstract class AnimalMarked : Animal
    {
        public int ChipId { get; set; }
        public AnimalMarked(string name, int chipId, string breed, string owner, string phone,
        DateTime vaccinationDate) : base(name, breed, owner, phone, vaccinationDate)
        {
            ChipId = chipId;
        }
        abstract public override bool isVaccinationExpired();

        public override bool Equals(object obj)
        {
            return this.Equals(obj as AnimalMarked);
        }
        public bool Equals(AnimalMarked animal)
        {
            if (Object.ReferenceEquals(animal, null))
            {
                return false;
            }
            if (this.GetType() != animal.GetType())
            {
                return false;
            }
            return (Owner == animal.Owner) && (Name == animal.Name);
        }
        public override int GetHashCode()
        {
            return Owner.GetHashCode() ^ Name.GetHashCode();
        }
        public static bool operator ==(AnimalMarked lhs, AnimalMarked rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }
                return false;
            }
            return lhs.Equals(rhs);
        }
        public static bool operator !=(AnimalMarked lhs, AnimalMarked rhs)
        {
            return !(lhs == rhs);
        }
        public static bool operator <=(AnimalMarked lhs, AnimalMarked rhs)
        {
            return lhs.Name.CompareTo(rhs.Name) < 0 || lhs.Name.CompareTo(rhs.Name) == 0 && lhs.Owner.CompareTo(rhs.Owner) < 0;
        }
        public static bool operator >=(AnimalMarked lhs, AnimalMarked rhs)
        {
            return lhs.Name.CompareTo(rhs.Name) > 0 || lhs.Name.CompareTo(rhs.Name) == 0 && lhs.Owner.CompareTo(rhs.Owner) > 0;
        }







    }
}
