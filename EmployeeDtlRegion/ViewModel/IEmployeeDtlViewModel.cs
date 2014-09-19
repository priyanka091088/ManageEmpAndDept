using Repository.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDtlRegion.ViewModel
{
    public interface IEmployeeDtlViewModel
    {
        ObservableCollection<Employee> EmployeeList {get;set;}

        int EmployeeId {get;set;}

        string FirstName {get;set;}

        string LastName{get;set;}

        int DepartmentId { get; set; }
    }
}
