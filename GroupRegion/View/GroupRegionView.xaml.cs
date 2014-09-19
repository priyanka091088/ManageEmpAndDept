using GroupRegion.ViewModel;
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

namespace GroupRegion.View
{
    /// <summary>
    /// Interaction logic for GroupRegionView.xaml
    /// </summary>
    public partial class GroupRegionView : UserControl
    {
        public GroupRegionView(IUnityContainer container)
        {
            InitializeComponent();
            this.DataContext = container.Resolve<GroupRegionViewModel>();
        }
    }
}
