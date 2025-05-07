using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Services.Abstract
{
    public interface IInvidualDataService
    {
        Task<ResponseDto<IndividualData>> CreateIndividualDataAsync(IndividualData individualData);

        Task<ResponseDto<List<IndividualData>>> GetAllIndividualDataAsync();
    }
}
