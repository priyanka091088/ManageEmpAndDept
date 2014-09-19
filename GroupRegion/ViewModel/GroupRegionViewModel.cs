using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GroupRegion.ViewModel
{
    public class GroupRegionViewModel : ViewModelBase
    {

        private IRegionManager _region;

        public GroupRegionViewModel(IRegionManager region)
        {
            this._region = region;
            ShowEmployeeRegion = new DelegateCommand(this.EmployeeRegionView);
            ShowDepartmentRegion = new DelegateCommand(this.DepartmentRegionView);

        }

        #region Event
        public ICommand ShowEmployeeRegion { get; private set; }
        public ICommand ShowDepartmentRegion { get; private set; }

        private void EmployeeRegionView()
        {
            var EmployeeRegionView = this._region.Regions["EmployeeDtlRegionView"].GetView("EmployeeDtlRegionView");
            this._region.Regions["EmployeeDtlRegionView"].Activate(EmployeeRegionView);
        }

        private void DepartmentRegionView()
        {
            var DepartmentRegionView = this._region.Regions["EmployeeDtlRegionView"].GetView("DepartmentDtlRegionView");
            this._region.Regions["EmployeeDtlRegionView"].Activate(DepartmentRegionView);
        }

        #endregion
    }
}
