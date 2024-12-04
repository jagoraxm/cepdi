using Microsoft.EntityFrameworkCore;

namespace WebAPICepdi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        :base(options)
        {

        }  

        public DbSet<Models.Usuarios> Usuarios {get;set;} 

        public DbSet<Models.Medicamentos> Medicamentos {get;set;}       
    }
}