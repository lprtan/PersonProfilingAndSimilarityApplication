using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Helpers.Abstarct
{
    public interface ISimilarityAlgorithm
    {
        double CalculateSimilarity(string profliedData, string unprofiledData);
    }
}
