using MioSitoEF.Models.Entities;
using MioSitoEF.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MioSitoEF.Models.ViewModel
{
        public class CourseDetailViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string ImagePath { get; set; }
            public string Author { get; set; }
            public double Rating { get; set; }
            public Money CurrentPrice { get; set; }
            public Money FullPrice { get; set; }
            public string Description { get; set; }
            public List<LessonViewModel> Lessons { get; set; }

            public TimeSpan TotalCourseDuration
            {
                get => TimeSpan.FromSeconds(Lessons?.Sum(l => l.Duration.TotalSeconds) ?? 0);
            }
        
        public static new CourseDetailViewModel FromEntity(Courses course)
        {
            return new CourseDetailViewModel
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Author = course.Author,
                ImagePath = course.ImagePath,
                Rating = course.Rating,
                CurrentPrice = course.CurrentPrice,
                FullPrice = course.FullPrice,
                Lessons = course.Lessons
                .Select(lesson => LessonViewModel.FromEntity(lesson))
                .ToList()
            };
        }

    }

}

