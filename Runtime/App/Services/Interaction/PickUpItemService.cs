using System;
using EnriRanjan.Interaction;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// The player grabs an object. Depending on the item's capabilities it
    /// either goes into the backpack (Storable) or stays in the hand for
    /// in-situ manipulation (torch, lever, machete...). Generic: every
    /// grabbable object in every zone goes through this use case.
    /// </summary>
    public sealed class PickUpItemService
    {
        private ItemCatalogSystem _itemCatalog;
        private AddItemToInventoryService _addItemToInventory;

        public void Install(ItemCatalogSystem itemCatalog, AddItemToInventoryService addItemToInventory)
        {
            _itemCatalog = itemCatalog ?? throw new ArgumentNullException(nameof(itemCatalog));
            _addItemToInventory = addItemToInventory ?? throw new ArgumentNullException(nameof(addItemToInventory));
        }

        public PickUpItemResult Execute(ItemId itemId)
        {
            // TODO: coordinate ItemCatalogSystem (Grabbable/Storable capabilities)
            // and AddItemToInventoryService: storable items go to the backpack,
            // hand-held tools stay in hand for in-situ manipulation.
            throw new NotImplementedException();
        }
    }
}
