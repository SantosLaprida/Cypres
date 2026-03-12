using Cypres2._0.Data.Connection.Access;
using Cypres2._0.Data.Services.ManoDeObra;
using Cypres2._0.Models.ManoDeObra;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cypres2._0.ViewModels.ManoDeObra
{
    public class ManoDeObraViewModel : BaseViewModel
    {
        private readonly IManoDeObraService _manoDeObraService;

        private List<FamiliaManoDeObraModel> _allFamilias = new();
        private List<ManoDeObraGridDto> _allRows = new();
        private FamiliaManoDeObraModel _selectedFamilia;
        public FamiliaManoDeObraModel SelectedFamilia
        {
            get => _selectedFamilia;
            set
            {
                _selectedFamilia = value;
                OnPropertyChanged(nameof(SelectedFamilia));
                FilterGrid();
            }
        }
        public ObservableCollection<ManoDeObraModel> ManoDeObra { get; set; }
        public ObservableCollection<FamiliaManoDeObraModel> FamiliaManoDeObra { get; set; }
        public ObservableCollection<ManoDeObraGridDto> ManoDeObraGridDto { get; set; }
        public ICommand LoadCommand { get; }
        public ICommand ListadoGeneralCommand { get; }
        public ManoDeObraViewModel(IManoDeObraService manoDeObraService)
        {
            _manoDeObraService = manoDeObraService;
            ManoDeObra = new ObservableCollection<ManoDeObraModel>();
            FamiliaManoDeObra = new ObservableCollection<FamiliaManoDeObraModel>();
            ManoDeObraGridDto = new ObservableCollection<ManoDeObraGridDto>();
            LoadCommand = new RelayCommand(Load);
            ListadoGeneralCommand = new RelayCommand(ShowAllFamilias);
            Load();
        }

        private void Load()
        {
            try
            {
                var manoDeObra = _manoDeObraService.GetManoDeObra();
                var familias = _manoDeObraService.GetFamilias();
                _allFamilias = familias;
                var manoDeObraRows = _manoDeObraService.GetManoDeObraRows();
                _allRows = manoDeObraRows;

                FamiliaManoDeObra.Clear();
                ManoDeObra.Clear();
                ManoDeObraGridDto.Clear();

                foreach (var item in manoDeObra)
                    ManoDeObra.Add(item);
                foreach (var item in familias)
                    FamiliaManoDeObra.Add(item);
                foreach (var item in manoDeObraRows)
                    ManoDeObraGridDto.Add(item);
            }
            catch (Exception ex)
            {
                // later replace with proper logging
                //System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Windows.MessageBox.Show(ex.Message, "Error");
            }
        }

        private void FilterFamilias() 
        {
            if (_selectedFamilia == null) return;
            FamiliaManoDeObra.Clear();
            FamiliaManoDeObra.Add(_selectedFamilia);
            FilterGrid();
        }

        private void ShowAllFamilias() 
        {
            SelectedFamilia = null;
            FilterGrid();
        }

        private void FilterGrid() 
        {
            if (_selectedFamilia == null) 
            {
                ManoDeObraGridDto.Clear();
                foreach (var item in _allRows)
                    ManoDeObraGridDto.Add(item);
                return;
            }
            
            ManoDeObraGridDto.Clear();
            foreach (var item in _allRows) 
                if (item.IdFamilia == _selectedFamilia.Id) ManoDeObraGridDto.Add(item);
        }
    }
}
