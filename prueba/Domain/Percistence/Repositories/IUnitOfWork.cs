namespace prueba.Domain.Percistence.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();   
    }
}
