using Microsoft.EntityFrameworkCore;
using PhoneVault.B2B.Repositories;
using PhoneVault.Data;
using PhoneVault.Models;
using PhoneVault.Repositories;
using PhoneVault.Services;

namespace PhoneVault.B2B.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository) 
        { 
            _itemRepository = itemRepository;
        }
        public async Task<IEnumerable<Item>> GetAllItemsAsync() =>
            await _itemRepository.GetAllItems();
    }
}
