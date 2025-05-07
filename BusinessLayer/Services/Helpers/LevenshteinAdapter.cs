using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services.Helpers.Abstarct;
using F23.StringSimilarity;

namespace BusinessLayer.Services.Helpers
{
    public class LevenshteinAdapter : ISimilarityAlgorithm
    {
        private readonly Levenshtein _levenshtein = new();
        public double CalculateSimilarity(string profliedData, string unprofiledData)
        {
            return _levenshtein.Distance(profliedData, unprofiledData);
        }
    }
}
