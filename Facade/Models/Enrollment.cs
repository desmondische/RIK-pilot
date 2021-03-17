namespace abc.Facade.Models
{
    public class Enrollment
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int ParticipantID { get; set; }

        public Participant Participant { get; set; }
        public Event Event { get; set; }
    }
}
