using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ToDoList.Infra.Data.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var _connectionString = "Server=localhost;Database=ToDoAPI;Uid=juliano;Pwd=Senh@Forte12;";
        
        optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}