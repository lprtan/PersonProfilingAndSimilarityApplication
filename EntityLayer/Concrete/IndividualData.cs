using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class IndividualData : BaseEntity
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string BirthPlace { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string IdentityNumber { get; set; }
        public ProfileData Profile { get; set; }
    }
}
