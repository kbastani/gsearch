using gSearch.Core.Graph.Services.Time.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSearch.Core.Graph.Services.Time
{
    /// <summary>
    /// The TimeScaleVertex class manages a triple in the form of three nodes with a directed relationship configuration.
    /// </summary>
    public class TimeScaleVertex : TimeScaleVertexTraversal, ITimeScaleVertex
    {
        /// <summary>
        /// Creates an unitialized instance of the TimeScaleVertex class, without nodes and relationship data.
        /// </summary>
        /// <param name="callback">The callback parameter supplies this instance of the TimeScaleVertex class a delegate method to callback to a globally managed TimeScale class.</param>
        public TimeScaleVertex(Func<ITimeScaleRelationship, List<ITimeScaleVertex>> callback)
            : base(callback)
        {
            InitializeTimeScaleInstance(null, null, callback);
        }

        /// <summary>
        /// Creates a new instance of the TimeScaleVertex class, supplying node data.
        /// </summary>
        /// <param name="nodes">The nodes that will be managed in the scope of this TimeScaleVertex class.</param>
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
        public void InitializeTimeScaleInstance(List<ITimeScaleNode> nodes, List<ITimeScaleRelationship> relationships, Func<ITimeScaleRelationship, List<ITimeScaleVertex>> callback)
        {
            RelationshipStartCache = new Dictionary<int, ITimeScaleRelationship>();
            RelationshipEndCache = new Dictionary<int, ITimeScaleRelationship>();

            // Setup callback
            if (callback == null)
            {
                throw new ArgumentException("The supplied callback cannot be null. Please be sure to supply a global callback to a globally managed TimeScale class.");
            }
            else
            {

            }

            if (nodes != null)
            {
                Nodes = nodes;
            }
            
            // If relationships exist, then setup the relationship caches
            if (relationships != null)
            {
                Relationships = relationships;

                // Setup relationship storage cache
                Relationships.ForEach(r =>
                {
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

        public Func<ITimeScaleRelationship, List<ITimeScaleVertex>> TimeScaleCallback
        {
            get
            {
                return Callback;
            }
        }
    }

    /// <summary>
    /// The TimeScaleVertexTraversal class implements the ITimeScaleVertexTraversal interface for traversing a TimeScale graph.
    /// </summary>
    public class TimeScaleVertexTraversal : ITimeScaleVertexTraversal
    {
        /// <summary>
        /// Create a new instance of the TimeScaleVertexTraversal class with a supplied callback delegate to a globally managed TimeScale class.
        /// </summary>
        /// <param name="traversal"></param>
        public TimeScaleVertexTraversal(Func<ITimeScaleRelationship, List<ITimeScaleVertex>> traversal)
        {
            Callback = traversal;
        }

        private Func<ITimeScaleRelationship, List<ITimeScaleVertex>> _callback;

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

    /// <summary>
    /// The TimeScaleNode class manages a single node within a larger TimeScaleGraph object.
    /// Each TimeScaleNode represents a reference to a Neo4j database node, having n relationships.
    /// </summary>
    public class TimeScaleNode<T> where T : ITimeScaleNode 
    {
        /// <summary>
        /// The ID of the node assigned by the Neo4j database.
        /// </summary>
        public int NodeId { get; set; }
    }

    public class GenericTimeScaleNode : ITimeScaleNode
    {
        /// <summary>
        /// The ID of the node assigned by the Neo4j database.
        /// </summary>
        public int NodeId { get; set; }

        /// <summary>
        /// The bit configuration of this GenericTimeScaleNode.
        /// </summary>
        public int Bit { get; set; }

        /// <summary>
        /// The interval in milliseconds represented by this GenericTimeScaleNode.
        /// </summary>
        public int Interval { get; set; }
    }

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
