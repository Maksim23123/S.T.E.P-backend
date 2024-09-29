using STEP_backend.Models.Dtos;

namespace STEP_backend.Architecture.Services
{
    public interface IPackageService
    {
        Task CreatePackage(PackageDto package);
        Task<IEnumerable<PackageDto>> GetAllPackagesOfStudentId(string studentId);
    }
}
