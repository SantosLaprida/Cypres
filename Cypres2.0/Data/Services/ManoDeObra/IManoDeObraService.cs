using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Cypres2._0.Models.ManoDeObra;
using Cypres2._0.Data.Connection;
using Cypres2._0.ViewModels.ManoDeObra;

namespace Cypres2._0.Data.Services.ManoDeObra
{
    public interface IManoDeObraService
    {
        List<ManoDeObraModel> GetManoDeObra();
        List<FamiliaManoDeObraModel> GetFamilias();
        List<UnidadesModel> GetUnidades();
        List<MonedasModel> GetMonedas();
        List<ManoDeObraGridDto> GetManoDeObraRows();

        void UnassignFamilia(int familiaId);
        void DeleteFamilia(int familiaId);

        void AddFamilia(FamiliaManoDeObraModel familia);
        void UpdateFamilia(FamiliaManoDeObraModel familia);

        void Add(ManoDeObraModel item);
        void Update(ManoDeObraModel item);
        void Delete(int id);
    }
}
