using EnfermeriaApp.Models;
using EnfermeriaApp.Repositories;
using System.Collections.Generic;

namespace EnfermeriaApp.Services
{
    public class AsignaturaService
    {
        private readonly AsignaturaRepository _repository;

        public AsignaturaService(AsignaturaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Asignatura> ObtenerAsignaturas(int page, int pageSize, out int totalRegistros)
        {
            return _repository.ObtenerAsignaturas(page, pageSize, out totalRegistros);
        }
    }
}
