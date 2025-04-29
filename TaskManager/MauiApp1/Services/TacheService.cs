using Microsoft.EntityFrameworkCore;
using MauiApp1.Models;
using MauiApp1.Data;

namespace MauiApp1.Services
{
    public class TacheService
    {
        private readonly AppDbContext _context;

        public TacheService(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<List<Tache>> GetTachesAsync()
        {
            return await _context.Taches.ToListAsync();
        }

        public async Task<Tache?> GetTacheByIdAsync(int id)
        {
            return await _context.Taches.FindAsync(id);
        }

        public async Task UpdateTacheAsync(Tache tache)
        {
            _context.Taches.Update(tache);
            await _context.SaveChangesAsync();
        }
    }
}
