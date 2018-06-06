using MacMickey.DomainModel.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace MacMickey.DomainModel
{
    public class ApplicationRole : IdentityRole, IAuditableEntity
    {

        public ApplicationRole()
        {

        }
        public ApplicationRole(string roleName) : base(roleName)
        {

        }

        public ApplicationRole(string roleName, string description) : base(roleName)
        {
            Description = description;
        }

        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Users { get; set; }
        public virtual ICollection<IdentityRoleClaim<string>> Claims { get; set; }
    }
}
