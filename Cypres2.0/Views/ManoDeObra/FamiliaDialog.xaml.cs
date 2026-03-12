using Cypres2._0.Data.Services.ManoDeObra;
using Cypres2._0.Models.ManoDeObra;
using Cypres2._0.ViewModels.ManoDeObra;
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
using System.Windows.Shapes;

namespace Cypres2._0.Views.ManoDeObra
{
    /// <summary>
    /// Interaction logic for FamiliaDialog.xaml
    /// </summary>
    public partial class FamiliaDialog : Window
    {
        public FamiliaDialog(FamiliaManoDeObraModel familia, IManoDeObraService service)
        {
            InitializeComponent();
            DataContext = new FamiliaDialogViewModel(familia, service, () =>
            {
                DialogResult = true;
                Close();
            });
        }

        // constructor for Crear
        public FamiliaDialog(IManoDeObraService service)
        {
            InitializeComponent();
            DataContext = new FamiliaDialogViewModel(service, () =>
            {
                DialogResult = true;
                Close();
            });
        }
    }
}
