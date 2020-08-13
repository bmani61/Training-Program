using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet, HttpPost]
        //public IActionResult Index(Entity.Program Program)
        //{
        //    var Module = _moduleService.GetAllModules(Program).Select(Module => new ModuleIndexViewModel
        //    {
        //        FLDPROGRAMID = Module.FLDPROGRAMID,
        //        FLDMODULECODE = Module.FLDMODULECODE,
        //        FLDMODULENAME = Module.FLDMODULENAME,
        //    }).ToList();
        //    ViewBag.ProgramsList = _programService.GetAllPrograms();
        //    return View(Module);
        //}
        [HttpGet, HttpPost]
        public IActionResult Index()
        {
            var Module = _moduleService.GetAllModules().Select(Module => new ModuleIndexViewModel
            {
                FLDPROGRAMID = Module.FLDPROGRAMID,
                FLDMODULECODE = Module.FLDMODULECODE,
                FLDMODULENAME = Module.FLDMODULENAME,
            }).ToList();
            ViewBag.ProgramsList = _programService.GetAllPrograms();
            return View(Module);
        }
    }
}
