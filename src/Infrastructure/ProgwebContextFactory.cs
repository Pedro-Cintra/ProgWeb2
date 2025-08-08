using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Infrastructure.Data;

public class ProgwebContextFactory : IDesignTimeDbContextFactory<progwebContext>
{
    public progwebContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<progwebContext>();

        builder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=mysecretpassword");

        return new progwebContext(builder.Options);
    }
}