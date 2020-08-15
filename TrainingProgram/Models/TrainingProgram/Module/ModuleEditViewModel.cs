using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingProgram.Models
{
    public class ModuleEditViewModel
    {
        [Required]
        public Guid FLDMODULEID { get; set; }
        public IEnumerable<Entity.Program> Programs { get; set; } = Enumerable.Empty<Entity.Program>();
        [DisplayName("Program"), Required(ErrorMessage = "Program is required")]
        public Guid? FLDPROGRAMID { get; set; }
        [DisplayName("Code"), Required(ErrorMessage = "Module Code is required")]
        public string FLDMODULECODE { get; set; }

        [DisplayName("Name"), Required(ErrorMessage = "Module Name is required")]
        public string FLDMODULENAME { get; set; }
    }
}
