using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Repository.Model;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DepartmentDtlRegion.ViewModel
{
    public class DepartmentDtlViewModel : ViewModelBase,IDepartmentDtlViewModel
    {
        #region Private variables
        
        private IDataRepository<Department> _iDptDataRepository;

        private bool _allowAdd = false;
        private bool _allowEdit = false;

        #endregion

        public DepartmentDtlViewModel(IDataRepository<Department> iDptDataRepository)
        {
            this._iDptDataRepository = iDptDataRepository;
            DepartmentList = new ObservableCollection<Department>();
            this.IsControlEnable = false;
            IsEditDeleteEnable = true;

            AddDepartment = new RelayCommand(this.Add);
            EditDepartment = new RelayCommand<Department>(this.Edit);
            DeleteDepartment = new RelayCommand<Department>(this.Delete);
            SaveDepartment = new RelayCommand<Department>(this.Save);
            
            Init();
        }

        #region Properties
        private const string _strDepartmentID = "DepartmentId";
        private int _departmentId;
        public int DepartmentId
        {
            get { return _departmentId; }
            set
            {
                if(_departmentId == value)
                {
                    return;
                }
                var _oldValue = value;
                _departmentId = value;
                RaisePropertyChanged(_strDepartmentID, _oldValue, value, true);
            }
        }

        private const string _strDepartmentName = "DepartmentName";
        private string _departmentName;
        public string DepartmentName 
        {
            get { return _departmentName; }
            set 
            {
                if(_departmentName == value)
                {
                    return;
                }
                var _oldValue = value;
                _departmentName = value;
                RaisePropertyChanged(_strDepartmentName, _oldValue, value, true);
            }
        }

        private const string _strdepartment = "department";
        private Department _department;
        public Department Department
        {
            get { return _department; }
            set
            {
                if (_department == value)
                {
                    return;
                }
                var _oldValue = value;
                _department = value;
                RaisePropertyChanged(_strdepartment, _oldValue, value, true);
            }
        }

        private const string _strIsControlEnable = "IsControlEnable";
        private bool _isControlEnable;
        public bool IsControlEnable
        {
            get { return _isControlEnable; }
            set
            {
                if (_isControlEnable == value)
                {
                    return;
                }
                var _oldValue = value;
                _isControlEnable = value;
                RaisePropertyChanged(_strIsControlEnable, _oldValue, value, true);
            }
        }

        private const string _strIsEditDeleteEnable = "IsEditDeleteEnable";
        private bool _isEditDeleteEnable;
        public bool IsEditDeleteEnable
        {
            get { return _isEditDeleteEnable; }
            set
            {
                if (_isEditDeleteEnable == value)
                {
                    return;
                }
                var _oldValue = value;
                _isEditDeleteEnable = value;
                RaisePropertyChanged(_strIsEditDeleteEnable, _oldValue, value, true);
            }
        }

        #region List of Business
       
        private const string _strDepartmentLst = "DepartmentList";
        private ObservableCollection<Department> _departmentList;
        public ObservableCollection<Department> DepartmentList
        {
            get { return _departmentList; }
            set
            {
                if(_departmentList == value)
                {
                    return;
                }

                var _oldValue = value;
                _departmentList = value;
                RaisePropertyChanged(_strDepartmentLst, _oldValue, value, true);
            }
        }
        #endregion

        #endregion

        #region Events 
        public ICommand AddDepartment { get; private set; }
        public ICommand EditDepartment { get; private set; }
        public ICommand DeleteDepartment { get; private set; }
        public ICommand SaveDepartment { get; private set; }

        private void Add()
        {
            try
            {
                IsControlEnable = true;
                IsEditDeleteEnable = false;
                Department = new Department();
                DepartmentList.Add(Department);
                _allowAdd = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Edit(Department dept)
        {
            if (dept != null)
            {
                _allowEdit = true;
                IsControlEnable = true;
            }
            else
            {
                MessageBox.Show("Please select a record to edit.", "Message");
            }
        }

        private void Delete(Department dept)
        {
            try
            {
                 var res = MessageBox.Show("Are you sure you want to delete the record(s)?.", "Delete Record", MessageBoxButton.YesNo, MessageBoxImage.Question);
                 if (res == MessageBoxResult.Yes)
                 {
                     bool result = _iDptDataRepository.Delete(dept);
                     if (!result)
                         MessageBox.Show("Department not deleted.");
                     else
                         MessageBox.Show("Department deleted successfully.");

                     DepartmentList = new ObservableCollection<Department>();
                     Init();
                 }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Save(Department dept)
        {
            try
            {
                if (dept != null && dept.DepartmentId != 0 && dept.DepartmentName != null)
                {
                    IsEditDeleteEnable = true;
                    IsControlEnable = false;
                    if (_allowAdd)
                    {
                        bool res = _iDptDataRepository.Create(dept);
                        if (!res)
                            MessageBox.Show("Department not added.");
                        else
                            MessageBox.Show("Department added successfully.");

                        _allowAdd = false;
                    }

                    else if (_allowEdit)
                    {
                        bool res = _iDptDataRepository.Update(dept);
                        if (!res)
                            MessageBox.Show("Department not updated.");
                        else
                            MessageBox.Show("Department updated successfully.");

                        _allowEdit = false;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter details.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        private void Init()
        {
            try
            {
                var DeptLst = _iDptDataRepository.GetAllData().ToList();
                foreach (Department item in DeptLst)
                {
                    DepartmentList.Add(item);
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

    }
}
