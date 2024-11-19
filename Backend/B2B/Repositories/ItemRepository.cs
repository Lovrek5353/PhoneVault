using Microsoft.EntityFrameworkCore;
using PhoneVault.B2B.Models;
using PhoneVault.Data;
using PhoneVault.Models;
using PhoneVault.Repositories;

namespace PhoneVault.B2B.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly PhoneVaultContext _context;

        public ItemRepository(PhoneVaultContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Item>> GetAllItems(string? brand = null, int? categoryId = null)
        {
            return await _context.Items
                .Where(p => (brand == null || p.Brand = brand) && (!categoryId.HasValue || p.CategoryId == categoryId))
                .ToListAsync();
        }
    }
}
