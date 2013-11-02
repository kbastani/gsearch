using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gSearch.Core.Graph.Services.Time.Interfaces
{
    public interface ITimeScaleRelationship
    {
        /// <summary>
        /// The start ID of a node assigned by the Neo4j database.
        /// </summary>
        int StartId { get; set; }

        /// <summary>
        /// The end ID of a node assigned by the Neo4j database.
        /// </summary>
        int EndId { get; set; }
    }
}
