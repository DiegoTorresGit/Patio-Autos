using arquetipo.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquetipo.Test.DbCache
{
    public class ContextC
    {
        protected BlogContext dbcontext;

        public ContextC()
        {

            var cacheContext = new DbContextOptionsBuilder<BlogContext>().UseInMemoryDatabase("Pruebas").Options;
            dbcontext = new BlogContext(cacheContext);
        }

    }
}
