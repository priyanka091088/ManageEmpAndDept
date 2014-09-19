using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();

        bool CreateEmployee(Employee emp);

        Employee GetById(int iID);

        bool UpdateEmployee(Employee emp);

        bool DeleteEmployee(Employee emp);

    }
}
