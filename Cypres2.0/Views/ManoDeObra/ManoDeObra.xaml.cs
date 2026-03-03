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
            // Temporary to check data base connection
            TestDatabaseConnection();
            var connection = new DatabaseConnection();
            _service = new ManoDeObraService(connection);
            PrintManoDeObra();
        }

        private void PrintManoDeObra()
        {
            var manoDeObraList = _service.GetManoDeObra();

            foreach (var item in manoDeObraList)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Id: {item.Id} | " +
                    $"Codigo: {item.Codigo} | " +
                    $"Descripcion: {item.Descripcion} | " +
                    $"Familia: {item.IdFamilia} | " +
                    $"Unidad: {item.IdUnidad}"
                );
            }
        }

        private void TestDatabaseConnection()
        {
            var dbConn = new DatabaseConnection();

            bool success = dbConn.TestConnection(out string errorMessage);

            if (success)
            {
                MessageBox.Show(
                    "Connection successful!\n\n" +
                    "The WPF app can now reach Cypres2.0.accdb.\n" +
                    "Path used: " + dbConn.ConnectionString.Replace("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=", ""),
                    "Database Connected",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

                // Optional: If you have a table ready, test a quick query
                // try
                // {
                //     int count = dbConn.GetTableRowCount("tblYourTableNameHere");  // Change to real table name
                //     MessageBox.Show($"Your table has {count} records.", "Quick Check");
                // }
                // catch (Exception ex)
                // {
                //     MessageBox.Show($"Connection OK, but query failed: {ex.Message}", "Query Info");
                // }
            }
            else
            {
                MessageBox.Show(
                    $"Connection failed:\n\n{errorMessage}\n\n" +
                    "Common fixes:\n" +
                    "1. Check bitness (Project Properties → Build → Platform target: try x64)\n" +
                    "2. Confirm file copied to bin/Debug/.../Data/access/\n" +
                    "3. Reinstall Microsoft 365 Access Runtime (x64 if Any CPU/x64 project)",
                    "Connection Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
    }
}
