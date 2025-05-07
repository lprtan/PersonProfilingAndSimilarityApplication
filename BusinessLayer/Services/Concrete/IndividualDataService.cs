using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services.Abstract;
using BusinessLayer.Services.Helpers;
using CoreLayer.Dtos;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLayer.Services.Concrete
{
    public class IndividualDataService : IInvidualDataService
    {
        private readonly IGenericService<IndividualData> _individualDataService;
        private readonly IGenericService<ProfileData> _profileService;

        public IndividualDataService(IGenericService<IndividualData> individualDataService, IGenericService<ProfileData> _profileDataService)
        {
            _individualDataService = individualDataService;
            _profileService = _profileDataService;
        }

        public async Task<ResponseDto<IndividualData>> CreateIndividualDataAsync(IndividualData individualData)
        {
            await _individualDataService.AddAsync(individualData);

            return ResponseDto<IndividualData>.Success(individualData, 201);
        }

        public async Task<ResponseDto<List<IndividualData>>> GetAllIndividualDataAsync()
        {
            var profilledIndividualIds = (await _profileService.GetAllAsync())
                .Select(p => p.IndividualId)
                .ToList();

            var allIndividuals = await _individualDataService.GetAllAsync();

            var unprofiledIndividuals = allIndividuals
                .Where(i => !profilledIndividualIds.Contains(i.Id))
                .ToList();

            var  profiledIndividuals = _individualDataService.AsQueryable()
                .Include(i => i.Profile)
                .Where(i => profilledIndividualIds.Contains(i.Id))
                .ToList();

            await ProfiledHelper.MatchOrCreateProfilesAsync(unprofiledIndividuals, profiledIndividuals, _profileService);

            var newProfiledIndividuals = _individualDataService.AsQueryable()
                .Include(i => i.Profile)
                .Where(i => profilledIndividualIds.Contains(i.Id))
                .ToList();

            return ResponseDto<List<IndividualData>>.Success(newProfiledIndividuals, 200);
        }
    }
}
