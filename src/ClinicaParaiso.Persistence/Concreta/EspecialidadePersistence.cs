using ClinicaParaiso.Domain.Models;
using ClinicaParaiso.Persistence.Data;
using ClinicaParaiso.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicaParaiso.Persistence.Concreta
{
    public class EspecialidadePersistence : DefaultPersistence, IEspecialidadePersistence
    {
        private readonly ClinicaParaisoContext context;

        public EspecialidadePersistence(ClinicaParaisoContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Especialidade>> GetAllEspecialidadeAsync()
        {
            IQueryable<Especialidade> query = context.especialidades;

            return await query.ToListAsync();
        }
    }
}
