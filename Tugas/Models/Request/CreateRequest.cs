using Tugas.Models.Entity;


namespace Tugas.Models.Request
{
    public class CreateRequest
    {
        public StudentModel student { get; set; }
        public dynamic entity { get; set; }
    }
}
