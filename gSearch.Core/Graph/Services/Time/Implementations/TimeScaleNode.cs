using gSearch.Core.Graph.Services.Time.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSearch.Core.Graph.Services.Time
{
    public class TimeScaleNode : ITimeScaleNode
    {
        /// <summary>
        /// The ID of the node assigned by the Neo4j database.
        /// </summary>
        public int NodeId { get; set; }

        /// <summary>
        /// The bit configuration of this TimeScaleNode.
        /// </summary>
        public int Bit { get; set; }

        /// <summary>
        /// The interval in milliseconds represented by this GenericTimeScaleNode.
        /// </summary>
        public int Interval { get; set; }
    }
}
