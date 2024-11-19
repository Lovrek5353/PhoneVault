using PhoneVault.B2B.Models;
using PhoneVault.Models;

namespace PhoneVault.B2B.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItems(string ? brand=null, int? categoryId=null);
    }
}
