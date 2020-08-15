using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TrainingProgram.Entity;
using TrainingProgram.Models;
using TrainingProgram.Services;
namespace TrainingProgram.Controllers.TrainingProgram
{
    public class ModuleController : Controller
    {
        private readonly IModuleService _moduleService;
        private readonly IProgramService _programService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ModuleController(IModuleService ModuleService, IWebHostEnvironment hostingEnvironment , IProgramService ProgramService)
        {
            _moduleService = ModuleService;
            _hostingEnvironment = hostingEnvironment;
            _programService = ProgramService;
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            var Modules =  new ModuleIndexViewModel
            {
                Modules = _moduleService.GetAllModules(),
                Programs = _programService.GetAllPrograms()
                };
            
            return View(Modules);
        }
        [HttpPost]
        public IActionResult Index(ModuleIndexViewModel module)
        {
            var Modules = new ModuleIndexViewModel
            {
                Modules = _moduleService.GetAllModules().Where( m => m.FLDPROGRAMID == module.FLDPROGRAMID).ToList(),
                Programs = _programService.GetAllPrograms(),
                FLDPROGRAMID = module.FLDPROGRAMID

            };

            return View(Modules);
        }

        [HttpGet]
        public IActionResult Create(Guid? id)
        {
            var model = new ModuleCreateViewModel()
            {
                FLDPROGRAMID = id,
                Programs = _programService.GetAllPrograms()
            };
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Create(ModuleCreateViewModel model)
        {
            model.Programs = _programService.GetAllPrograms();
            if (ModelState.IsValid)
            {
                var Module = new Module
                {

                    FLDMODULECODE = model.FLDMODULECODE,
                    FLDMODULENAME = model.FLDMODULENAME,
                    FLDPROGRAMID = model.FLDPROGRAMID


                };

                await _moduleService.CreateAsync(Module);
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }
    }
}
