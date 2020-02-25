using MioSitoEF.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MioSitoEF.Models.ViewModel
{
    public class LessonViewModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }

        internal static LessonViewModel FromEntity(Lessons lesson)
        {
            return new LessonViewModel
            {
                Id = lesson.Id,
                CourseId = lesson.CourseId,
                Title = lesson.Title,
                Description = lesson.Description,
                Duration = TimeSpan.Parse(lesson.Duration)
            };
        }
    }
}
