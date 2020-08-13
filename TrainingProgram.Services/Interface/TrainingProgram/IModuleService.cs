using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProgram.Entity;

namespace TrainingProgram.Services
{
    public interface IModuleService
    {
        Task CreateAsync(Module Module);

        Module GetModuleById(Guid ModuleId);

        Task UpdateAsync(Module Module);

        Task UpdateAsync(Guid ModuleId);

        IEnumerable<Module> GetAllModules(Program program);
        IEnumerable<Module> GetAllModules();
    }
}
