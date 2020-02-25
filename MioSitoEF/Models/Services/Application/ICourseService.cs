using MioSitoEF.Models.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MioSitoEF.Models.Services.Application
{
    public interface ICourseService
    {
        public Task<CourseDetailViewModel> GetCourseAsync(int id);
        public Task<List<CourseDetailViewModel>> GetCoursesAsync();
        public Task<CourseDetailViewModel> GetCourseRating(int id);
        public Task<List<CourseDetailViewModel>> GetBestCourses();
        public Task<List<CourseDetailViewModel>> GetWorstCourses();

    }
}