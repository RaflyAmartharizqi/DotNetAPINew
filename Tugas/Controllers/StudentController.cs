using Microsoft.AspNetCore.Mvc;
using Tugas.Interfaces;

namespace Tugas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : BaseController
    {
        public StudentController(IServiceBase service) : base(service) 
        { 
        
        }
    }
}
