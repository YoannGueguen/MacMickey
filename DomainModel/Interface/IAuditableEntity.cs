using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.DomainModel.Interface
{
        public interface IAuditableEntity
        {
            string CreatedBy { get; set; }
            string UpdatedBy { get; set; }
            DateTime CreatedDate { get; set; }
            DateTime UpdatedDate { get; set; }
        }

}
