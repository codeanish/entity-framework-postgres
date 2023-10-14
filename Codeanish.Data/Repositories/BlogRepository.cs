using System.Linq.Expressions;

namespace Codeanish.Data;

public class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    public BlogRepository(ApplicationContext context) : base(context) { }

    public Post GetLatestPost(int blogId)
    {
        return _context.Posts.Where(p => p.BlogId == blogId).OrderByDescending(p => p.PostId).FirstOrDefault();
    }
}
