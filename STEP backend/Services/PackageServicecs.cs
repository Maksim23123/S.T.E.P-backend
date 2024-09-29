using Microsoft.EntityFrameworkCore;
using STEP_backend.Architecture.Services;
using STEP_backend.Entity;
using STEP_backend.Models.Dtos;

namespace STEP_backend.Services
{
    public class PackageServicecs : IPackageService
    {
        private readonly ApplicationDbContext _dbContext;
        public PackageServicecs(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreatePackage(PackageDto packageDto)
        {
            if (packageDto == null)
            {
                throw new ArgumentException("Package cannot be null");
            }
            var package = new Package()
            {
                StudentId = packageDto.StudentId,
                Material = packageDto.Material,
                TopicName = packageDto.TopicName,
                Test = new Test
                {
                    Questions = packageDto.Test.Questions.Select(x => new Question
                    {
                        Title = x.Title,
                        Answers = x.Answers.Select(ans => new Answer
                        {
                            isCorrect = ans.isCorrect,
                            Text = ans.Text,
                        }).ToList()
                    }).ToList()
                }
            };
            _dbContext.Packages.Add(package);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PackageDto>> GetAllPackagesOfStudentId(string studentId)
        {
            var student = await _dbContext.Students.Include(stud => stud.Packages).ThenInclude(pack => pack.Test).ThenInclude(test => test.Questions).ThenInclude(question => question.Answers).SingleOrDefaultAsync(stud => stud.Id == studentId);
            if (student == null)
            {
                throw new ArgumentException("No student with given id is in database");
            }
            var packages = student.Packages.ToList();
            var packagesDto = packages.Select(package => new PackageDto
            {
                Material = package.Material,
                TopicName = package.TopicName,
                StudentId = package.StudentId,
                Test = new TestDto
                {
                    Questions = package.Test.Questions.Select(x => new QuestionDto
                    {
                        Title = x.Title,
                        Answers = x.Answers.Select(ans => new AnswerDto
                        {
                            isCorrect = ans.isCorrect,
                            Text = ans.Text,
                        })
                    })
                }
            });
            return packagesDto;
        }
    }
}
