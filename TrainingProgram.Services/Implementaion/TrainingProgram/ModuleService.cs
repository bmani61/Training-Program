using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingProgram.Entity;
using TrainingProgram.Persistance;

namespace TrainingProgram.Services.Implementaion
{
    public class ModuleService : IModuleService
    {
        private readonly ApplicationDbContext _context;

        public ModuleService(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task CreateAsync(Module Module)
        {
            await _context.Module.AddAsync(Module);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Module> GetAllModules()
        {
            
                return _context.Module;
           
            
            
        }
        public IEnumerable<Module> GetAllModules(Program Program)
        {
            return _context.Module.Where(m => m.FLDPROGRAMID == Program.FLDPROGRAMID).ToList();
        }


            public Module GetModuleById(Guid ModuleId)
        {
            return  _context.Module.Where(m => m.FLDMODULEID == ModuleId).FirstOrDefault();
        }

        public async Task UpdateAsync(Module Module)
        {
            _context.Update(Module);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid ModuleId)
        {
            var module = GetModuleById(ModuleId);
            _context.Update(module);
            await _context.SaveChangesAsync();
        }
    }
}
