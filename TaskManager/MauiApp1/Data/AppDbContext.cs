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
        options.UseMySql("server=localhost;database=taskmasterdb;user=root;password=root;",
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

public class Tache
{
    public int Id { get; set; }
    public string Titre { get; set; }
    public string Description { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime? Echeance { get; set; }
    public string Statut { get; set; }
    public string Priorite { get; set; }
    public int AuteurId { get; set; }
    public Utilisateur Auteur { get; set; }
    public int RealisateurId { get; set; }
    public Utilisateur Realisateur { get; set; }
    public string Categorie { get; set; }
    public List<Etiquette> Etiquettes { get; set; }
    public List<SousTache> SousTaches { get; set; }
    public List<Commentaire> Commentaires { get; set; }
}

public class Utilisateur
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public List<Tache> TachesCreees { get; set; }
    public List<Tache> TachesAssignees { get; set; }
}

public class Commentaire
{
    public int Id { get; set; }
    public int TacheId { get; set; }
    public Tache Tache { get; set; }
    public int AuteurId { get; set; }
    public Utilisateur Auteur { get; set; }
    public DateTime Date { get; set; }
    public string Contenu { get; set; }
}

public class Etiquette
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public List<Tache> Taches { get; set; }
}

public class SousTache
{
    public int Id { get; set; }
    public int TacheId { get; set; }
    public Tache Tache { get; set; }
    public string Titre { get; set; }
    public string Statut { get; set; }
    public DateTime? Echeance { get; set; }
}
