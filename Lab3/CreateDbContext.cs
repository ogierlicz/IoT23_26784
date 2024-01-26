using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Lab1.Database;

public class DatabaseContextContextFactory : IDesignTimeDbContextFactory<PeopleDb>
{
    public PeopleDb CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PeopleDb>();
        optionsBuilder.UseSqlServer("Server=tcp:iot23dbserver.database.windows.net,1433;Initial Catalog=iot23db;Persist Security Info=False;User ID=ogierlicz;Password=1@qwerty;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        return new PeopleDb(optionsBuilder.Options);
    }
}