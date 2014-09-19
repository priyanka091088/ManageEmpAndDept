
using Repository.Model;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> GetAllEmployees()
        {
            using (var context = new DataContext())
            {
                List<Employee> empLst = context.Employee.ToList();
                return empLst;
            }
        }

        //Adding Employee
        public bool CreateEmployee(Employee emp)
        {
            try
            {
                using (var context = new DataContext())
                {
                    context.Employee.Add(emp);
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee GetById(int iID)
        {
            try
            {
                using (var context = new DataContext())
                {
                    Employee emp = context.Employee.Where(x => x.EmployeeId == iID).SingleOrDefault();
                    return emp;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        //Updating Employee details
        public bool UpdateEmployee(Employee emp)
        {
            try
            {
                using (var context = new DataContext())
                {
                    context.Employee.Attach(emp);
                    context.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        //Deleting Employee
        public bool DeleteEmployee(Employee emp)
        {
            try
            {
                using (var context = new DataContext())
                {
                    //var strID = context.Employee.Find(emp.EmployeeId);
                    //context.Employee.Remove(emp);
                    var entry = context.Entry(emp);
                    if (entry.State == System.Data.Entity.EntityState.Detached)
                        context.Employee.Attach(emp);

                    context.Employee.Remove(emp);
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
    }
}
