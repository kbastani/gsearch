using gSearch.Core.Graph.Services.Time.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gSearch.Core.Graph.Services.Time.Interfaces
{
    /// <summary>
    /// The ITimeScaleVertex interface is a contract for implementations of the TimeScaleVertex pattern
    /// that is a component to the TimeScale graph architecture.
    /// </summary>
    public interface ITimeScaleVertex
    {
        /// <summary>
        /// A list of implementations of the ITimeScaleRelationship interface.
        /// </summary>
        List<ITimeScaleRelationship> Relationships { get; set; }

        /// <summary>
        /// A list of implementations of the ITimeScaleNode interface.
        /// </summary>
        List<ITimeScaleNode> Nodes { get; set; }
    }
}
