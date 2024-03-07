using Tugas.Interfaces;

namespace Tugas.Services
{
    public class StudentService : ServiceBase
    {
        public StudentService(IRepositoryBase repository) : base(repository)
        {
        }
    }
}
