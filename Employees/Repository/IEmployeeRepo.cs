using DataAccessLayer.DAL;
using Employees.Models;
using System.Collections.Generic;

namespace Employees.Repository
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetAll();
        ApiResponse Get(int id);
        ApiResponse Add(Employee item);
        ApiResponse Remove(int id);
        ApiResponse Update(Employee item);
    }
}
