using System;
using EnriRanjan.Interaction;
using EnriRanjan.Inventory;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// The player stores an item in the backpack, as the consequence of a pick
    /// up or of examining/combining something that ends up in the inventory.
    /// Only items the catalog marks as Storable enter, and only while there is
    /// a free slot; every other outcome is reported back for the view to react.
    /// Generic: used across every zone of the demo.
    /// </summary>
    public sealed class AddItemToInventoryService
    {
        private InventorySystem<ItemId> _backpack;
        private ItemCatalogSystem _itemCatalog;

        public void Install(InventorySystem<ItemId> backpack, ItemCatalogSystem itemCatalog)
        {
            _backpack = backpack ?? throw new ArgumentNullException(nameof(backpack));
            _itemCatalog = itemCatalog ?? throw new ArgumentNullException(nameof(itemCatalog));
        }

        public AddItemToInventoryResult Execute(ItemId itemId)
        {
            if (!_itemCatalog.HasCapability(itemId, ItemCapabilities.Storable))
            {
                return AddItemToInventoryResult.NotStorable;
            }

            return _backpack.TryAdd(itemId, out _)
                ? AddItemToInventoryResult.Stored
                : AddItemToInventoryResult.InventoryFull;
        }
    }
}
