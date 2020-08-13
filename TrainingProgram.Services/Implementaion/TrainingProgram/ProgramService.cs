using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingProgram.Entity;
using TrainingProgram.Persistance;

namespace TrainingProgram.Services.Implementaion
{
    public  class ProgramService : IProgramService
    {
        private readonly ApplicationDbContext _context;

        public ProgramService(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task CreateAsync(Program program)
        {
            await _context.Program.AddAsync(program);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Program> GetAllPrograms()
        {
            return _context.Program;
        }

        public Program GetProgramById(Guid programId)
        {
            return _context.Program.Where(e => e.FLDPROGRAMID == programId).FirstOrDefault();
        }

        public async  Task UpdateAsync(Program program)
        {
            _context.Update(program);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid programid)
        {
            var program = GetProgramById(programid);
            _context.Update(program);
            await _context.SaveChangesAsync();
        }
    }
}
