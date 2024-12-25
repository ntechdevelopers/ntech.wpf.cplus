using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SampleWpfDataGrid
{
    /// <summary>
    /// Interaction logic for CustomDataGrid.xaml
    /// </summary>
    public partial class CustomDataGrid : Microsoft.Windows.Controls.DataGrid
    {
        public CustomDataGrid()
        {
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return base.OnCreateAutomationPeer();
        }
    }
}
