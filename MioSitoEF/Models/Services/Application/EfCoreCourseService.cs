using Microsoft.EntityFrameworkCore;
using MioSitoEF.Models.Services.Infrastructure;
using MioSitoEF.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MioSitoEF.Models.Services.Application
{
    public class EfCoreCourseService:ICourseService
    {
        private readonly MyCourseDbContext dbContext;
        public EfCoreCourseService(MyCourseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<CourseDetailViewModel>> GetCoursesAsync()
        {
            IQueryable<CourseDetailViewModel> queryLinq = dbContext.Courses.AsNoTracking()
            .Select(course =>
            new CourseDetailViewModel
            {
                Id = course.Id,
                Title = course.Title,
                ImagePath = course.ImagePath,
                Author = course.Author,
                Rating = Convert.ToDouble(course.Rating),
                CurrentPrice = course.CurrentPrice,
                FullPrice = course.FullPrice,
            });

            List<CourseDetailViewModel> courses = await queryLinq.ToListAsync();

            return courses;
        }
        public async Task<CourseDetailViewModel> GetCourseAsync(int id)
        {
            CourseDetailViewModel viewModel = await dbContext.Courses.AsNoTracking()
            .Where(course => course.Id == id)
            .Select(course =>
            new CourseDetailViewModel
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Author = course.Author,
                ImagePath = course.ImagePath,
                Rating = Convert.ToDouble(course.Rating),
                CurrentPrice = course.CurrentPrice,
                FullPrice = course.FullPrice,
                Lessons = course.Lessons.Select(lesson => new LessonViewModel()
                {
                    Id = lesson.Id,
                    Title = lesson.Title,
                    Description = lesson.Description,
                    Duration = TimeSpan.Parse(lesson.Duration)
                }).ToList()
            }).FirstOrDefaultAsync();

            return viewModel;
        } 
        public async Task<CourseDetailViewModel> GetCourseRating(int id)
        {
            CourseDetailViewModel viewModel = await dbContext.Courses.AsNoTracking()
            .Where(course => course.Id == id)
            .Select(course =>
            new CourseDetailViewModel
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Author = course.Author,
                ImagePath = course.ImagePath,
                Rating = Convert.ToDouble(course.Rating),
                CurrentPrice = course.CurrentPrice,
                FullPrice = course.FullPrice,
                Lessons = course.Lessons.Select(lesson => new LessonViewModel()
                {
                    Id = lesson.Id,
                    Title = lesson.Title,
                    Description = lesson.Description,
                    Duration = TimeSpan.Parse(lesson.Duration)
                }).ToList()
            }).FirstOrDefaultAsync();

            return viewModel;
        }
        public async Task<List<CourseDetailViewModel>> GetBestCourses()
        {
            IQueryable<CourseDetailViewModel> queryLinq = dbContext.Courses.AsNoTracking()
            .Where(course => course.Rating >= 4.51 && course.Rating <= 4.95)
            .Select(course =>
            new CourseDetailViewModel
            {
                Id = course.Id,
                Title = course.Title,
                ImagePath = course.ImagePath,
                Author = course.Author,
                Rating = Convert.ToDouble(course.Rating),
                CurrentPrice = course.CurrentPrice,
                FullPrice = course.FullPrice,
            });

            List<CourseDetailViewModel> courses = await queryLinq.ToListAsync();

            return courses;
        }
        public async Task<List<CourseDetailViewModel>> GetWorstCourses()
        {
            IQueryable<CourseDetailViewModel> queryLinq = dbContext.Courses.AsNoTracking()
            .Where(course => course.Rating <=2.5)
            .Select(course =>
            new CourseDetailViewModel
            {
                Id = course.Id,
                Title = course.Title,
                ImagePath = course.ImagePath,
                Author = course.Author,
                Rating = Convert.ToDouble(course.Rating),
                CurrentPrice = course.CurrentPrice,
                FullPrice = course.FullPrice,
            });

            List<CourseDetailViewModel> courses = await queryLinq.ToListAsync();

            return courses;
        }

    }

}
