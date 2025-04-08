using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Tache
{
    [Key]
    public int Id { get; set; }
    public string Titre { get; set; }
    public string Description { get; set; }
    public DateTime DateCreation { get; set; } = DateTime.Now;
    public DateTime? Echeance { get; set; }
    public string Statut { get; set; } = "à faire"; // "à faire", "en cours", "terminée", "annulée"
    public string Priorite { get; set; } = "moyenne"; // "basse", "moyenne", "haute", "critique"
    public string Categorie { get; set; } // perso, travail, projet, etc.

    // Foreign keys
    public int AuteurId { get; set; }
    [ForeignKey("AuteurId")]
    public Utilisateur Auteur { get; set; }

    public int RealisateurId { get; set; }
    [ForeignKey("RealisateurId")]
    public Utilisateur Realisateur { get; set; }

    // Navigation properties
    public List<Etiquette> Etiquettes { get; set; } = new List<Etiquette>();
    public List<SousTache> SousTaches { get; set; } = new List<SousTache>();
    public List<Commentaire> Commentaires { get; set; } = new List<Commentaire>();
}
