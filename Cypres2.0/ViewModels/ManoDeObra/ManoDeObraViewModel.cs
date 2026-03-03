using Cypres2._0.Data.Connection.Access;
using Cypres2._0.Data.Services.ManoDeObra;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cypres2._0.ViewModels.ManoDeObra
{
    public class ManoDeObraViewModel: BaseViewModel
    {
        private readonly IManoDeObraService _manoDeObraService;
        public ObservableCollection<Models.ManoDeObra.ManoDeObraModel> ManoDeObra { get; set; }
        public ObservableCollection<Models.ManoDeObra.FamiliaManoDeObraModel> FamiliaManoDeObra { get; set; }

        public ICommand LoadCommand { get; }

        public ManoDeObraViewModel(IManoDeObraService manoDeObraService) 
        {
            _manoDeObraService = manoDeObraService;
            ManoDeObra = new ObservableCollection<Models.ManoDeObra.ManoDeObraModel>();
            FamiliaManoDeObra = new ObservableCollection<Models.ManoDeObra.FamiliaManoDeObraModel>();
            LoadCommand = new RelayCommand(Load);
        }

        private void Load()
        {
            try
            {
                var data = _manoDeObraService.GetManoDeObra();

                ManoDeObra.Clear();

                foreach (var item in data)
                    ManoDeObra.Add(item);
            }
            catch (Exception ex)
            {
                // later replace with proper logging
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

    }
}
