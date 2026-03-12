using Cypres2._0.Data.Services.ManoDeObra;
using Cypres2._0.Models.ManoDeObra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cypres2._0.ViewModels.ManoDeObra
{
    public enum FamiliaDialogMode
    {
        Crear,
        Editar
    }
    class FamiliaDialogViewModel : BaseViewModel
    {
        private readonly IManoDeObraService _service;
        private readonly Action _closeDialog;
        private readonly FamiliaDialogMode _mode;
        private readonly FamiliaManoDeObraModel _familia;

        private string _descripcion;
        public String Descripcion
        {
            get => _descripcion;
            set
            {
                _descripcion = value;
                OnPropertyChanged(nameof(Descripcion));
            }
        }

        public string Title => _mode == FamiliaDialogMode.Editar
        //TODO LOCALIZE
        ? "Modificar Familia de Mano de Obra"
        : "Crear Familia de Mano de Obra";

        public ICommand AceptarCommand { get; }
        public ICommand TerminarCommand { get; }
    

    // constructor for EDITAR
    public FamiliaDialogViewModel(FamiliaManoDeObraModel familia,
                                   IManoDeObraService service,
                                   Action closeDialog)
        {
            _familia = familia;
            _service = service;
            _closeDialog = closeDialog;
            _mode = FamiliaDialogMode.Editar;
            Descripcion = familia.Descripcion;

            AceptarCommand = new RelayCommand(Aceptar);
            TerminarCommand = new RelayCommand(Terminar);
        }

        // constructor for CREAR
        public FamiliaDialogViewModel(IManoDeObraService service, Action closeDialog)
        {
            _service = service;
            _closeDialog = closeDialog;
            _mode = FamiliaDialogMode.Crear;
            _familia = new FamiliaManoDeObraModel();
            Descripcion = string.Empty;

            AceptarCommand = new RelayCommand(Aceptar);
            TerminarCommand = new RelayCommand(Terminar);
        }

        private void Aceptar()
        {
            _familia.Descripcion = Descripcion;
            if (_mode == FamiliaDialogMode.Editar)
                _service.UpdateFamilia(_familia);
            else
                _service.AddFamilia(_familia);
            _closeDialog();
        }

        private void Terminar() => _closeDialog();
    }
}
