using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Utilisateur
{
    [Key]
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }

    // Navigation properties
    public List<Tache> TachesCreees { get; set; } = new List<Tache>();
    public List<Tache> TachesAssignees { get; set; } = new List<Tache>();
}
