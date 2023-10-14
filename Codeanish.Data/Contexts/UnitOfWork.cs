namespace Codeanish.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;
    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
        Blogs = new BlogRepository(_context);
        Posts = new GenericRepository<Post>(_context);
    }

    public IBlogRepository Blogs { get; private set; }
    public IGenericRepository<Post> Posts { get; private set; }
    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
