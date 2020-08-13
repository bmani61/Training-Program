using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrainingProgram.Entity
{
    public class Program
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FLDPROGRAMID { get; set; }
        [Required, MaxLength(50)]
        public string FLDPROGRAMCODE { get; set; }
        [Required, MaxLength(500)]
        public string FLDPROGRAMNAME { get; set; }
    }
}
