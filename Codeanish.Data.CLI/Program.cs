
using Codeanish.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class Program 
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);   
        var serviceProvider = services.BuildServiceProvider();
        using(var unitOfWork = serviceProvider.GetService<IUnitOfWork>())
        {
            // var blog = new Blog { Url = "https://www.codeanish.com" };
            // unitOfWork.Blogs.Add(blog);
            var blog = unitOfWork.Blogs.GetById(1);
            var post1 = new Post { Title = "Test Post 1", Content = "Test Content 1", Blog = blog};
            var post2 = new Post { Title = "Test Post 2", Content = "Test Content 2", Blog = blog};
            unitOfWork.Posts.Add(post1);
            unitOfWork.Posts.Add(post2);
            unitOfWork.Complete();
            var post = unitOfWork.Blogs.GetLatestPost(blog.BlogId);
            Console.WriteLine(post.Title);
        }
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>(options => options
            .UseNpgsql($"Host=localhost;Database=test_db;Username=test_user;Password=test_password")
            .UseSnakeCaseNamingConvention());
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}