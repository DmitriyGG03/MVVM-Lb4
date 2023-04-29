using Microsoft.EntityFrameworkCore;

namespace MVVM_Lb4.EF;

public class ApplicationDbContextFactory
{
    private readonly DbContextOptions _options;

    public ApplicationDbContextFactory(DbContextOptions options)
    {
        _options = options;
    }

    public ApplicationDbContext Create()
    {
        return new ApplicationDbContext(_options);
    }
}