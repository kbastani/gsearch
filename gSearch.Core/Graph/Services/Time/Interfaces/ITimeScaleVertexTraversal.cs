using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gSearch.Core.Graph.Services.Time.Interfaces
{
    public interface ITimeScaleVertexTraversal
    {
        Func<ITimeScaleRelationship, List<ITimeScaleVertex>> Callback { get; set; }
    }
}
