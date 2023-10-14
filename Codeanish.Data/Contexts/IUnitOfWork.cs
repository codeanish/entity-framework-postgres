namespace Codeanish.Data;

public interface IUnitOfWork : IDisposable
{
    IBlogRepository Blogs {get; }
    IGenericRepository<Post> Posts {get; }
    int Complete();
}
