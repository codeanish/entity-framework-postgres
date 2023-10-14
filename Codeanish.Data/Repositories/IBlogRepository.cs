namespace Codeanish.Data;

public interface IBlogRepository : IGenericRepository<Blog>
{
    Post GetLatestPost(int blogId);
}
