using System.Collections.Generic;
using System.Threading.Tasks;
using Tugas.Models.Entity;


namespace Tugas.Interfaces
{
    public interface IRepositoryBase
    {
        Task<IEnumerable<dynamic>> GetAllData();
        Task<dynamic> Get(int id);
        //Task<dynamic> Create(StudentModel StudentModel);
        Task<dynamic> Create(IEnumerable<StudentModel> studentModels);



    }
}
