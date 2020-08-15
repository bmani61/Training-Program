using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TrainingProgram.Entity;

namespace TrainingProgram.Models
{
    public class ModuleIndexViewModel
    {

        public IEnumerable<Module> Modules { get; set; }

        public IEnumerable<Entity.Program> Programs { get; set; }
        [DisplayName("Program")]
        public Guid? FLDPROGRAMID { get; set; }
    }
}
