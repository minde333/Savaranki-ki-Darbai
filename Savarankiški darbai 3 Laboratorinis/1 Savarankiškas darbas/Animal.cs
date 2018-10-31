using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Savarankiškas_darbas
{
    abstract class Animal
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Owner { get; set; }
        public string Phone { get; set; }
        public DateTime VaccinationDate { get; set; }
        public Animal(string name, string breed, string owner, string phone,
       DateTime vaccinationDate)
        {
            Name = name;
            Breed = breed;
            Owner = owner;
            Phone = phone;
            VaccinationDate = vaccinationDate;
        }
        //metodas paskelbtas abstrakčiu. Tai reiškia, jog vaikų klasės privalės ji realizuoti
        abstract public bool isVaccinationExpired();
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Animal);
        }
        public bool Equals(Animal animal)
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
        public static bool operator ==(Animal lhs, Animal rhs)
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
        public static bool operator !=(Animal lhs, Animal rhs)
        {
            return !(lhs == rhs);
        }
        public static bool operator <=(Animal lhs, Animal rhs)
        {
            return lhs.Name.CompareTo(rhs.Name) < 0 || lhs.Name.CompareTo(rhs.Name) == 0 && lhs.Owner.CompareTo(rhs.Owner) < 0;
        }
        public static bool operator >=(Animal lhs, Animal rhs)
        {
            return lhs.Name.CompareTo(rhs.Name) > 0 || lhs.Name.CompareTo(rhs.Name) == 0 && lhs.Owner.CompareTo(rhs.Owner) > 0;
        }
    }
}