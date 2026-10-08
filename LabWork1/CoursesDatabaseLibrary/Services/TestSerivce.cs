using CoursesDatabaseLibrary.Contexts;
using CoursesDatabaseLibrary.Models;

namespace CoursesDatabaseLibrary.Services
{
    public class TestSerivce
    {
        private readonly CoursesContext _context = new();

        async public Task CreateTestAsync(int topicId, string Title)
        {
            Test test = new()
            {
                TopicId = topicId,
                Title = Title
            };

            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();
        }

        async public Task CreateExerciseAsync(int topicId, string title, string description)
        {
            Exercise exercise = new()
            {
                TopicId = topicId,
                Title = title,
                Description = description
            };

            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
        }
    }
}
