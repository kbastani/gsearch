using gSearch.Core.Graph.Services.Time.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSearch.Core.Graph.Services.Time
{
    /// <summary>
    /// The TimeScale class is a data management service for a binary tree graph data structure stored in the Neo4j graph database.
    /// </summary>
    public class TimeScale
    {
        /// <summary>
        /// The vertices belonging to this instance of the TimeScale class.
        /// </summary>
        public List<ITimeScaleVertex> Vertices { get; set; }

        /// <summary>
        /// The TimeScaleVertexCache contains a uniquely indexed collection of ITimeScaleVertex implementations, where each implementation of ITimeScaleVertex
        /// manages a single in-memory tuple data structure. A tuple is a reference to a 3-node subgraph in Neo4j.
        /// </summary>
        public Dictionary<int, ITimeScaleVertex> TimeScaleVertexCache { get; set; }

        /// <summary>
        /// Creates a new uninitialized instance of the TimeScale class.
        /// </summary>
        public TimeScale()
        {

        }

        /// <summary>
        /// Creates a new initialized instance of the TimeScale class by supplying a collection of ITimeScaleVertex implementations.
        /// </summary>
        /// <param name="vertices">The list of ITimeScaleVertex implementations that will be managed in-memory for this TimeScale graph.</param>
        public TimeScale(List<ITimeScaleVertex> vertices)
        {
            InitializeTimeScaleGraph(vertices);
        }

        /// <summary>
        /// Initializes this instance of the TimeScale graph data structure with supplied ITimeScaleVertex implementations.
        /// </summary>
        /// <param name="vertices">The list of ITimeScaleVertex implementations that will be managed in-memory for this TimeScale graph.</param>
        public void InitializeTimeScaleGraph(List<ITimeScaleVertex> vertices)
        {
            // Setup the TimeScaleVertexCache.
            if (vertices != null)
            {
                vertices.AsParallel().ForAll(v =>
                {
                    v.Nodes.ToList().AsParallel().ForAll(vn =>
                    {
                        lock (TimeScaleVertexCache)
                        {
                            if (!TimeScaleVertexCache.ContainsKey(vn.NodeId))
                            {
                                TimeScaleVertexCache.Add(vn.NodeId, v);
                            }
                        }
                    });

                });
            }
        }

        /// <summary>
        /// The global callback delegate performs a limited graph search over all implementations of ITimeScaleVertex that are subscribed to this TimeScale graph.
        /// </summary>
        /// <returns>
        /// Returns a functional expression that calls back to the global management service for this TimeScale instance and searches
        /// for connected implementations of the ITimeScaleVertex that are currently stored in-memory.
        /// </returns>
        public Func<ITimeScaleRelationship, List<ITimeScaleVertex>> GlobalCallback()
        {
            // Return the uncompiled functional expression to be supplied as a callback delegate to this class.
            return new Func<ITimeScaleRelationship, List<ITimeScaleVertex>>((tsv) => 
            {
                List<ITimeScaleVertex> results = new List<ITimeScaleVertex>();

                // Search the cache for the start id vertex.
                if (TimeScaleVertexCache.ContainsKey(tsv.StartId))
                {
                    results.Add(TimeScaleVertexCache[tsv.StartId]);
                }

                // Search the cache for the end id vertex.
                if (TimeScaleVertexCache.ContainsKey(tsv.EndId))
                {
                    results.Add(TimeScaleVertexCache[tsv.EndId]);
                }

                return results;
            });
        }
    }
}
