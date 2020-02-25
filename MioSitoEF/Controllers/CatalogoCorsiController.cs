using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MioSitoEF.Models.Services.Application;

namespace MioSitoEF.Controllers
{
    public class CatalogoCorsiController : Controller
    {
        private readonly ICourseService _courseService;
        public CatalogoCorsiController(ICourseService courseService)
        {
            this._courseService = courseService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var courseService = await _courseService.GetCoursesAsync();

            return View(courseService);
        }
        public async Task<IActionResult> DettagliButtonAsync(int id)
        {
            var courseService = await _courseService.GetCourseAsync(id);

            return View(courseService);
        }        
        public async Task<IActionResult> Rating(int id)
        {
            var courseService = await _courseService.GetCourseRating(id);

            return View(courseService);
        }
        public async Task<IActionResult> BestCourses()
        {
            var courseService = await _courseService.GetBestCourses();

            return View(courseService);
        }  
        public async Task<IActionResult> WorstCourses()
        {
            var courseService = await _courseService.GetWorstCourses();

            return View(courseService);
        }
    }
}