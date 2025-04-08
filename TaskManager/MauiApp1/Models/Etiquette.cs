using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Etiquette
{
    [Key]
    public int Id { get; set; }
    public string Nom { get; set; }

    // Navigation properties
    public List<Tache> Taches { get; set; } = new List<Tache>();
}
