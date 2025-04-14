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
        }

        public async Task<List<Tache>> GetTachesAsync()
        {
            return await _context.Taches.ToListAsync();
        }
    }
}
