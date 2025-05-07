using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services.Helpers.Abstarct;
using EntityLayer.Concrete;
using F23.StringSimilarity;

namespace BusinessLayer.Services.Helpers
{
    public class SimilarityRatioCalculationHelper
    {
        public static double CalculateSimilarity(IndividualData profliedData, IndividualData unprofiledDate, ISimilarityAlgorithm similarityAlgorithm)
        {
            var levenshtein = new Levenshtein();

            if (profliedData == null || unprofiledDate == null)
            {
                throw new ArgumentNullException("Individual data cannot be null.");
            }

            const double threshold = 0.85;
            double ratio = 0;

            string profliedFullName = profliedData.FirstName + " " + profliedData.MiddleName + " " + profliedData.LastName;
            string unprofiledFullName = unprofiledDate.FirstName + " " + unprofiledDate.MiddleName + " " + unprofiledDate.LastName;



            if(profliedData.IdentityNumber == unprofiledDate.IdentityNumber)
            {
                ratio = 1;
                return ratio;
            }


            double fullNameSimilarity = similarityAlgorithm.CalculateSimilarity(profliedFullName, unprofiledFullName);

            double birthPlaceSimilarity = similarityAlgorithm.CalculateSimilarity(profliedData.BirthPlace, unprofiledDate.BirthPlace);

            if(profliedData.Nationality == unprofiledDate.Nationality)
            {
                ratio += 0.15;
            }

            var birthDateDiff = Math.Abs((profliedData.BirthDate - unprofiledDate.BirthDate).TotalDays);
            if (birthDateDiff <= 2)
            {
                ratio += 0.15;
            }

            if (fullNameSimilarity <= 3) 
            {
                ratio += 0.5;
            }

            if(birthPlaceSimilarity <= 2)
            {
                ratio += 0.2;
            }

            return ratio;
        }
    }
}
