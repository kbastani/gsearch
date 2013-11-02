using gSearch.Core.Graph.Services.Time.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSearch.Core.Graph.Services.Time
{
    /// <summary>
    /// This TimeScale class manages a persistent model of time as a Neo4j graph.
    /// </summary>
    public class TimeScale
    {
        /// <summary>
        /// The vertices belonging to this instance of the TimeScale class.
        /// </summary>
        public List<ITimeScaleVertex> Vertices { get; set; }

        /// <summary>
        /// The TimeScaleVertexCache contains a uniquely indexed collection of TimeScaleVertex instances containing a subgraph triple store.
        /// </summary>
        public Dictionary<int, TimeScaleVertex> TimeScaleVertexCache { get; set; }

        public TimeScale()
        {

        }

        public TimeScale(List<ITimeScaleVertex> vertices)
        {
            InitializeTimeScaleGraph(vertices);
        }

        public void InitializeTimeScaleGraph(List<ITimeScaleVertex> vertices)
        {
            // Setup the TimeScaleVertexCache
            if (vertices != null)
            {
                vertices.ForEach(v =>
                {
                    v.Nodes.ToList().ForEach(vn =>
                    {
                        if (!TimeScaleVertexCache.ContainsKey(vn.NodeId))
                        {
                            TimeScaleVertexCache.Add(vn.NodeId, v as TimeScaleVertex);
                        }
                    });

                });
            }
        }

        /// <summary>
        /// The global callback delegate to perform a graph lookup from subscriber instances of TimeScaleVertex class.
        /// </summary>
        /// <returns></returns>
        public Func<ITimeScaleRelationship, List<ITimeScaleVertex>> GlobalCallback()
        {
            // Return the uncompiled functional expression to be supplied as a callback delegate to this class.
            return new Func<ITimeScaleRelationship, List<ITimeScaleVertex>>((tsv) => 
            {
                List<ITimeScaleVertex> results = new List<ITimeScaleVertex>();

                // Search the cache for the start id vertex
                if (TimeScaleVertexCache.ContainsKey(tsv.StartId))
                {
                    results.Add(TimeScaleVertexCache[tsv.StartId]);
                }

                // Search the cache for the end id vertex
                if (TimeScaleVertexCache.ContainsKey(tsv.EndId))
                {
                    results.Add(TimeScaleVertexCache[tsv.EndId]);
                }

                return results;
            });
        }
    }
}
