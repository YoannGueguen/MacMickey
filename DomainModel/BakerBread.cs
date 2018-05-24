using System;
using System.Collections.Generic;
using System.Text;

namespace MacMickey.DomainModel
{
    // EF core only (version 2)
    /// <summary>
    /// Association entity for many-to-many
    /// </summary>
    public class BakerBread
    {
        public int BakerId { get; set; }
        public Baker Baker { get; set; }

        public int BreadId { get; set; }
        public Bread Bread { get; set; }
    }
}
