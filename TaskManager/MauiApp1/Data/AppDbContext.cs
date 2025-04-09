using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Tache> Taches { get; set; }
    public DbSet<Utilisateur> Utilisateurs { get; set; }
    public DbSet<Commentaire> Commentaires { get; set; }
    public DbSet<Etiquette> Etiquettes { get; set; }
    public DbSet<SousTache> SousTaches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql("server=localhost;database=taskmasterdb;user=root;",
            new MySqlServerVersion(new Version(8, 0, 31)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tache>()
            .HasMany(t => t.SousTaches)
            .WithOne(st => st.Tache)
            .HasForeignKey(st => st.TacheId);

        modelBuilder.Entity<Tache>()
            .HasMany(t => t.Commentaires)
            .WithOne(c => c.Tache)
            .HasForeignKey(c => c.TacheId);

        modelBuilder.Entity<Tache>()
            .HasMany(t => t.Etiquettes)
            .WithMany(e => e.Taches);

        modelBuilder.Entity<Tache>()
            .HasOne(t => t.Auteur)
            .WithMany(u => u.TachesCreees)
            .HasForeignKey(t => t.AuteurId);

        modelBuilder.Entity<Tache>()
            .HasOne(t => t.Realisateur)
            .WithMany(u => u.TachesAssignees)
            .HasForeignKey(t => t.RealisateurId);
    }
}
