using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TrainingProgram.Models;
using TrainingProgram.Services;

namespace TrainingProgram.Controllers
{
    
    public class ProgramController : Controller
    {
        private readonly IProgramService _programService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProgramController(IProgramService programService, IWebHostEnvironment hostingEnvironment)
        {
            _programService = programService;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet,HttpPost]
        public IActionResult Index()
        {
            var Programs = _programService.GetAllPrograms().Select(Program => new ProgramIndexViewModel
            {
               FLDPROGRAMID = Program.FLDPROGRAMID,
               FLDPROGRAMCODE = Program.FLDPROGRAMCODE,
               FLDPROGRAMNAME = Program.FLDPROGRAMNAME
            }).ToList();
            return View(Programs);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProgramCreateViewModel();
            return View(model);

        }
        [HttpPost]
        
        public async Task<IActionResult> Create(ProgramCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var program = new Entity.Program
                {
                   
                   FLDPROGRAMCODE = model.FLDPROGRAMCODE,
                   FLDPROGRAMNAME = model.FLDPROGRAMNAME


                };
                
                await _programService.CreateAsync(program);
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var Program = _programService.GetProgramById(id);
            if (Program == null)
            {
                return NotFound();
            }
            var model = new ProgramEditViewModel()
            {
                FLDPROGRAMID = Program.FLDPROGRAMID,
                FLDPROGRAMCODE = Program.FLDPROGRAMCODE,
                FLDPROGRAMNAME = Program.FLDPROGRAMNAME

            };
            return View(model);
        }

        [HttpPost]
        
        public async Task<IActionResult> Edit(ProgramEditViewModel model , Guid id)
        {
            if (ModelState.IsValid)
            {
                var Program = _programService.GetProgramById(id);
                if (Program == null)
                {
                    return NotFound();
                }

                
                Program.FLDPROGRAMCODE = model.FLDPROGRAMCODE;
                Program.FLDPROGRAMNAME = model.FLDPROGRAMNAME;
                
                
                await _programService.UpdateAsync(Program);
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
        
        

    }
}
