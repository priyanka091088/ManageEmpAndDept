using EmployeeDtlRegion.ViewModel;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeDtlRegion.View
{
    /// <summary>
    /// Interaction logic for EmployeeDtlRegionView.xaml
    /// </summary>
    public partial class EmployeeDtlRegionView : UserControl
    {
        public EmployeeDtlRegionView(IUnityContainer container)
        {
            InitializeComponent();
            this.DataContext = container.Resolve<EmployeeDtlViewModel>();
        }

    }
}
