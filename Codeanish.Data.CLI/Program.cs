
using Codeanish.Data;

public class Program 
{
    public static void Main(string[] args)
    {
        using var db = new BloggingContext($"Host=localhost;Database=test_db;Username=test_user;Password=test_password");
        db.Database.EnsureCreated();
        db.Blogs.Add(new Blog { Url = "https://www.codeanish.com" });
        db.SaveChanges();
        var codeanishBlog = db.Blogs.FirstOrDefault(b => b.Url == "https://www.codeanish.com");
        db.Posts.Add(new Post { Title = "Test Post 2", Content = "Test Content 2", Blog = codeanishBlog});
        db.SaveChanges();
        foreach(var post in db.Posts)
        {
            Console.WriteLine(post.Title);
        }
    }
}