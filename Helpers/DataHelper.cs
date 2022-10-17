using ContactApp.Data;
using Microsoft.EntityFrameworkCore;
namespace ContactApp.Helpers
{
    public static class DataHelper
    {
        public static async Task ManageDataAsync(IServiceProvider svcProvider)
        {
            //get an instance of the db application context
            var dbContextSvc = svcProvider.GetRequiredService<ApplicationDbContext>();
            //migration this is the equivalent to update database
            await dbContextSvc.Database.MigrateAsync();
        }
    }
}
