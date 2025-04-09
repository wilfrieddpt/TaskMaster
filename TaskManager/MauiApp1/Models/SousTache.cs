using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MauiApp1.Models;

public class SousTache
{
    [Key]
    public int Id { get; set; }
    public int TacheId { get; set; }
    [ForeignKey("TacheId")]
    public Tache Tache { get; set; }
    public string Titre { get; set; }
    public string Statut { get; set; } = "� faire"; // "� faire", "en cours", "termin�e", "annul�e"
    public DateTime? Echeance { get; set; }
}
