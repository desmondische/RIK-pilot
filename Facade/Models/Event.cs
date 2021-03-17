using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace abc.Facade.Models
{
    public class Event
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Ürituse nimi:")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("Toimumisaeg:")]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Koht:")]
        public string Location { get; set; }

        [StringLength(1000)]
        [DisplayName("Lisainfo:")]
        public string Comment { get; set; }


        [DisplayName("Osavõtjad:")]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
