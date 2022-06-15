using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC3Oef3.Models
{
    public class Punt
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Vak")]
        public int VakId { get; set; }
        //navigation property
        [ForeignKey("VakId")]
        public Vak Vak { get; set; }
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        [Range(0, 20)]
        public int Score { get; set; }
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0}%")]
        public int ScoreProcent => Score * 5;
    }
}
