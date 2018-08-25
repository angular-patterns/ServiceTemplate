
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class DataContext: DbContext
    {


        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
