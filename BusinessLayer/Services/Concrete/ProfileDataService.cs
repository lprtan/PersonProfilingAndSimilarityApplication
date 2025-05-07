using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services.Abstract;
using CoreLayer.Dtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Services.Concrete
{
    public class ProfileDataService : IProfileDataService
    {
        private readonly IGenericService<ProfileData> _profileService;

        public ProfileDataService(IGenericService<ProfileData> profileService)
        {
            _profileService = profileService;
        }

        public async Task<ResponseDto<List<ProfileData>>> GetAllProfileDataAsync()
        {
            var individualDataList = await _profileService.GetAllAsync();

            if (individualDataList == null || !individualDataList.Any())
            {
                return ResponseDto<List<ProfileData>>.Fail("Veri bulunamadı", 404, true);
            }

            return ResponseDto<List<ProfileData>>.Success(individualDataList.ToList(), 200);
        }
    }
}
