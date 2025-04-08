using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Commentaire
{
    [Key]
    public int Id { get; set; }
    public int TacheId { get; set; }
    [ForeignKey("TacheId")]
    public Tache Tache { get; set; }
    public int AuteurId { get; set; }
    [ForeignKey("AuteurId")]
    public Utilisateur Auteur { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string Contenu { get; set; }
}
