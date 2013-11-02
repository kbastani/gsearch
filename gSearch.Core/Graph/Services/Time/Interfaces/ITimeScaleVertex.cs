using gSearch.Core.Graph.Services.Time.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gSearch.Core.Graph.Services.Time.Interfaces
{
    public interface ITimeScaleVertex
    {
        Func<ITimeScaleRelationship, List<ITimeScaleVertex>> TimeScaleCallback { get; }

        List<ITimeScaleRelationship> Relationships { get; set; }

        List<ITimeScaleNode> Nodes { get; set; }
    }
}
