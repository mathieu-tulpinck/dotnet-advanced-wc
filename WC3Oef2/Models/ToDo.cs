using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC3Oef2.Models
{
    public class ToDo
    {
        public ToDo()
        {
            Date = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
