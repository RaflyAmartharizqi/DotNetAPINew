using Microsoft.AspNetCore.Mvc;
using Tugas.Models;
using Tugas.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tugas.Models.Entity;

namespace Tugas.Interfaces
{
    public interface IBaseController
    {
        Task<ActionResult<ApiResponse>> GetAllData();
        Task<ActionResult<ApiResponse>> Get(int Id);
        Task<ActionResult<ApiResponse>> Post(IEnumerable<StudentModel> studentModel);


    }
}
