using System.Collections.Generic;
using System.Threading.Tasks;
using Tugas.Models;
using Tugas.Models.Entity;

namespace Tugas.Interfaces
{
    public interface IServiceBase
    {
        Task<ServiceResult> GetAllData();
        Task<ServiceResult> Get(int id);
        Task<ServiceResult> Create(IEnumerable<StudentModel> studentModels);
    }
}
