using Microsoft.EntityFrameworkCore;

namespace src.HelloWorld
{
    public class dbContextHandler
    {
        public EFContext ConfigureDB()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
                      .UseInMemoryDatabase(databaseName: "BasketDB")
                      .Options;
            var context = new EFContext(options);

            return context;
        }
    }
}