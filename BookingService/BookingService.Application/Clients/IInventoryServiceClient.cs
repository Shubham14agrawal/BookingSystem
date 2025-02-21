using System.Threading.Tasks;

namespace BookingService.Application.Clients
{
    public interface IInventoryServiceClient
    {
        /// <summary>
        /// Checks if the inventory item is available.
        /// </summary>
        Task<bool> IsInventoryAvailableAsync(int inventoryItemId);

        /// <summary>
        /// Decrements the inventory count for the given item.
        /// </summary>
        Task<bool> DecrementInventoryAsync(int inventoryItemId);


        /// <summary>
        /// Decrements the inventory count for the given item.
        /// </summary>
        Task<bool> IncreaseInventoryAsync(int inventoryItemId);
    }
}
