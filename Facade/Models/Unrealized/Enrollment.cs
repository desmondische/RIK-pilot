using System.ComponentModel.DataAnnotations;

namespace abc.Facade.Models.Unrealized
{
    public class Enrollment
    {
        public int ID { get; set; }
        public int ParticipantID { get; set; }
        public int EventID { get; set; }
        public Event Event { get; set; }
        public Participant Participant { get; set; }
    }
}
