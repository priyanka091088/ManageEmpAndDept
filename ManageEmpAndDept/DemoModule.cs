using DepartmentDtlRegion.View;
using EmployeeDtlRegion.View;
using GroupRegion.View;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopRegion.View;

namespace ManageEmpAndDept
{
    class DemoModule : IModule
    {
        private IRegionManager _region { get; set; }
        private IUnityContainer _container { get; set; }

        public DemoModule(IRegionManager Region, IUnityContainer container)
        {
            this._region = Region;
            this._container = container;
        }

        public void Initialize()
        {
            var TopRegion = this._region.Regions["TopRegionView"];
            var GroupRegion = this._region.Regions["GroupRegionView"];
            var EmpDtlRegion = this._region.Regions["EmployeeDtlRegionView"];

            TopRegion.Add(new TopRegionView(), "TopRegionView");
            GroupRegion.Add(_container.Resolve<GroupRegionView>(), "GroupRegionView");
            EmpDtlRegion.Add(_container.Resolve<EmployeeDtlRegionView>(), "EmployeeDtlRegionView");
            EmpDtlRegion.Add(_container.Resolve<DepartmentDtlRegionView>(), "DepartmentDtlRegionView");
        }
    }
}
