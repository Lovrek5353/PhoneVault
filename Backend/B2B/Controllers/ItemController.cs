using Microsoft.AspNetCore.Mvc;
using PhoneVault.B2B.Models;
using PhoneVault.B2B.Services;
using PhoneVault.Models;
using PhoneVault.Services;

namespace PhoneVault.B2B.Controllers
{
    [Route("api/b2b/[controller]")]
    [ApiController]
    public class ItemController: ControllerBase
    {
        private readonly ItemService _itemService;
        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items=await _itemService.GetAllItemsAsync();
            return Ok(items);
        }
    }
}
