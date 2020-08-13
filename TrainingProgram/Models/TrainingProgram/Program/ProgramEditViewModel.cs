using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingProgram.Models
{
    public class ProgramEditViewModel
    {
        [Required]
        public Guid FLDPROGRAMID { get; set; }
        [Required(ErrorMessage = "Program Code is required"), StringLength(50), Display(Name = "Code")]
        public string FLDPROGRAMCODE { get; set; }
        [Required(ErrorMessage = "Program Name is required"), StringLength(500), Display(Name = "Name")]
        public string FLDPROGRAMNAME { get; set; }
    }
}
