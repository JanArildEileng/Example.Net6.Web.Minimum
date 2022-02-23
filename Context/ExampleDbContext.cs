using Microsoft.EntityFrameworkCore;

namespace ExampleContext;
public class ExampleDbContext :DbContext {
  
     public DbSet<ExampleEntity>? ExampleEntity { get; set; }

    public ExampleDbContext(DbContextOptions<ExampleDbContext> option ) : base(option)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<ExampleEntity>()
         .HasKey(e=>e.Id);
     
        modelBuilder.Entity<ExampleEntity>().HasData(
            new ExampleEntity {Id=1},
            new ExampleEntity {Id=2}
            );
    }
       

}


public class ExampleEntity {

    public int Id { get; set; }
    public Guid Guid { get; init; }=Guid.NewGuid();
    public DateTime  Created { get; init; }=DateTime.Now;
   
    public  override string ToString() {
        return $"{Id}  {Created}  {Guid}  ";
    }
}
