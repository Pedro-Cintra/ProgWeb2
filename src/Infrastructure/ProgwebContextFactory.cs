using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Infrastructure.Data;  // ajuste o namespace para onde está seu DbContext

public class ProgwebContextFactory : IDesignTimeDbContextFactory<progwebContext>
{
    public progwebContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<progwebContext>();

        // copie a mesma connection string que está no appsettings ou nas variáveis:
        builder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=mysecretpassword");

        return new progwebContext(builder.Options);
    }
}