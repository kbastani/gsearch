using gSearch.Core.Graph.Services.Time.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSearch.Core.Graph.Services.Time
{
    public class TimeScaleRelationship : ITimeScaleRelationship
    {
        /// <summary>
        /// The start ID of a node assigned by the Neo4j database.
        /// </summary>
        public int StartId { get; set; }

        /// <summary>
        /// The end ID of a node assigned by the Neo4j database.
        /// </summary>
        public int EndId { get; set; }
    }
}
