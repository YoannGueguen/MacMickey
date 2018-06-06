using MacMickey.DomainModel.ModelUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.DomainModel
{
    public abstract class Person : AuditableEntity
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}
