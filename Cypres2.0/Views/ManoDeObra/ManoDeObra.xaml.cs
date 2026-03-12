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

using WPFLocalizeExtension.Engine;
using Cypres2._0.Data.Connection.Access;
using Cypres2._0.Data.Services.ManoDeObra;
using Cypres2._0.ViewModels.ManoDeObra;

namespace Cypres2._0.Views.ManoDeObra
{
    /// <summary>
    /// Interaction logic for ManoDeObra.xaml
    /// </summary>
    public partial class ManoDeObra : Window
    {

        private readonly ManoDeObraService _service;

        public ManoDeObra()
        {
            InitializeComponent();
            //Temporary, this line is going to be on the main window of the application
            LocalizeDictionary.Instance.Culture = new System.Globalization.CultureInfo("es");
            var connection = new DatabaseConnection();
            var service = new ManoDeObraService(connection);
            DataContext = new ManoDeObraViewModel(service);
        }

    }
}
