using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Services.Abstract
{
    public interface IProfileDataService
    {
        Task<ResponseDto<List<ProfileData>>> GetAllProfileDataAsync();
    }
}
