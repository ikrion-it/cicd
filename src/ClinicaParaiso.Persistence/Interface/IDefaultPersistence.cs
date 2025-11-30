namespace ClinicaParaiso.Persistence.Interface
{
    public interface IDefaultPersistence
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
