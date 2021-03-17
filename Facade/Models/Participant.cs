using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations; 

namespace abc.Facade.Models
{
    public enum PaymentType
    {
        Pangaülekanne = 1,
        Sularaha = 2
    }

    public class Participant
    {
        public int ID { get; set; }

        [DisplayName("Eesnimi:")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [StringLength(10, MinimumLength = 2)]
        public string FirstName { get; set; }

        [DisplayName("Perenimi:")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [StringLength(15, MinimumLength = 2)]
        public string LastName { get; set; }

        [DisplayName("Isikukood:")]
        [RegularExpression(@"^[0-9]{11,11}$")] 
        [MaxLength(11)]
        public string PersonalCode { get; set; }

        [DisplayName("Juriidiline nimi:")]
        [StringLength(20, MinimumLength = 2)]
        public string LegalName { get; set; }

        [DisplayName("Registrikood:")]
        [RegularExpression("^\\d+$")]
        [MaxLength(8)]
        public string RegisterCode { get; set; }

        [DisplayName("Osavõtjate arv:")]
        public int? ParticipantsQty { get; set; }

        [DisplayName("Maksmisviis:")]
        public PaymentType PaymentType { get; set; }

        [DisplayName("Lisainfo:")]
        public string Comment { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [DisplayName("Üritused:")]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
