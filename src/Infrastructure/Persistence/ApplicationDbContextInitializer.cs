using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContextInitializer(ApplicationDbContext context)
{
    public async Task InitialiseAsync()
    {
        if (EF.IsDesignTime)
        {
            return;
        }

        await context.Database.MigrateAsync();
    }
}