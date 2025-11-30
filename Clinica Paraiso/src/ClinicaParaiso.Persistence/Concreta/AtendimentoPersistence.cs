using ClinicaParaiso.Domain.Models;
using ClinicaParaiso.Persistence.Data;
using ClinicaParaiso.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicaParaiso.Persistence.Concreta
{
    public class AtendimentoPersistence : DefaultPersistence, IAtendimentoPersistence
    {
        private readonly ClinicaParaisoContext context;

        public AtendimentoPersistence(ClinicaParaisoContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Atendimento>> GetAllAtendimentosAsync(string status = "")
        {
            IQueryable<Atendimento> query = context.atendimentos
                .Include(x => x.Paciente) ;

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(x => x.Status == status);
            }

            
            query = query.OrderBy(x => x.DataHoraChegada);

            return await query.ToListAsync();
        }

        public async Task<Atendimento?> GetAtendimentoByIdAsync(int atendimentoId)
        {
            IQueryable<Atendimento> query = context.atendimentos
                .Where(x => x.Id == atendimentoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
