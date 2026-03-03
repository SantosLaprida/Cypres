using Cypres2._0.Data.Connection.Access;
using Cypres2._0.Models.ManoDeObra;
using Cypres2._0.ViewModels.ManoDeObra;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cypres2._0.Data.Services.ManoDeObra
{
    public class ManoDeObraService: IManoDeObraService
    {
        private readonly IDatabaseConnection _db;

        public ManoDeObraService(IDatabaseConnection db) 
        {
            _db = db;
        }

        public List<ManoDeObraModel> GetManoDeObra() 
        {
            var result = new List<ManoDeObraModel>();

            using (var connection = _db.GetOpenConnection())
            {
                string query = "SELECT * FROM mano_de_obra";

                using (var command = new OleDbCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ManoDeObraModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Codigo = Convert.ToInt32(reader["Codigo"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            IdUnidad = Convert.ToInt32(reader["IdUnidad"]),
                            IdFamilia = Convert.ToInt32(reader["Id_familia"]),
                            COrigen = reader["C_Origen"] != DBNull.Value
                            ? Convert.ToDouble(reader["C_Origen"])
                            : 0.0,
                            IdMoneda = Convert.ToInt32(reader["Id_moneda"]),
                            CFinal = reader["C_Final"] != DBNull.Value
                            ? Convert.ToDouble(reader["C_Final"])
                            : 0.0,
                            VRef = reader["V_ref"].ToString(),
                            EquiposRef = Convert.ToInt32(reader["Equipos"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            IdBdatos = Convert.ToInt32(reader["Id_bdatos"]),
                            IndiceRedeterminacion = Convert.ToInt32(reader["Indice_redeterminacion"]),
                            Revisado = Convert.ToBoolean(reader["Revisado"]),
                            Calificada = Convert.ToBoolean(reader["Calificada"])
                        });
              
                    }
                }
            }

            return result;
        }

        public List<FamiliaManoDeObraModel> GetFamilias()
        {
            var result = new List<FamiliaManoDeObraModel>();

            using var connection = _db.GetOpenConnection();
            string query = "SELECT * FROM FamiliaManoDeObra";

            using var command = new OleDbCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new FamiliaManoDeObraModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Descripcion = reader["Descripcion"]?.ToString() ?? string.Empty
                });
            }

            return result;
        }

        public List<UnidadesModel> GetUnidades()
        {
        var result = new List<UnidadesModel>();
            using var connection = _db.GetOpenConnection();
            string query = "SELECT * FROM Unidades";

            using var command = new OleDbCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read()) 
            {
                result.Add(new UnidadesModel 
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Descripcion = reader["Descripcion"]?.ToString() ?? string.Empty,
                    Simbolo = reader["Simbolo"]?.ToString() ?? string.Empty,
                    U_Ref = reader["U_Ref"]?.ToString() ?? string.Empty,
                    Equivalencia = Convert.ToInt32(reader["Equivalencia"]),
                    TipoUnidadId = Convert.ToInt32(reader["TipoUnidadId"]),
                    Pre_mat = Convert.ToInt32(reader["Pre_mat"]),
                    Pre_mob = Convert.ToInt32(reader["Pre_mob"]),
                    Pre_maq = Convert.ToInt32(reader["Pre_maq"]),
                    Pre_sub = Convert.ToInt32(reader["Pre_sub"]),
                    Pre_auxtar = Convert.ToInt32(reader["Pre_auxtar"]),
                });
            }

            return result;
        }

        public List<MonedasModel> GetMonedas()
        {
            var result = new List<MonedasModel>();
            using var connection = _db.GetOpenConnection();

            string query = "SELECT * FROM Monedas";

            using var command = new OleDbCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read()) 
            {
                result.Add(new MonedasModel
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Descripcion = reader["Descripcion"]?.ToString() ?? string.Empty,
                    Signo = reader["Signo"]?.ToString() ?? string.Empty,
                    Cotizacion = Convert.ToInt32(reader["Cotizacion"]),
                });
            }
            return result;
        }

        public List<ManoDeObraGridDto> GetManoDeObraRows() 
        {
        var result = new List<ManoDeObraGridDto>();
            using var connection = _db.GetOpenConnection();

        string query = @"
            SELECT m.Id,
                   m.Descripcion,
                   u.Descripcion AS Unidad,
                   mo.Descripcion AS Moneda,
                   m.C_Origen,
                   m.C_Final,
                   m.V_ref,
                   m.Fecha,
                   m.Revisado,
                   m.Calificada
            FROM ManoDeObra m
            LEFT JOIN Unidades u ON m.UnidadId = u.Id
            LEFT JOIN Monedas mo ON m.MonedaId = mo.Id";

            using var command = new OleDbCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new ManoDeObraGridDto
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Codigo = Convert.ToInt32(reader["Codigo"]),
                    Descripcion = reader["Descripcion"]?.ToString() ?? string.Empty,
                    Unidad = reader["Unidad"]?.ToString() ?? string.Empty,
                    Moneda = reader["Moneda"]?.ToString() ?? string.Empty,
                    COrigen = reader["C_Origen"] != DBNull.Value ? Convert.ToDouble(reader["C_Origen"]) : 0,
                    CFinal = reader["C_Final"] != DBNull.Value ? Convert.ToDouble(reader["C_Final"]) : 0,
                    VRef = reader["V_ref"]?.ToString() ?? string.Empty,
                    Fecha = reader["Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha"]) : DateTime.MinValue,
                    Revisado = reader["Revisado"] != DBNull.Value && Convert.ToBoolean(reader["Revisado"]),
                    Calificada = reader["Revisado"] != DBNull.Value && Convert.ToBoolean(reader["Calificada"])
                });
            }
            return result;
        }

        public void Add(ManoDeObraModel item)
        {
            throw new NotImplementedException();
        }

        public void Update(ManoDeObraModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
