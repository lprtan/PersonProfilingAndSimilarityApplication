using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProfileData : BaseEntity
    {
        public int ProfileId { get; set; }
        public int IndividualId { get; set; }
        public IndividualData Individual { get; set; }
    }
}
