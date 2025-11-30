using ClinicaParaiso.Persistence.Data;
using ClinicaParaiso.Persistence.Interface;

namespace ClinicaParaiso.Persistence.Concreta
{
    public class DefaultPersistence : IDefaultPersistence
    {
        private readonly ClinicaParaisoContext context;

        public DefaultPersistence(ClinicaParaisoContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
    }
}
