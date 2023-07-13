using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_Dictionary
{
    internal class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public Person(long Id, string Name, string Gender) 
        {
            this.Id = Id;
            this.Name = Name;
            this.Gender = Gender;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nGender: {Gender}";
        }
    }
}
