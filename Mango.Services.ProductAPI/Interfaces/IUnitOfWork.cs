namespace Mango.Services.ProductAPI.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository {get;}
        Task<Boolean> Complete();
        bool HasChanges();
    }
}