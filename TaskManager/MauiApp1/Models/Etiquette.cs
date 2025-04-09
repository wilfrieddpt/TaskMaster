using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MauiApp1.Models;

public class Etiquette
{
    [Key]
    public int Id { get; set; }
    public string Nom { get; set; }

    // Navigation properties
    public List<Tache> Taches { get; set; } = new List<Tache>();
}
