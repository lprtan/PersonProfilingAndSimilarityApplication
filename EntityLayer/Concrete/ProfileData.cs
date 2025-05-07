using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProfileData : BaseEntity
    {
        public int ProfileId { get; set; }
        public int IndividualId { get; set; }

        [JsonIgnore]
        public IndividualData Individual { get; set; }
    }
}
