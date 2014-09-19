using EmployeeDtlRegion.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Repository.Model;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace EmployeeDtlRegion.ViewModel
{
    public class EmployeeDtlViewModel : ViewModelBase,IEmployeeDtlViewModel
    {
        #region Private variables
        

        private IDataRepository<Employee> _iEmployeeRepository;
        private IDataRepository<Department> _iDeptRepository;

        private bool _allowAdd = false;
        private bool _allowEdit = false;

        #endregion
        public EmployeeDtlViewModel(IDataRepository<Employee> iEmployeeRepository, IDataRepository<Department> iDeptRepository)
        {
            
            this._iEmployeeRepository = iEmployeeRepository;
            this._iDeptRepository = iDeptRepository;
            IsControlEnable = false;
            IsEditDeleteEnable = true;

            EmployeeList = new ObservableCollection<Employee>();
            DepartmentList = new ObservableCollection<Department>();

            AddEmployee = new RelayCommand(this.Add);
            EditEmployee = new RelayCommand<Employee>(this.Edit);
            SaveEmployee = new RelayCommand<Employee>(this.Save);
            DeleteEmployee = new RelayCommand<Employee>(this.Delete);

            Init();
            
        }

        #region Properties

        private const string _strEmployeeId = "EmployeeId";
        private int _employeeId;
        public int EmployeeId
        {
            get { return _employeeId; }
            set
            {
                if (_employeeId == value)
                {
                    return;
                }

                var _oldValue = value;
                _employeeId = value;
                RaisePropertyChanged(_strEmployeeId, _oldValue, value, true);
            }
        }

        private const string _strFirstName = "FirstName";
        private string _firstName;
        public string FirstName
        { get { return _firstName; }
            set
            {
                if (_firstName == value)
                {
                    return;
                }
                var _oldValue = value;
                _firstName = value;
                RaisePropertyChanged(_strFirstName, _oldValue, value, true);
            }
        }

        private const string _strLastName = "LastName";
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set {
                if (_lastName == value)
                {
                    return;
                }
                var _oldValue = value;
                _lastName = value;
                RaisePropertyChanged(_strLastName, _oldValue, value, true);
            }
        }
        private const string _strDepartmentId = "DepartmentId";
        private int _departmentId;
        public int DepartmentId
        { get { return _departmentId; }
            set
            {
                if (_departmentId == value)
                {
                    return;
                }
                var _oldValue = value;
                _departmentId = value;
                RaisePropertyChanged(_strDepartmentId, _oldValue, value, true);
            }
        }

        private const string _strEmployee = "employee";
        private Employee _employee;
        public Employee Employee
        {
            get { return _employee; }
            set 
            {
                if(_employee == value)
                {
                    return;
                }
                var _oldValue = value;
                _employee = value;
                RaisePropertyChanged(_strEmployee, _oldValue, value, true);
            }
        }

        private const string _strIsControlEnable = "IsControlEnable";
        private bool _isControlEnable;
        public bool IsControlEnable
        {
            get { return _isControlEnable; }
            set 
            {
                if(_isControlEnable == value)
                {
                    return;
                }
                var _oldValue = value;
                _isControlEnable = value;
                RaisePropertyChanged(_strIsControlEnable,_oldValue,value,true);
            }
        }

        private const string _strIsEditDeleteEnable = "IsEditDeleteEnable";
        private bool _isEditDeleteEnable;
        public bool IsEditDeleteEnable
        {
            get { return _isEditDeleteEnable; }
            set
            {
                if(_isEditDeleteEnable == value)
                {
                    return;
                }
                var _oldValue = value;
                _isEditDeleteEnable = value;
                RaisePropertyChanged(_strIsEditDeleteEnable, _oldValue, value, true);
            }
        }


        #endregion

        #region ListOfBusiness
        private const string strEmployeeCollection = "EmployeeList";
        private ObservableCollection<Employee> _employeeList;

        public ObservableCollection<Employee> EmployeeList
        {
            get { return _employeeList; }
            set
            {
                if(_employeeList == value)
                {
                    return;
                }
                var _oldValue = value;
                _employeeList = value;
                RaisePropertyChanged(strEmployeeCollection, _oldValue, value, true);
            }
        }

        private const string strDeptCollection = "DepartmentList";
        private ObservableCollection<Department> _departmentList;
        public ObservableCollection<Department> DepartmentList
        {
            get { return _departmentList; }
            set
            {
                if (_departmentList == value)
                {
                    return;
                }
                var _oldValue = value;
                _departmentList = value;
                RaisePropertyChanged(strDeptCollection, _oldValue, value, true);
            }
        } 
        #endregion

        #region Events
        public ICommand AddEmployee { get; private set; }

        public ICommand EditEmployee { get; private set; }

        public ICommand SaveEmployee { get; private set; }

        public ICommand DeleteEmployee { get; private set; }


        private void Add()
        {

            try
            {
                IsControlEnable = true;
                IsEditDeleteEnable = false;
                _allowAdd = true;
                Employee = new Employee();
                EmployeeList.Add(Employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void Edit(Employee emp)
        {
            try
            {
                if (emp != null)
                {
                    IsControlEnable = true;
                    _allowEdit = true;
                }
                else
                {
                    MessageBox.Show("Please select a record to edit.", "Message");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Delete(Employee emp)
        {
            try
            {
                var result = MessageBox.Show("Are you sure you want to delete the record(s)?.", "Delete Record", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool res = _iEmployeeRepository.Delete(emp);
                    if (!res)
                        MessageBox.Show("Employee not deleted.");
                    else
                        MessageBox.Show("Employee deleted successfully.");

                    EmployeeList = new ObservableCollection<Employee>();
                    Init();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

             
        }

        private void Save(Employee emp)
        {
            try
            {
                if (emp !=null && emp.EmployeeId !=0 && emp.FirstName!=null && emp.LastName != null)
                {
                    IsControlEnable = false;
                    IsEditDeleteEnable = true;
                    if (_allowAdd)
                    {
                        bool res = _iEmployeeRepository.Create(emp);
                        if (!res)
                            MessageBox.Show("Employee not added.");
                        else
                            MessageBox.Show("Employee added successfully.");

                        _allowAdd = false;
                    }
                    else if (_allowEdit)
                    {
                        bool res = _iEmployeeRepository.Update(emp);
                        if (!res)
                            MessageBox.Show("Employee not updated.");
                        else
                            MessageBox.Show("Employee updated successfully.");

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
                var EmpLst = _iEmployeeRepository.GetAllData().ToList();
                foreach (Employee item in EmpLst)
                {
                    EmployeeList.Add(item);
                }

                var DeptLst = _iDeptRepository.GetAllData().ToList();
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
