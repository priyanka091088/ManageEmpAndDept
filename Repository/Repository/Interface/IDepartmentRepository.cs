using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IDepartmentRepository
    {
        List<Department> GetAllDepartment();
        bool CreateDepartment(Department Dept);
        bool UpdateDepartment(Department Dept);
        bool DeleteDepartment(Department Dept);


    }
}
