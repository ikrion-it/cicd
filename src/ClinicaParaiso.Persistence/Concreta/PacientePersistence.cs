using ClinicaParaiso.Domain.Models;
using ClinicaParaiso.Persistence.Data;
using ClinicaParaiso.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicaParaiso.Persistence.Concreta
{
    public class PacientePersistence : DefaultPersistence, IPacientePersistence
    {
        private readonly ClinicaParaisoContext context;

        public PacientePersistence(ClinicaParaisoContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Paciente>> GetallPacientesAsync(string cpf = "")
        {
            IQueryable<Paciente> query = context.pacientes;

            if (!string.IsNullOrEmpty(cpf))
            {
                query = query.Where(x => x.Cpf.Contains(cpf));
            }

            return await query.ToListAsync();
        }

        public async Task<Paciente> GetPacienteByCpfAsync(string cpf, bool showLastAtendimento)
        {
            IQueryable<Paciente> query = context.pacientes;

            if (showLastAtendimento)
            {
                query = query
                    .Include(p => p.Atendimentos
                    .OrderByDescending(a => a.DataHoraChegada)
                    .Take(1));
            }

            query = query.Where(x => x.Cpf == cpf);

            return await query.FirstOrDefaultAsync();
        }
    }
}
