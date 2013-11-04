using gSearch.Core.Graph.Services.Time.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSearch.Core.Graph.Services.Time
{
    /// <summary>
    /// The TimeScaleVertex class manages a tuple in the form of a 3-nodes subgraph with a directed relationship configuration.
    /// </summary>
    public class TimeScaleVertex : TimeScaleVertexTraversal, ITimeScaleVertex
    {

        /// <summary>
        /// The nodes and their corresponding properties.
        /// </summary>
        public List<ITimeScaleNode> Nodes { get; set; }

        /// <summary>
        /// The partioned relationship store for this TimeScaleVertex.
        /// </summary>
        public List<ITimeScaleRelationship> Relationships { get; set; }

        /// <summary>
        /// The relationship start cache is an index of node identifiers for outgoing directed relationship objects.
        /// </summary>
        public Dictionary<int, ITimeScaleRelationship> RelationshipStartCache { get; set; }

        /// <summary>
        /// The relationship end cache is an index of node identifiers for incoming directed relationship objects.
        /// </summary>
        public Dictionary<int, ITimeScaleRelationship> RelationshipEndCache { get; set; }

        /// <summary>
        /// Creates an uninitialized instance of the TimeScaleVertex class, without nodes and relationship data.
        /// </summary>
        /// <param name="callback">
        /// The callback parameter supplies this implementation of the ITimeScaleVertex class a delegate method to callback to a 
        /// globally managed TimeScale class.
        /// </param>
        public TimeScaleVertex(Func<ITimeScaleRelationship, List<ITimeScaleVertex>> callback)
            : base(callback)
        {
            InitializeTimeScaleInstance(null, null, callback);
        }

        /// <summary>
        /// Creates a new instance of the TimeScaleVertex class, supplying node data.
        /// </summary>
        /// <param name="nodes">The nodes that will be managed in the scope of this TimeScaleVertex class.</param>
        /// <param name="callback">
        /// The callback parameter supplies this implementation of the ITimeScaleVertex class a delegate method to callback to a 
        /// globally managed TimeScale class.
        /// </param>
        public TimeScaleVertex(List<ITimeScaleNode> nodes, Func<ITimeScaleRelationship, List<ITimeScaleVertex>> callback)
            : base(callback)
        {
            InitializeTimeScaleInstance(nodes, null, callback);
        }

        /// <summary>
        /// Creates a new instance of the TimeScaleVertex class, supplying node and relationship data.
        /// </summary>
        /// <param name="nodes">The nodes that will be managed in the scope of this TimeScaleVertex class.</param>
        /// <param name="relationships">The relationships that will link the TimeScaleVertex nodes within the scope of this class.</param>
        /// <param name="callback">The callback parameter supplies this implementation of the ITimeScaleVertex class a delegate method to callback to a 
        /// globally managed TimeScale class.</param>
        public TimeScaleVertex(List<ITimeScaleNode> nodes, List<ITimeScaleRelationship> relationships, Func<ITimeScaleRelationship, List<ITimeScaleVertex>> callback)
            : base(callback)
        {
            InitializeTimeScaleInstance(nodes, relationships, callback);
        }

        /// <summary>
        /// Initializes the TimeScaleVertex class with supplied TimeScaleNode and TimeScaleRelationship lists.
        /// </summary>
        /// <param name="nodes">The nodes that will be managed in the scope of this TimeScaleVertex class.</param>
        /// <param name="relationships">The relationships that will link the TimeScaleVertex nodes within the scope of this class.</param>
        /// <param name="callback">The callback parameter supplies this implementation of the ITimeScaleVertex class a delegate method to callback to a 
        /// globally managed TimeScale class.</param>
        public void InitializeTimeScaleInstance(List<ITimeScaleNode> nodes, List<ITimeScaleRelationship> relationships, Func<ITimeScaleRelationship, List<ITimeScaleVertex>> callback)
        {
            RelationshipStartCache = new Dictionary<int, ITimeScaleRelationship>();
            RelationshipEndCache = new Dictionary<int, ITimeScaleRelationship>();

            // Setup callback
            if (callback == null)
            {
                // Throw an exception, notifying the application runtime that a callback expression is mandatory.
                throw new ArgumentException("The supplied callback cannot be null. Please be sure to supply a global callback to a globally managed TimeScale class.");
            }
            else
            {
                this.Callback = callback;
            }

            if (nodes != null)
            {
                Nodes = nodes;
            }
            
            // If relationships exist, then setup the relationship caches.
            if (relationships != null)
            {
                Relationships = relationships;

                // Setup relationship storage cache.
                Relationships.ForEach(r =>
                {
                    // These lookup tables provide fast in-memory access to local nodes within this subgraph.
                    if (!RelationshipStartCache.ContainsKey(r.StartId))
                    {
                        RelationshipStartCache.Add(r.StartId, r);
                    }

                    if (!RelationshipEndCache.ContainsKey(r.EndId))
                    {
                        RelationshipEndCache.Add(r.EndId, r);
                    }
                });
            }
        }
    }
}
