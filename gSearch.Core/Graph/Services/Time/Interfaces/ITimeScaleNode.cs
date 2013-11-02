using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gSearch.Core.Graph.Services.Time.Interfaces
{
    /// <summary>
    /// This interface contract defines the TimeScaleNode construct's shared features.
    /// </summary>
    public interface ITimeScaleNode
    {
        /// <summary>
        /// The node id of the managed Neo4j database node.
        /// </summary>
        int NodeId { get; set; }
    }
}
