using Repository.Model;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        //Getting Department details
        public List<Department> GetAllDepartment()
        {
            using (var context = new DataContext())
            {
                List<Department> dptLst = context.Department.ToList<Department>();
                return dptLst;
            }
        }

        //Adding Department
        public bool CreateDepartment(Department Dept)
        {
            try
            {
                using (var context = new DataContext())
                {
                    context.Department.Add(Dept);
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Updating Department
        public bool UpdateDepartment(Department Dept)
        {
            try
            {
                using (var context = new DataContext())
                {
                    context.Department.Attach(Dept);
                    context.Entry(Dept).State = System.Data.Entity.EntityState.Modified;
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Deleting Department
        public bool DeleteDepartment(Department Dept)
        {
            try
            {
                using (var context = new DataContext())
                {
                    var entry = context.Entry(Dept);
                    if (entry.State == System.Data.Entity.EntityState.Detached)
                        context.Department.Attach(Dept);

                    context.Department.Remove(Dept);
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
