using DataAccessLayer.DAL;
using Employees.Models;
using Employees.Repository;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Employees.Controllers
{
    public class EmployeesApiController : ApiController
    {
        static readonly IEmployeeRepo repo = new EmployeeRepo();

        // GET : /api/employeesapi
        public IEnumerable<Employee> GetEmployee()
        {
            return repo.GetAll();
        }

        // GET : /api/employeesapi/id
        public ApiResponse GetEmployee(int id)
        {
            ApiResponse item = repo.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        // DELETE : /api/employeesapi/id
        [HttpDelete]
        public ApiResponse DeleteEmployee(int id)
        {
            return repo.Remove(id);
        }

        // POST : /api/employeesapi/
        [HttpPost]
        public ApiResponse AddEmployee(Employee item)
        {
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
            return repo.Add(item);
        }

        // PUT : /api/employeesapi/id
        [HttpPut]
        public ApiResponse UpdateEmployee(Employee item)
        {
            return repo.Update(item);
        }
    }
}
