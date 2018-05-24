using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.DomainModel
{
    public class Baker
    {
        /// <summary>
        /// Primary key of the baker table
        /// </summary>
        public int BakerId { get; set; }

        /// <summary>
        /// Name of the supplier
        /// </summary>
        /// <remarks>30 chars max</remarks>
        public string Name { get; set; }

        // EF core only (version 2)
        /// <summary>
        /// Type of breads produce by the supplier (baker)
        /// </summary>
        public virtual ICollection<BakerBread> BakerBreads { get; set; }
    }
}
