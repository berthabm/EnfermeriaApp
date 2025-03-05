using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using EnfermeriaApp.Models;

namespace EnfermeriaApp.Repositories
{
    public class AsignaturaRepository
    {
        private readonly string _connectionString;

        public AsignaturaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Asignatura> ObtenerAsignaturas(int page, int pageSize, out int totalRegistros)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT COUNT(*) FROM TAsignaturas a
                    INNER JOIN TProgramasAsignaturas pa ON a.IdAsignatura = pa.IdAsignatura
                    INNER JOIN TProgramas p ON pa.IdPrograma = p.IdPrograma
                    WHERE p.CodPrograma = 'G1G011';";

                totalRegistros = connection.ExecuteScalar<int>(query);

                query = @"
                    SELECT 
                        a.CodAsignatura, 
                        a.Asignatura AS AsignaturaNombre, 
                        a.ECTS, 
                        a.Horas,
                        p.Programa
                    FROM TAsignaturas a
                    INNER JOIN TProgramasAsignaturas pa ON a.IdAsignatura = pa.IdAsignatura
                    INNER JOIN TProgramas p ON pa.IdPrograma = p.IdPrograma
                    WHERE p.CodPrograma = 'G1G011'
                    ORDER BY a.CodAsignatura
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

                return connection.Query<Asignatura>(query, new { Offset = (page - 1) * pageSize, PageSize = pageSize });
            }
        }


    }
}
