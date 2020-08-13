using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProgram.Entity;

namespace TrainingProgram.Services
{
    public interface IProgramService
    {
        Task CreateAsync(Program program);

        Program GetProgramById(Guid programId);

        Task UpdateAsync(Program program);

        Task UpdateAsync(Guid programid);

        IEnumerable<Program> GetAllPrograms();
        
    }
}
