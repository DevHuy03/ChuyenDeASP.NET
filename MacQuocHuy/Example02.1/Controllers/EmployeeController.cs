using Microsoft.AspNetCore.Mvc;

namespace Example02._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        //GET:api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return GetEmployees();
        }
        //GET:api/Employee/2
        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)
        {
            return GetEmployees().Find(e => e.Id == id);
        }
        //POST :api/Employee
        [HttpPost]
        [Produces("application/json")]
        public Employee Post([FromBody] Employee employee)
        {
            return new Employee();
        }
        //put:api/Employee/2
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            //Logic to update an Employee
        }
        //DELETE:api/Employee/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private List<Employee> GetEmployees()
        {
            return new List<Employee>()
   {
    new Employee()
    {
        Id = 1,
        FirstName= "An",
        LastName = "Nguyen",
        EmailId = "nguyenan@gmail.com"
    },
        new Employee()
    {
        Id = 2,
        FirstName= "Tuan",
        LastName = "Nguyen",
        EmailId = "nguyentuan@gmail.com"
    }
        ,
    new Employee()
    {
        Id = 3,
        FirstName= "Tu",
        LastName = "Nguyen",
        EmailId = "nguyentu@gmail.com"
    }
   };
        }
    }
}
