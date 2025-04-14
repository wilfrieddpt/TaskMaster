using Microsoft.EntityFrameworkCore;
using MauiApp1.Data;

namespace MauiApp1.back_end.Services;
public interface IUserService
{
    Task<bool> RegisterAsync(string email, string password, string nom, string prenom);
    Task<bool> LoginAsync(string email, string password);
}

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterAsync(string email, string password, string nom, string prenom)
    {
        if (_context.Utilisateurs.Any(u => u.Email == email))
            return false;

        var utilisateur = new Utilisateur
        {
            Email = email,
            Password = password, // Stocke le mot de passe en clair
            Nom = nom,
            Prenom = prenom
        };

        _context.Utilisateurs.Add(utilisateur);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Email == email);
        if (utilisateur == null || utilisateur.Password != password)
            return false;

        return true;
    }
}

