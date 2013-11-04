using gSearch.Core.Graph.Services.Time.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSearch.Core.Graph.Services.Time
{
    /// <summary>
    /// The TimeScaleVertexTraversal class implements the ITimeScaleVertexTraversal interface for traversing a TimeScale graph.
    /// </summary>
    public class TimeScaleVertexTraversal : ITimeScaleVertexTraversal
    {
        private Func<ITimeScaleRelationship, List<ITimeScaleVertex>> _callback;

        /// <summary>
        /// Create a new instance of the TimeScaleVertexTraversal class with a supplied callback delegate to a globally managed TimeScale class.
        /// </summary>
        /// <param name="traversal"></param>
        public TimeScaleVertexTraversal(Func<ITimeScaleRelationship, List<ITimeScaleVertex>> traversal)
        {
            Callback = traversal;
        }

        /// <summary>
        /// This Callback property sets or gets a delegate method to callback to a globally managed TimeScale class.
        /// </summary>
        public Func<ITimeScaleRelationship, List<ITimeScaleVertex>> Callback
        {
            get
            {
                return _callback;
            }
            set
            {
                _callback = value;
            }
        }
    }
}
