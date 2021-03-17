using System.Collections.Generic;

namespace abc.Facade.Models.Unrealized
{
    public class Participant : Common
    {
        public string PaymentType { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
