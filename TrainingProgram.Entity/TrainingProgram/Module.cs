using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrainingProgram.Entity
{
    public class Module
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FLDMODULEID { get; set; }
        [Required,ForeignKey("Program")]
        public Guid? FLDPROGRAMID { get; set; }
        [Required, MaxLength(50)]
        public string  FLDMODULECODE{ get; set; }
        [Required, MaxLength(500)]
        public string FLDMODULENAME { get; set; }
    }
}
