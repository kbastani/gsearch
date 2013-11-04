using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gSearch.Core.Graph.Services.Time.Interfaces
{
    /// <summary>
    /// The ITimeScaleVertexTraversal interface is a contract for traversal implementations in
    /// the TimeScale graph architecture.
    /// </summary>
    public interface ITimeScaleVertexTraversal
    {
        /// <summary>
        /// The Callback property sets or gets a delegate method to callback to a globally managed TimeScale class.
        /// </summary>
        Func<ITimeScaleRelationship, List<ITimeScaleVertex>> Callback { get; set; }
    }
}
