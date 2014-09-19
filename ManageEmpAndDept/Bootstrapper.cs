using DepartmentDtlRegion.View;
using DepartmentDtlRegion.ViewModel;
using EmployeeDtlRegion.View;
using EmployeeDtlRegion.ViewModel;
using GroupRegion.View;
using GroupRegion.ViewModel;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Repository;
using Repository.Migrations;
using Repository.Model;
using Repository.Repository;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TopRegion.ViewModel;

namespace ManageEmpAndDept
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            Container.RegisterType<TopRegionViewModel>(new PerResolveLifetimeManager());
            Container.RegisterType<GroupRegionViewModel>(new PerResolveLifetimeManager());

            Container.RegisterType(typeof(IDataRepository<>),typeof(DataRepository<>));

            this.Container.RegisterType<IEmployeeDtlViewModel, EmployeeDtlViewModel>(new PerResolveLifetimeManager());
            this.Container.RegisterType<IDepartmentDtlViewModel, DepartmentDtlViewModel>(new PerResolveLifetimeManager());

            Container.RegisterType<DbContext, DataContext>();
            
            Container.RegisterType<EmployeeDtlRegionView>(new PerResolveLifetimeManager());
            Container.RegisterType<DepartmentDtlRegionView>(new PerResolveLifetimeManager());
            Container.RegisterType<GroupRegionView>(new PerResolveLifetimeManager());
            

            Database.SetInitializer<DataContext>(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
            using(var context = new DataContext())
            {
                context.Database.Initialize(false);
            }
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(DemoModule));  

        }
    }
}
