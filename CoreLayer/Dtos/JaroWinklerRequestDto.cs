using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace CoreLayer.Dtos
{
    public class JaroWinklerRequestDto
    {
        public IndividualData ProfiledData { get; set; }
        public IndividualData UnprofiledData { get; set; }
    }
}
