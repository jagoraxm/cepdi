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
        public DbSet<Models.FormasFarmaceuticasClass> FormasFarmaceuticas {get;set;}   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación entre Medicamentos y FormasFarmaceuticasClass
            modelBuilder.Entity<Models.Medicamentos>()
                .HasOne(m => m.FormaFarmaceutica) // Propiedad de navegación en Medicamentos
                .WithMany(f => f.Medicamentoss)   // Propiedad de navegación en FormasFarmaceuticasClass
                .HasForeignKey(m => m.idformafarmaceutica) // Clave foránea en Medicamentos
                .HasConstraintName("FK_Medicamentos_FormasFarmaceuticasClass"); // Nombre opcional para la restricción
        }   
    }
}