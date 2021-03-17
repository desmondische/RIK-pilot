using System;
using System.Collections.Generic;

namespace abc.Facade.Models.Unrealized
{
    public class Event : Common
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
