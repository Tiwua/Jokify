namespace Jokify.UnitTests.Mock
{
    using Jokify.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DbMock
    {
        public static JokifyDbContext Instance
        {
            get
            {
                var contextOptions = new DbContextOptionsBuilder<JokifyDbContext>()
                .UseInMemoryDatabase("Jokify" + new Guid().ToString())
                .Options;



                return new JokifyDbContext(contextOptions);
            }
        }


    }
}
