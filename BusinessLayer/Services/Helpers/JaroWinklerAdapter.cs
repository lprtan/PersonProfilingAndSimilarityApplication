using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services.Helpers.Abstarct;
using F23.StringSimilarity;

namespace BusinessLayer.Services.Helpers
{
    public class JaroWinklerAdapter : ISimilarityAlgorithm
    {
        private readonly JaroWinkler _jaro = new();

        public double CalculateSimilarity(string profliedData, string unprofiledData)
        {
            return 1 - _jaro.Similarity(profliedData, unprofiledData);
        }
    }
}
