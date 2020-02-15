using Microsoft.EntityFrameworkCore;

namespace testpfe.Models
{

    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        //instance liée à la classe TodoItems(on peut gérer le BD à l'aide de cette instance)
        public DbSet<Etudiant> TodoItems { get; set; }

       //instance liée à la classe Etudiant(on peut gérer le BD à l'aide de cette instance)
      // public DbSet<Etudiant> Etudiant {get;set;}

        
    }
}