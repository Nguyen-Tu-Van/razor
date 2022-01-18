using Microsoft.EntityFrameworkCore;

namespace RazorEntity.Models
{
    public class MyBlogContext: DbContext
    {
        public DbSet<Article> articles { get; set; }

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Debug);

            builder.AddConsole();
        }
       );
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var datasource = @"LAPTOP-8B5D80O8\SQLEXPRESS";//your server
            var database = "Blog"; //your database name
            var username = "sa"; //username of server to connect
            var password = "123456"; //password

            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";TrustServerCertificate=True;User ID=" + username + ";Password=" + password;

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory).UseSqlServer(connString);
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tạo index , mối quan hệ 
            base.OnModelCreating(modelBuilder);

            // Các Fluent API
            /*modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(p => p.Category).WithMany(c => c.products)
                .OnDelete(DeleteBehavior.SetNull)            // Ứng xử khi User bị xóa (Hoặc chọn DeleteBehavior.Cascade)
                .HasConstraintName("FK_Products_user_1234"); ;
            });*/

        }
    }
}
