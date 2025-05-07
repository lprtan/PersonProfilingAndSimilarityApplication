using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Services.Helpers
{
    public class ProfiledHelper
    {
        public static async Task MatchOrCreateProfilesAsync(List<IndividualData> unprofiled, List<IndividualData> profiled, IGenericService<ProfileData> dataProfiledService)
        {
            int maxProfileId = profiled.Select(p => p.Profile?.ProfileId ?? 0).DefaultIfEmpty(0).Max();
            int nextProfileId = maxProfileId + 1;
            var remaining = new List<IndividualData>(unprofiled);

            foreach (var un in unprofiled.ToList())
            {
                foreach (var prof in profiled)
                {
                    if (SimilarityRatioCalculationHelper.CalculateSimilarity(prof, un, new LevenshteinAdapter()) >= 0.85)
                    {
                        int profileId = prof.Profile.ProfileId;
                        un.Profile = new ProfileData
                        {
                            ProfileId = profileId,
                            IndividualId = un.Id
                        };

                        await dataProfiledService.AddAsync(un.Profile);

                        remaining.Remove(un);
                        break;
                    }
                }
            }


            while (remaining.Any())
            {
                var current = remaining.First();
                remaining.Remove(current);

                var group = new List<IndividualData> { current };

                foreach (var other in remaining.ToList())
                {
                    if (SimilarityRatioCalculationHelper.CalculateSimilarity(current, other, new LevenshteinAdapter()) >= 0.85)
                    {
                        group.Add(other);
                        remaining.Remove(other);
                    }
                }

                foreach (var item in group)
                {
                    item.Profile = new ProfileData
                    {
                        ProfileId = nextProfileId,
                        IndividualId = item.Id
                    };

                    await dataProfiledService.AddAsync(item.Profile);
                }

                nextProfileId++;
            }
        }
    }
}
