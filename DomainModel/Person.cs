using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.DomainModel.Persons
{
    public abstract class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}
